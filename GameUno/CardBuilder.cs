namespace GameUno
{
    // Строит компоненты игровой карты
    public static class CardBuilder
    {
        // Построение карт с номерами 0..9
        public static void BuildNumericCard(Card card, int number)
        {
            card.Feature = new PrimitiveFeature(number);
            card.Cost = number;
        }

        // карта с требованием пропуска хода
        public static void BuildSkipCard(Card card)
        {
            card.Feature = new ActiveFeature(AllowedOperations.Skip);
            card.Cost = 20;
        }

        // карта с требованием смены направления
        public static void BuildRotateCard(Card card)
        {
            card.Feature = new ActiveFeature(AllowedOperations.Rotate);
            card.Cost = 20;
        }

        // карта с требованием взять две карты
        public static void BuildTakeTwoCard(Card card)
        {
            card.Feature = new ActiveFeature(AllowedOperations.TakeTwo);
            card.Cost = 20;
        }

        // карта с возможностью выбрать новый цвет
        public static void BuildWildColorCard(Card card)
        {
            //card.Color = CardColor.Black;
            card.Feature = new WildFeature(AllowedOperations.Color);
            card.Cost = 50;
        }

        // карта с возможностью выбрать новый цвет и с требованием взять ещё четыре карты
        public static void BuildWildColorTakeFourCard(Card card)
        {
            //card.Color = CardColor.Black;
            card.Feature = new WildFeature(AllowedOperations.Color | AllowedOperations.TakeFour);
            card.Cost = 50;
        }
    }
}
