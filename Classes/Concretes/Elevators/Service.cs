using Building.Enums;

namespace Building.Classes.Concretes.Elevators
{
    ///<summary>
    /// Only Staff Members.
    /// Only authorized personnel.
    ///</summary>
    public sealed class Service: ElevatorType
    {
        
        private string _speed = ElevatorSpeeds.Normal.ToString();
        private int _passengerLimit = 4;
        private double _weightLimit = 80.5;
        private int _numberOfElevators = (int)ElevatorTypes.Service;
        private List<int> _floorsServed = new List<int> { (int)Floors.Basement, (int)Floors.Roof };

        public Service(string id) : base(type: "Service", id)
        {
        }
        
        public override int NumberOfElevators { get => _numberOfElevators; init => _numberOfElevators = value; }
        public override int PassengerLimit { get => _passengerLimit; init => _passengerLimit = value; }
        public override double WeightLimit { get => _weightLimit; init => _weightLimit = value;}
        public override List<int> FloorsServed { get => _floorsServed; init => _floorsServed = value; }

        public override string Speed { get => _speed; set => _speed = value; }
        
    }
}