using MySql.Data.MySqlClient;


namespace GameUno
{
    public static class Helper
    {
        class Content
        {
            public int Id { get; set; }
            public string? Name { get; set; }
        }

        public static List<Card> GetHandsCards(int stepOrder)
        {
            var list = new List<Card>();
            using (var server = new Server())
            {
                if (server.Connected)
                {
                    using (var command = new MySqlCommand(
                        $"SELECT `Id`,`Name` FROM `Hands` WHERE `Order`=@Order",
                        server.Connection))
                    {
                        command.Parameters.AddWithValue("@Order", stepOrder);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var id = reader.GetInt32(0);
                                var name = reader.GetString(1);
                                CreateAndAddCardToList(list, id, name);
                            }
                        }
                    }
                }
            }
            list.Sort(ComparisonCardsFunc);
            return list;
        }

        private static int ComparisonCardsFunc(Card x, Card y)
        {
            if (x.Color == y.Color)
            {
                if (x.Cost == y.Cost) return 0;
                if (x.Cost > y.Cost) return 1;
                return -1;
            }
            else
            if (x.Color > y.Color) return 1;
            return -1;
        }

        public static Card? CreateACard(int id, string? name)
        {
            var list = new List<Card>();
            CreateAndAddCardToList(list, id, name);
            return list.Count == 1 ? list[0] : null;
        }

        private static void CreateAndAddCardToList(List<Card> list, int id, string? name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Card name cannot be null or empty.", nameof(name));
            }
            var card = new Card(id, name);
            var n = 0;
            foreach (var colorName in Enum.GetNames(typeof(CardColor)))
            {
                if (name.StartsWith(colorName))
                {
                    card.Color = (CardColor)n;
                    var funcName = name.Substring(colorName.Length).Trim('(', ')');
                    if (int.TryParse(funcName, out int number))
                    {
                        CardBuilder.BuildNumericCard(card, number);
                        list.Add(card);
                    }
                    else
                    {
                        switch (funcName)
                        {
                            case "ActiveRotate":
                                CardBuilder.BuildRotateCard(card);
                                list.Add(card);
                                break;
                            case "ActiveSkip":
                                CardBuilder.BuildSkipCard(card);
                                list.Add(card);
                                break;
                            case "ActiveTakeTwo":
                                CardBuilder.BuildTakeTwoCard(card);
                                list.Add(card);
                                break;
                            case "WildColor":
                                CardBuilder.BuildWildColorCard(card);
                                list.Add(card);
                                break;
                            case "WildColor, TakeFour":
                                CardBuilder.BuildWildColorTakeFourCard(card);
                                list.Add(card);
                                break;
                        }
                    }
                }
                n++;
            }
        }

        public static Card? GetPurchaseCardToHands(int stepOrder, int count = 1)
        {
            Card? card = null;
            using (var server = new Server())
            {
                if (server.Connected)
                {
                    var tr = server.Connection.BeginTransaction();
                    try
                    {
                        int cardsCount;
                        using (var command = new MySqlCommand(
                           "SELECT COUNT(*) FROM `Purchase`", server.Connection))
                        {
                            cardsCount = (int)(long)command.ExecuteScalar();
                        }
                        if (cardsCount < count)
                            RebuildPurchase(server.Connection, tr);

                        var list = new List<Content>();
                        using (var command = new MySqlCommand(
                            $"SELECT `Id`,`Name` FROM `Purchase` ORDER BY `Id` LIMIT {count}",
                            server.Connection, tr))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    list.Add(new Content()
                                    {
                                        Id = reader.GetInt32(0),
                                        Name = reader.GetString(1),
                                    });
                                }
                            }
                        }
                        foreach (var item in list)
                        {
                            using (var insertCommand = new MySqlCommand(
                                "INSERT INTO `Hands` (`Order`,`Name`) VALUES (@Order,@Name)",
                                server.Connection, tr))
                            {
                                insertCommand.Parameters.AddWithValue("@Order", stepOrder);
                                insertCommand.Parameters.AddWithValue("@Name", item.Name);
                                insertCommand.ExecuteNonQuery();
                            }
                            // очистка колоды прикупа
                            using (var command = new MySqlCommand("DELETE FROM `Purchase` WHERE `Id`=@Id", server.Connection, tr))
                            {
                                command.Parameters.AddWithValue("@Id", item.Id);
                                command.ExecuteNonQuery();
                            }
                        }
                        tr.Commit();
                        var lastCard = list.Last();
                        card = CreateACard(lastCard.Id, lastCard.Name);
                    }
                    catch
                    {
                        tr.Rollback();
                    }
                }
            }
            return card;
        }

        private static void RebuildPurchase(MySqlConnection connection, MySqlTransaction tr)
        {
            var list = new List<Content>();
            using (var command = new MySqlCommand("SELECT `Id`,`Name` FROM `Drop`", connection, tr))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Content()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                        });
                    }
                }
            }
            foreach (var item in list)
            {
                using (var insertCommand = new MySqlCommand(
                    "INSERT INTO `Purchase` (`Order`,`Name`) VALUES (@Order,@Name)", connection, tr))
                {
                    insertCommand.Parameters.AddWithValue("@Order", item.Id);
                    insertCommand.Parameters.AddWithValue("@Name", item.Name);
                    insertCommand.ExecuteNonQuery();
                }
                // очистка колоды прикупа
                using (var command = new MySqlCommand("DELETE FROM `Drop` WHERE `Id`=@Id", connection, tr))
                {
                    command.Parameters.AddWithValue("@Id", item.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void GetPurchaseCardToDropFirstCard()
        {
            using (var server = new Server())
            {
                if (server.Connected)
                {
                    var tr = server.Connection.BeginTransaction();
                    try
                    {
                        // очистка колоды сброса
                        using (var command = new MySqlCommand("DELETE FROM `Drop`", server.Connection, tr))
                        {
                            command.ExecuteNonQuery();
                        }
                        var list = new List<Content>();
                        using (var command = new MySqlCommand(
                            $"SELECT `Id`,`Name` FROM `Purchase` ORDER BY `Id` LIMIT 1",
                            server.Connection, tr))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    list.Add(new Content()
                                    {
                                        Id = reader.GetInt32(0),
                                        Name = reader.GetString(1),
                                    });
                                }
                            }
                        }
                        foreach (var item in list)
                        {
                            using (var insertCommand = new MySqlCommand(
                                "INSERT INTO `Drop` (`Name`) VALUES (@Name)",
                                server.Connection, tr))
                            {
                                insertCommand.Parameters.AddWithValue("@Name", item.Name);
                                insertCommand.ExecuteNonQuery();
                            }
                            // очистка колоды прикупа
                            using (var command = new MySqlCommand("DELETE FROM `Purchase` WHERE `Id`=@Id", server.Connection, tr))
                            {
                                command.Parameters.AddWithValue("@Id", item.Id);
                                command.ExecuteNonQuery();
                            }
                        }
                        tr.Commit();
                    }
                    catch
                    {
                        tr.Rollback();
                    }
                }
            }
        }

        public static void EmptyHands()
        {
            using (var server = new Server())
            {
                if (server.Connected)
                {
                    // очистка колод на руках
                    using (var command = new MySqlCommand("DELETE FROM `Hands`", server.Connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public static Dictionary<string, Image> GetResourceImages()
        {
            var dict = new Dictionary<string, Image>();
            var heights = new int[] { 0, 360, 720, 1080, 1440, 1800, 2160, 2520 };
            var widths = new int[] { 0, 240, 480, 720, 960, 1200, 1440, 1680, 1920, 2160, 2400, 2640, 2880, 3120 };
            var colorNames = Enum.GetNames(typeof(CardColor)).Take(4).ToArray();
            // источник рисунка игральной поверхности карт
            var source = Properties.Resources.Cards;
            using (var graphics = Graphics.FromImage(source))
            {
                var width = 241;
                var height = 360;
                for (var i = 0; i < 8; i++)
                {
                    for (var j = 0; j < 14; j++)
                    {
                        var rect = new Rectangle(widths[j], heights[i], width, height);
                        var image = new Bitmap(width, height);
                        using (var g = Graphics.FromImage(image))
                        {
                            g.FillRectangle(Brushes.Green, rect);
                            g.DrawImage(source, 0, 0, rect, GraphicsUnit.Pixel);
                        }
                        image.MakeTransparent(Color.Green);
                        // пропускаем пустые карты, всего должно получиться 108 карт в колоде
                        if (i > 3 && j == 0)
                            continue;
                        string key = string.Empty;
                        var colorName = j == 13 ? $"Black" : $"{colorNames[i % 4]}";
                        switch (j)
                        {
                            case 10:
                                key = $"{colorName}(ActiveSkip)";
                                break;
                            case 11:
                                key = $"{colorName}(ActiveRotate)";
                                break;
                            case 12:
                                key = $"{colorName}(ActiveTakeTwo)";
                                break;
                            case 13:
                                if (i < 4)
                                    key = "Black(WildColor)";
                                else
                                    key = "Black(WildColor, TakeFour)";
                                break;
                            default:
                                if (j <= 9)
                                    key = $"{colorName}({j})";
                                break;
                        }
                        if (!string.IsNullOrEmpty(key) && !dict.ContainsKey(key))
                        {
                            dict.Add(key, image);
                            if (key == "Black(WildColor)")
                            {
                                foreach (var cn in colorNames)
                                    dict.Add($"{cn}(WildColor)", image);
                            }
                            if (key == "Black(WildColor, TakeFour)")
                            {
                                foreach (var cn in colorNames)
                                    dict.Add($"{cn}(WildColor, TakeFour)", image);
                            }
                        }
                    }
                }
            }
            return dict;
        }

        public static int CalculateWinScore(int winOrder)
        {
            var score = 0;
            for (int i = 1; i <= Game.PlaceCount; i++)
            {
                if (i == winOrder) continue;
                score += GetHandsCards(i).Sum(card => card.Cost);
            }
            return score;
        }
    }
}
