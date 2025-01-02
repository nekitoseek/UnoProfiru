namespace GameUno
{
    // Допустимые операции над картой
    [Serializable]
    [Flags]
    public enum AllowedOperations : uint
    {
        Drop = 0x0,
        Skip = 0x1,
        Rotate = 0x2,
        TakeTwo = 0x4,
        Color = 0x8,
        Wild = 0x10,
        TakeFour = 0x20,
        All = 0xffffffff,
    }
}
