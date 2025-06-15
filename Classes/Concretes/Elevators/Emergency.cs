using Building.Enums;

namespace Building.Classes.Concretes.Elevators
{
    ///<summary>
    /// Only Evacuation Purposes.
    ///</summary>
    public class Emergency : ElevatorType
    {
        private string _state = ElevatorStates.Stop.ToString();
        private string _speed = ElevatorSpeeds.Fast.ToString();
        private int _passengerLimit = 15;
        private double _weightLimit = 79.5;
        private int _numberOfElevators = (int)ElevatorTypes.Emergency;
        private List<int> _floorsServed = new List<int> { (int)Floors.Ground, (int)Floors.Roof };

        public Emergency(string id) : base(type: "Emergency", id)
        {
           
        }

        public override int NumberOfElevators { get => _numberOfElevators; init => _numberOfElevators = value; }
        public override int PassengerLimit { get => _passengerLimit; init => _passengerLimit = value; }
        public override double WeightLimit { get => _weightLimit; init => _weightLimit = value;}
        public override List<int> FloorsServed { get => _floorsServed; init => _floorsServed = value; }

        public override string Speed { get => _speed; set => _speed = value; }
        public override string State { get => _state; set => _state = value; }
    }    
}