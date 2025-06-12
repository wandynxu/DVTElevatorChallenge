using Building.Enums;

namespace Elevator.Classes
{
    public abstract class Elevator
    {
        protected bool isMoving = false;
        protected string direction = ElevatorDirection.Idle.ToString();
        protected bool operational = true;
        protected string speed = ElevatorSpeeds.Normal.ToString();
        public Elevator(string type, string id)
        {
            Type = type;
            Id = id;
        }

        /// <summary>
        /// Type of elevator been used.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Type of elevator been used.
        /// </summary>
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Number Of Elevators for each type of elevator in the building.
        /// </summary>
        public abstract int NumberOfElevators { get; }
        /// <summary>
        /// Maximum weight in a static state in Kg
        /// </summary>
        public abstract double WeightCapacity { get; }
        /// <summary>
        /// Maximum weight can withstand during movement in Kg
        /// </summary>
        public abstract double WeightLimit { get; }
        /// <summary>
        ///   Authorized personnel only.
        /// </summary>
        public abstract bool AuthorizedPersonnel { get; }
        public abstract string Speed { get; init; }
        public abstract int CurrentFloor { get; set; }
        public abstract bool IsMoving { get; set; }
        public abstract string Direction { get; set; }
        public abstract bool Operational { get; set; }
        
        
    }
}