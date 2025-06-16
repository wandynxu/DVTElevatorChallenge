
namespace Building.Classes
{
    public abstract class ElevatorType
    {
        protected int currentFloor = 0;
        protected int currentNumberOfPassengers = 0;
        protected double currentWeightOfGoods = 0.0;
        protected string? speed = Enums.Elevator.Speed.Normal.ToString();
        protected string? direction = Enums.Elevator.Direction.Idle.ToString();
        protected string? state = Enums.Elevator.State.Stationary.ToString();

        internal ElevatorType(string type, string id)
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
        public abstract int NumberOfElevators { get; }
        /// <summary>
        /// Maximum passengers in elevator.
        /// </summary>
        public abstract int PassengerLimit { get; }
        /// <summary>
        /// Maximum weight can withstand during movement.
        /// </summary>
        public abstract double WeightLimit { get; }
        /// <summary>
        /// Maximum floors that served.
        /// </summary>
        public abstract IReadOnlyList<int> FloorsServed { get; }

        public abstract int CurrentFloor { get; set; }
        public abstract int CurrentNumberOfPassengers { get; set; }
        public abstract double CurrentWeightOfGoods { get; set; }
        public abstract string Speed { get; set; }
        public abstract string Direction { get; set; }
        public abstract string State { get; set; }

        public override string ToString()
        {
            if (CurrentWeightOfGoods == 0)
            {
                return $"Elevator: {Type}, CurrentFloor: {CurrentFloor}, Direction: {Direction}, State: {State}, Number Of Passengers: {CurrentNumberOfPassengers}";
            }
            return $"Elevator: {Type}, CurrentFloor: {CurrentFloor}, Direction: {Direction}, State: {State}, Weight Of Goods: {CurrentWeightOfGoods}";
        } 
    }
}