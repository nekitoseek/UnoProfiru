namespace GameUno
{
    [Serializable]
    public class WildFeature : Feature
    {

        // Локальное поле для хранения ограничений для операций
        readonly AllowedOperations allowedOperations;

        // Свойство возвращает определённые в конструкторе ограничения для операций
        public override AllowedOperations AllowedOperations { get { return allowedOperations; } }

        public AllowedOperations Allowed { get; }

        internal WildFeature(AllowedOperations allowed)
        {
            Allowed = allowed;
            Name = $"Wild{allowed}";
            // запоминаем ограничения для операций в локальном поле
            allowedOperations = AllowedOperations.Drop | AllowedOperations.Wild | allowed;
        }

        public override string? ToString()
        {
            return Name;
        }
    }
}
