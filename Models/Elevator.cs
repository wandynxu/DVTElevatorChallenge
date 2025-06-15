namespace Building.Models
{
    /// <summary>
    /// Elevator class representing an elevator in a building.
    /// </summary>
    public class Elevator
    {
        public required string Id { get; init; }
        public required string Name { get; init; }
        public int CurrentFloor { get; set; }
        public int TargetFloor { get; set; }
        public string? Speed { get; set; }
        ///<summary>
        /// Number of passengers carrying.
        ///</summary>
        public int NumberOfPassengers { get; set; }
        ///<summary>
        /// Weight of goods to be transported.
        ///</summary>
        public double WeightOfGoods { get; set; }
    }
}