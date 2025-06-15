using Building.Enums;

namespace Building.Classes.Concretes.Elevators
{
    ///<summary>
    /// Heavy Goods.
    ///</summary>
    public sealed class Freight : ElevatorType
    {
        
        private string _speed = ElevatorSpeeds.Slow.ToString();
        private int _passengerLimit = 0;
        private double _weightLimit = 141.74;
        private int _numberOfElevators = (int)ElevatorTypes.Freight;
        private List<int> _floorsServed = new List<int> { (int)Floors.Basement, (int)Floors.Roof };
  
        public Freight(string id) : base(type: "Freight", id)
        {
            
        }
        
        public override int NumberOfElevators { get => _numberOfElevators; init => _numberOfElevators = value; }
        public override int PassengerLimit { get => _passengerLimit; init => _passengerLimit = value; }
        public override double WeightLimit { get => _weightLimit; init => _weightLimit = value;}
        public override List<int> FloorsServed { get => _floorsServed; init => _floorsServed = value; }

        public override string Speed { get => _speed; set => _speed = value; }
        
        
    }
}