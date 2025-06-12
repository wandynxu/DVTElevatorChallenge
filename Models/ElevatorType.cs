namespace Building.Models
{
    /// <summary>
    /// Elevator class representing an elevator in a building.
    /// </summary>
    public class ElevatorType
    {
        public required string Id { get; init; } 
        public int CurrentFloor { get; set; }
        public int TargetFloor { get; set; }
        public string? Speed { get; set; }
        public bool IsMoving { get; set; }
        public bool IsOperational { get; set; }
        public string? Direction { get; set; }
        public bool AuthorizedPersonnel { get; set; }
        public List<int> FloorsServed { get; set; } = new List<int>();
    }
}