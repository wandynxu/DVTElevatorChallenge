using Building.Enums;

namespace Building.Classes.Concretes.Elevators
{
    ///<summary>
    /// Residential & Express.
    ///</summary>
    public class Passenger : ElevatorType
    {

        private const int _passengerLimit = 25;
        private const double _weightLimit = 100.5;
        private const int _numberOfElevators = 3;
        private List<int> _floorsServed = new List<int> { (int)Floors.Basement, (int)Floors.Roof };

        public Passenger(string id) : base(type: "Passenger", id)
        {

        }

        public override int NumberOfElevators { get => _numberOfElevators; }
        public override int PassengerLimit { get => _passengerLimit; }
        public override double WeightLimit { get => _weightLimit; }
        public override IReadOnlyList<int> FloorsServed { get => _floorsServed; }

        public override string Speed { get => speed ?? string.Empty; set => speed = value; }
        public override int CurrentNumberOfPassengers { get => currentNumberOfPassengers; set => currentNumberOfPassengers = value; }
        public override double CurrentWeightOfGoods { get => currentWeightOfGoods; set => currentWeightOfGoods = value; }
        public override string State { get => state ?? string.Empty; set => state = value; }
        public override int CurrentFloor { get => currentFloor; set => currentFloor = value; }
        public override string Direction { get => direction ?? string.Empty; set => direction = value; }
        public override int TargetFloor { get => targetFloor; set => targetFloor = value; }
    }
}