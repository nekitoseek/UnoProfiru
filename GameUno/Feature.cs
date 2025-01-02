namespace GameUno
{

    [Serializable]
    public abstract class Feature
    {
        public string? Name { get; set; }

        // Допустимые операции над картой
        public abstract AllowedOperations AllowedOperations { get; }
    }
}
