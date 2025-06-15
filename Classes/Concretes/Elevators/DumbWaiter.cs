using Building.Enums;

namespace Building.Classes.Concretes.Elevators
{
    ///<summary>
    /// Transport small loads(Floor to floor).
    /// and are not used for transporting people.
    ///</summary> 
    public sealed class DumbWaiter : ElevatorType
    {
        private string _state = ElevatorStates.Stop.ToString();
        private string _speed = ElevatorSpeeds.Slow.ToString();
        private int _passengerLimit = 0;
        private double _weightLimit = 54.5;
        private int _numberOfElevators = (int)ElevatorTypes.DumbWaiter;
        private List<int> _floorsServed = new List<int> { (int)Floors.Restaurant, (int)Floors.Residential };

        public DumbWaiter(string id) : base(type: "DumbWaiter", id)
        {

        }

        public override int NumberOfElevators { get => _numberOfElevators; init => _numberOfElevators = value; }
        public override int PassengerLimit { get => _passengerLimit; init => _passengerLimit = value; }
        public override double WeightLimit { get => _weightLimit; init => _weightLimit = value; }
        public override List<int> FloorsServed { get => _floorsServed; init => _floorsServed = value; }

        public override string Speed { get => _speed; set => _speed = value; }
        public override string State { get => _state; set => _state = value; }
        
    }
}