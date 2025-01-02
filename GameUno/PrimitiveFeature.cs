
namespace GameUno
{
    // Содержит особенности числовой карты
    [Serializable]
    public class PrimitiveFeature : Feature
    {

        // Локальное поле для хранения ограничений для операций
        readonly AllowedOperations allowedOperations;

        // Свойство возвращает определённые в конструкторе ограничения для операций
        public override AllowedOperations AllowedOperations { get { return allowedOperations; } }

        public int Number { get; }

        internal PrimitiveFeature(int number)
        {
            Number = number;
            Name = $"{number}";
            // запоминаем ограничения для операций в локальном поле
            allowedOperations = AllowedOperations.Drop;
        }

        public override string? ToString()
        {
            return Name;
        }
    }
}
