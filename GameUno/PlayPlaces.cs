using MySql.Data.MySqlClient;

namespace GameUno
{
    public static class PlayPlaces
    {
        static readonly int maxRange = Game.PlaceCount;
        public static int Order { get; private set; }

        public static void DefinePlaceOrder(string playerName)
        {
            using (var server = new Server())
            {
                if (server.Connected)
                {
                    string name;
                    for (int i = 1; i <= maxRange; i++)
                    {
                        using (var command = new MySqlCommand($"SELECT `Name` FROM `Players` WHERE `Order`=@Order", server.Connection))
                        {
                            command.Parameters.AddWithValue("@Order", i);
                            name = (string)command.ExecuteScalar();
                        }
                        if (string.IsNullOrEmpty(name))
                        {
                            using (var command = new MySqlCommand($"UPDATE `Players` SET `Name`=@Name WHERE `Order`=@Order", server.Connection))
                            {
                                command.Parameters.AddWithValue("@Name", playerName);
                                command.Parameters.AddWithValue("@Order", i);
                                command.ExecuteNonQuery();
                            }
                            Order = i;
                            return;
                        }
                    }
                }
            }
            Order = 0;
        }

        // Очистить таблицу игроков
        public static void Clear()
        {
            using (var server = new Server())
            {
                if (server.Connected)
                {
                    var tr = server.Connection.BeginTransaction();
                    try
                    {
                        using (var command = new MySqlCommand("DELETE FROM `Players`", server.Connection, tr))
                        {
                            command.ExecuteNonQuery();
                        }
                        for (int i = 1; i <= maxRange; i++)
                        {
                            using (var command = new MySqlCommand("INSERT INTO `Players` (`Order`,`Name`,`CountCards`,`PlayScore`)" +
                                " VALUES (@Order,@Name,@CountCards,@PlayScore)",
                                server.Connection, tr))
                            {
                                command.Parameters.AddWithValue("@Order", i);
                                command.Parameters.AddWithValue("@Name", string.Empty);
                                command.Parameters.AddWithValue("@CountCards", 0);
                                command.Parameters.AddWithValue("@PlayScore", 0);
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

        // Очистить таблицу результатов
        public static void ClearScores()
        {
            using (var server = new Server())
            {
                if (server.Connected)
                {
                    using (var command = new MySqlCommand("UPDATE `Players` SET `PlayScore`=0", server.Connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public static void Update()
        {
            using (var server = new Server())
            {
                if (server.Connected)
                {
                    using (var command = new MySqlCommand(
                        "SELECT `Order`,`Name`,`CountCards`,`PlayScore` FROM `Players`",
                        server.Connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var order = reader.GetInt32(0);
                                var name = reader.GetString(1);
                                var cards = reader.GetInt32(2);
                                var score = reader.GetInt32(3);
                                SetPlayer(order, name, cards, score);
                            }
                        }
                    }
                }
            }
        }

        public static event PlayerEventHandler? PlayerChanged;
        private static void SetPlayer(int order, string name, int cards, int score)
        {
            PlayerChanged?.Invoke(new object(),
                new PlayerEventArgs(order, name, cards, score));
        }

        public static void SetPlayerName(int stepOrder, string name)
        {
            using (var server = new Server())
            {
                if (server.Connected)
                {
                    using (var command = new MySqlCommand(
                        "UPDATE `Players` SET `Name`=@Name WHERE `Order`=@Order", server.Connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Order", stepOrder);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public static string? GetPlayerName(int stepOrder)
        {
            using (var server = new Server())
            {
                if (server.Connected)
                {
                    using (var command = new MySqlCommand(
                        "SELECT `Name` FROM `Players` WHERE `Order`=@Order", server.Connection))
                    {
                        command.Parameters.AddWithValue("@Order", stepOrder);
                        var name = (string)command.ExecuteScalar();
                        return string.IsNullOrWhiteSpace(name) ? $"Бот {stepOrder}" : name;
                    }
                }
            }
            return null;
        }

        // Очистить место имени игрока после отключения
        public static void ClearPlayerPlace(int stepOrder)
        {
            using (var server = new Server())
            {
                if (server.Connected)
                {
                    using (var command = new MySqlCommand(
                        "UPDATE `Players` SET `Name`=@Name WHERE,`CountCards`=@CountCards,`PlayScore`=@PlayScore `Order`=@Order",
                        server.Connection))
                    {
                        command.Parameters.AddWithValue("@Name", string.Empty);
                        command.Parameters.AddWithValue("@CountCards", 0);
                        command.Parameters.AddWithValue("@PlayScore", 0);
                        command.Parameters.AddWithValue("@Order", stepOrder);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public static void AddOrSubCountCards(int stepOrder, int addOrSub)
        {
            using (var server = new Server())
            {
                if (server.Connected)
                {
                    var tr = server.Connection.BeginTransaction();
                    try
                    {
                        int count = 0;
                        using (var command = new MySqlCommand(
                            "SELECT `CountCards` FROM `Players` WHERE `Order`=@Order", server.Connection, tr))
                        {
                            command.Parameters.AddWithValue("@Order", stepOrder);
                            count = (int)command.ExecuteScalar();
                        }
                        using (var command = new MySqlCommand(
                            "UPDATE `Players` SET `CountCards`=@CountCards WHERE `Order`=@Order", server.Connection, tr))
                        {
                            command.Parameters.AddWithValue("@CountCards", count + addOrSub);
                            command.Parameters.AddWithValue("@Order", stepOrder);
                            command.ExecuteNonQuery();
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

        public static int GetCountCards(int stepOrder)
        {
            using (var server = new Server())
            {
                if (server.Connected)
                {
                    using (var command = new MySqlCommand(
                        "SELECT `CountCards` FROM `Players` WHERE `Order`=@Order", server.Connection))
                    {
                        command.Parameters.AddWithValue("@Order", stepOrder);
                        return (int)command.ExecuteScalar();
                    }
                }
            }
            return 0;
        }

        public static void SetCountCards(int stepOrder, int count)
        {
            using (var server = new Server())
            {
                if (server.Connected)
                {
                    using (var command = new MySqlCommand(
                        "UPDATE `Players` SET `CountCards`=@CountCards WHERE `Order`=@Order", server.Connection))
                    {
                        command.Parameters.AddWithValue("@CountCards", count);
                        command.Parameters.AddWithValue("@Order", stepOrder);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public static void SetPlayScore(int stepOrder, int score)
        {
            using (var server = new Server())
            {
                if (server.Connected)
                {
                    using (var command = new MySqlCommand(
                        "UPDATE `Players` SET `PlayScore`=@PlayScore WHERE `Order`=@Order", server.Connection))
                    {
                        command.Parameters.AddWithValue("@PlayScore", score);
                        command.Parameters.AddWithValue("@Order", stepOrder);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public static int GetPlayScore(int stepOrder)
        {
            using (var server = new Server())
            {
                if (server.Connected)
                {
                    using (var command = new MySqlCommand(
                        "SELECT `PlayScore` FROM `Players` WHERE `Order`=@Order", server.Connection))
                    {
                        command.Parameters.AddWithValue("@Order", stepOrder);
                        return (int)command.ExecuteScalar();
                    }
                }
            }
            return 0;
        }

        public static int AddPlayScore(int stepOrder, int score)
        {
            var result = 0;
            using (var server = new Server())
            {
                if (server.Connected)
                {
                    var tr = server.Connection.BeginTransaction();
                    try
                    {
                        int count = 0;
                        using (var command = new MySqlCommand(
                            "SELECT `PlayScore` FROM `Players` WHERE `Order`=@Order", server.Connection, tr))
                        {
                            command.Parameters.AddWithValue("@Order", stepOrder);
                            count = (int)command.ExecuteScalar();
                        }
                        result = count + score;
                        using (var command = new MySqlCommand(
                            "UPDATE `Players` SET `PlayScore`=@PlayScore WHERE `Order`=@Order", server.Connection, tr))
                        {
                            command.Parameters.AddWithValue("@PlayScore", result);
                            command.Parameters.AddWithValue("@Order", stepOrder);
                            command.ExecuteNonQuery();
                        }
                        tr.Commit();
                    }
                    catch
                    {
                        tr.Rollback();
                    }
                }
            }
            return result;
        }

        public static void ClearPlace(int stepOrder)
        {
            SetPlayerName(stepOrder, string.Empty);
            SetCountCards(stepOrder, 0);
            SetPlayScore(stepOrder, 0);
        }
    }

    public delegate void PlayerEventHandler(object sender, PlayerEventArgs args);

    public class PlayerEventArgs : EventArgs
    {
        public PlayerEventArgs(int stepOrder, string name, int countCards, int playScore)
        {
            StepOrder = stepOrder;
            Name = name;
            CountCards = countCards;
            PlayScore = playScore;
        }

        public int StepOrder { get; }
        public string Name { get; }
        public int CountCards { get; }
        public int PlayScore { get; }
    }
}
