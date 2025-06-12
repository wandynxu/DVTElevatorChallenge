namespace Building.Enums
{
    /// <summary>
    /// Roof = 19
    /// Residential = 5 -> 18
    /// Offices = 3 -> 4
    /// Restaurant = 2
    /// Ground/Sidewalk = 1
    /// Basement = 0
    /// </summary>
    public enum Floors
    {
        Basement,
        Ground,
        Restaurant,
        Offices,
        Residential = 5,
        Roof = 19
    }
}