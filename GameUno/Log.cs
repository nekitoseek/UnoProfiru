using System.Xml.Linq;

namespace GameUno
{
    public static class Log
    {
        private static readonly string LogFilePath = "Log.xml"; // Путь к XML-файлу
        public static int NumberLastMessage { get; private set; }

        static Log()
        {
            // Инициализация: создание файла, если его нет
            if (!File.Exists(LogFilePath))
            {
                var logDocument = new XDocument(new XElement("LogMessages"));
                logDocument.Save(LogFilePath);
            }
            else
            {
                // Установить последний ID на основе существующего XML
                var logDocument = XDocument.Load(LogFilePath);
                NumberLastMessage = logDocument.Descendants("Message").Count();
            }
        }

        public static string[] SelectLastMessages(int count = 0)
        {
            var list = new List<string>();

            if (File.Exists(LogFilePath))
            {
                var logDocument = XDocument.Load(LogFilePath);
                var messages = logDocument.Descendants("Message")
                    .OrderByDescending(x => (int)x.Attribute("Id"))
                    .ToList(); // Преобразуем в List для последующих операций

                if (count > 0)
                {
                    messages = messages.Take(count).ToList(); // Ограничиваем количество сообщений
                }

                foreach (var messageElement in messages.AsEnumerable().Reverse()) // Используем Reverse на List
                {
                    list.Add(messageElement.Value);
                }
            }

            return list.ToArray();
        }




        public static void Add(string message = "")
        {
            var logDocument = XDocument.Load(LogFilePath);
            var logRoot = logDocument.Element("LogMessages");

            if (logRoot != null)
            {
                NumberLastMessage++;
                var newMessage = new XElement("Message",
                    new XAttribute("Id", NumberLastMessage),
                    message ?? string.Empty);

                logRoot.Add(newMessage);
                logDocument.Save(LogFilePath);
            }
        }

        public static void Clear()
        {
            if (File.Exists(LogFilePath))
            {
                var logDocument = new XDocument(new XElement("LogMessages"));
                logDocument.Save(LogFilePath);
                NumberLastMessage = 0;
            }
        }
    }
}
