namespace GameUno
{
    [Serializable]
    public class Card(int id, string name)
    {
        public string Name { get; private set; } = name;

        public Feature? Feature { get; set; }

        public int ID { get; } = id;

        // Стоимость карты
        public int Cost { get; set; }

        // Цвет карты
        public CardColor Color { get; set; }

        public void ChangeWildColor(CardColor color)
        {
            Color = color;
            Name = color.ToString() + Name.Substring(Name.IndexOf('('));
        }

        public override string ToString()
        {
            return $"{Color}({Feature})";
        }
    }
}
