namespace GameUno
{
    // Содержит особенности активной карты
    [Serializable]
    public class ActiveFeature : Feature
    {

        // Локальное поле для хранения ограничений для операций
        readonly AllowedOperations allowedOperations;

        // Свойство возвращает определённые в конструкторе ограничения для операций
        public override AllowedOperations AllowedOperations { get { return allowedOperations; } }

        public AllowedOperations Allowed { get; }

        internal ActiveFeature(AllowedOperations allowed)
        {
            Allowed = allowed;
            Name = $"Active{allowed}";
            // запоминаем ограничения для операций в локальном поле
            allowedOperations = AllowedOperations.Drop | allowed;
        }

        public override string ToString()
        {
            return Name ?? "Unnamed Feature";
        }
    }
}
