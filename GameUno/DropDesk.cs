using MySql.Data.MySqlClient;

namespace GameUno
{
    public static class DropDesk
    {
        public static Card? TopCard { get; private set; }

        public static void DropACard(Card? card)
        {
            using (var server = new Server())
            {
                if (server.Connected)
                {
                    var tr = server.Connection.BeginTransaction();
                    try
                    {
                        // очистка карт на руках
                        using (var command = new MySqlCommand("DELETE FROM `Hands` WHERE `Id`=@Id", server.Connection, tr))
                        {
                            command.Parameters.AddWithValue("@Id", card?.ID);
                            command.ExecuteNonQuery();
                        }
                        using (var insertCommand = new MySqlCommand(
                            "INSERT INTO `Drop` (`Name`) VALUES (@Name)",
                            server.Connection, tr))
                        {
                            insertCommand.Parameters.AddWithValue("@Name", card?.Name);
                            insertCommand.ExecuteNonQuery();
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

        public static void Update()
        {
            using (var server = new Server())
            {
                if (server.Connected)
                {
                    using (var command = new MySqlCommand(
                        "SELECT `Id`,`Name` FROM `Drop` ORDER BY `Id` DESC LIMIT 1",
                        server.Connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var id = reader.GetInt32(0);
                                var name = reader.GetString(1);
                                SetName(id, name);
                                break;
                            }
                        }
                    }
                }
            }
        }

        public static event EventHandler? TopCardChanged;
        private static void SetName(int id, string name)
        {
            var card = Helper.CreateACard(id, name);
            if (card != null)
                TopCardChanged?.Invoke(card, EventArgs.Empty);
        }

        public static void Clear()
        {
            using (var server = new Server())
            {
                if (server.Connected)
                {
                    var tr = server.Connection.BeginTransaction();
                    try
                    {
                        using (var command = new MySqlCommand("DELETE FROM `Drop`", server.Connection, tr))
                        {
                            command.ExecuteNonQuery();
                        }
                        using (var command = new MySqlCommand("DELETE FROM `Hands`", server.Connection, tr))
                        {
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
    }
}
