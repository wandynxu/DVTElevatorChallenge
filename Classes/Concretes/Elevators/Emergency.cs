using Building.Enums;

namespace Building.Classes.Concretes.Elevators
{
    ///<summary>
    /// Only Evacuation Purposes.
    ///</summary>
    public class Emergency : ElevatorType
    {
        
        private const int _passengerLimit = 20;
        private const double _weightLimit = 79.5;
        private const int _numberOfElevators = (int)ElevatorTypes.Emergency;
        private List<int> _floorsServed = new List<int> { (int)Floors.Ground, (int)Floors.Roof };

        public Emergency(string id) : base(type: "Emergency", id)
        {
           
        }

        public override int NumberOfElevators { get => _numberOfElevators; }
        public override int PassengerLimit { get => _passengerLimit; }
        public override double WeightLimit { get => _weightLimit;  }
        public override IReadOnlyList<int> FloorsServed { get => _floorsServed; }

        public override string Speed { get => Speed; set => speed = value; }
        public override string State { get => State; set => state = value; }
        public override int CurrentFloor { get => CurrentFloor; set => currentFloor = value; }
        public override int CurrentNumberOfPassengers { get => CurrentNumberOfPassengers; set => currentNumberOfPassengers = value; }
        public override double CurrentWeightOfGoods { get => CurrentWeightOfGoods; set => currentWeightOfGoods = value; }
        public override string Direction { get => Direction; set => direction = value; }
    }    
}