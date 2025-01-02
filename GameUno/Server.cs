using MySql.Data.MySqlClient;

namespace GameUno
{
    public sealed class Server : IDisposable
    {
        private readonly string connectionString = string.Empty;
        private static string lasterrorString = string.Empty;
        public MySqlConnection Connection;
        private readonly bool serverConnected = false;

        public static string LastError { get { return lasterrorString; } }

        public Server()
        {
            // "server=localhost;user=root;port=3306;password=3141592653;database=UNO;";
            connectionString = Properties.Settings.Default.ConnectionString;
            Connection = new MySqlConnection(connectionString);
            serverConnected = TryToConnect();
        }

        public void Dispose()
        {
            Connection.Dispose();
        }

        private bool TryToConnect()
        {
            try
            {
                // произведем попытку подключения
                Connection.Open();
                lasterrorString = string.Empty;
                return true;
            }
            catch (Exception e)
            {
                lasterrorString = e.Message;
                return false;
            }
        }

        public bool Connected
        {
            get
            {
                return serverConnected;
            }
        }
    }
}
