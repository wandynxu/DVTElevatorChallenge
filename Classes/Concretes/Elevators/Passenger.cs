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
        private const int _numberOfElevators = (int)ElevatorTypes.Passenger;
        private List<int> _floorsServed = new List<int> { (int)Floors.Basement, (int)Floors.Roof };

        public Passenger(string id) : base(type: "Passenger", id)
        {

        }

        public override int NumberOfElevators { get => _numberOfElevators; }
        public override int PassengerLimit { get => _passengerLimit; }
        public override double WeightLimit { get => _weightLimit; }
        public override IReadOnlyList<int> FloorsServed { get => _floorsServed; }

        public override string Speed { get => Speed; set => speed = value; }
        public override string State { get => State; set => state = value; }
        public override int CurrentFloor { get => CurrentFloor; set => currentFloor = value; }
        public override int CurrentNumberOfPassengers { get => CurrentNumberOfPassengers; set => currentNumberOfPassengers = value; }
        public override double CurrentWeightOfGoods { get => CurrentWeightOfGoods; set => currentWeightOfGoods = value; }
        public override string Direction { get => Direction; set => direction = value; }
    }
}