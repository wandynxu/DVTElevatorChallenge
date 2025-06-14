using Building.Enums;

namespace Elevator.Classes.Concretes
{
    ///<summary>
    /// Transport small loads(Floor to floor).
    /// and are not used for transporting people.
    ///</summary> 
    public sealed class DumbWaiter : Elevator
    {
        
        private string _speed = ElevatorSpeeds.Slow.ToString();
        private int _passengerLimit = 0;
        private double _weightLimit = 54.5;
        private int _numberOfElevators = (int)Elevators.Dumbwaiter;
        private List<int> _floorsServed = new List<int> { (int)Floors.Restaurant, (int)Floors.Residential };

        public DumbWaiter(string id) : base(type: "DumbWaiter", id)
        {
            
        }

        public override int NumberOfElevators { get => _numberOfElevators; init => _numberOfElevators = value; }
        public override int PassengerLimit { get => _passengerLimit; init => _passengerLimit = value; }
        public override double WeightLimit { get => _weightLimit; init => _weightLimit = value;}
        public override List<int> FloorsServed { get => _floorsServed; init => _floorsServed = value; }

        public override string Speed { get => _speed; set => _speed = value; }
        
        
    }
}