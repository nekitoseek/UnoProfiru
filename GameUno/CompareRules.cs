namespace GameUno
{
    public static class CompareCardsRules
    {
        // Правила сравнения карт "UNO"
        public static bool Compare(CardColor color, Card origin, Card test)
        {
            return test.Feature is WildFeature || color == test.Color ||
                (origin.Feature is PrimitiveFeature num1) && (test.Feature is PrimitiveFeature num2) && num1.Number == num2.Number ||
                (origin.Feature is ActiveFeature act1) && (test.Feature is ActiveFeature act2) && act1.Allowed == act2.Allowed;
        }
    }
}
