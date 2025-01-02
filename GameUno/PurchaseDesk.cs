using MySql.Data.MySqlClient;

namespace GameUno
{
    public static class PurchaseDesk
    {
        public static int CardsCount()
        {
            using (var server = new Server())
            {
                if (server.Connected)
                {
                    using (var command = new MySqlCommand(
                        "SELECT COUNT(*) FROM `Purchase`", server.Connection))
                    {
                        return (int)(long)command.ExecuteScalar();
                    }
                }
            }
            return 0;
        }

        public static void DropThisCardId(int id)
        {
            using (var server = new Server())
            {
                if (server.Connected)
                {
                    // очистка колоды прикупа
                    using (var command = new MySqlCommand("DELETE FROM `Purchase` WHERE `Id`=@Id", server.Connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public static void ReshuffleCards()
        {
            using (var server = new Server())
            {
                if (server.Connected)
                {
                    var tr = server.Connection.BeginTransaction();
                    try
                    {
                        var list = new List<int>();
                        using (var command = new MySqlCommand("SELECT `Id` FROM `Desk` ORDER BY `Id`", server.Connection, tr))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                    list.Add(reader.GetInt32(0));
                            }
                        }
                        // очистка колоды прикупа
                        using (var command = new MySqlCommand("DELETE FROM `Purchase`", server.Connection, tr))
                        {
                            command.ExecuteNonQuery();
                        }
                        // перетасуем карты, делаем выборку из колоды образцов в колоду прикупа в случайном порядке
                        var rand = new Random();
                        while (list.Count > 0)
                        {
                            var index = rand.Next(0, list.Count);
                            var cardIndex = list[index];
                            list.RemoveAt(index);
                            string? name = null;
                            using (var command = new MySqlCommand("SELECT `Name` FROM `UNO`.`Desk` WHERE `Id`=@Id",
                                server.Connection, tr))
                            {
                                command.Parameters.AddWithValue("@Id", cardIndex);
                                using (var reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        name = reader.GetString(0);
                                        break;
                                    }
                                }
                            }
                            if (name != null)
                            {
                                using (var insertCommand = new MySqlCommand("INSERT INTO `Purchase` (`Name`) VALUES (@Name)",
                                    server.Connection, tr))
                                {
                                    insertCommand.Parameters.AddWithValue("@Name", name);
                                    insertCommand.ExecuteNonQuery();
                                }
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
    }
}
