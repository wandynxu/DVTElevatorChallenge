using Building.Enums;

namespace Elevator.Classes
{
    public abstract class Elevator
    {
        protected bool isMoving = false;
        protected bool operational = true;
        public Elevator(string type, string id)
        {
            Type = type;
            Id = id;
        }
        /// <summary>
        /// Elevator Id.
        /// </summary>
        public string Id { get; set; } = string.Empty;
        /// <summary>
        /// Type of elevator been used.
        /// </summary>
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Number Of Elevators for each type of elevator in the building.
        /// </summary>
        public abstract int NumberOfElevators { get; init; }
        /// <summary>
        /// Maximum weight in a static state in Kg.
        /// </summary>
        public abstract double WeightCapacity { get; init; }
        /// <summary>
        /// Maximum weight can withstand during movement in Kg.
        /// </summary>
        public abstract double WeightLimit { get; init; }
        /// <summary>
        /// Maximum floors that served.
        /// </summary>
        public abstract List<int> FloorsServed { get; init; }

        public abstract string Speed { get; set; }
        public abstract int CurrentFloor { get; set; }
        public abstract bool IsMoving { get; set; }
        public abstract bool Operational { get; set; }

        public override string ToString()
        {
            return "Elevator:{ElevatorType}, CurrentFloor:{CurrentFloor}, IsMoving:{In Motion/Stationary}, NumberOfPassengers:{Passengers}/WeightOfGoods:{Passengers}";
        }
    }
}