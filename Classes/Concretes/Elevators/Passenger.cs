using Building.Enums;
using Building.Models;

namespace Elevator.Classes.Concretes
{
    ///<summary>
    /// Residential & Express.
    ///</summary>
    public class Passenger: Elevator
    {
        private string _speed = ElevatorSpeeds.Normal.ToString();
        private int _passengerLimit = 25;
        private double _weightLimit = 100.5;
        private int _numberOfElevators = (int)Elevators.Passenger;
        private List<int> _floorsServed = new List<int> { (int)Floors.Basement, (int)Floors.Roof };

        public Passenger(string id) : base(type: "Passenger", id)
        {
           
        }
    
        public override int NumberOfElevators { get => _numberOfElevators; init => _numberOfElevators = value; }
        public override int PassengerLimit { get => _passengerLimit; init => _passengerLimit = value; }
        public override double WeightLimit { get => _weightLimit; init => _weightLimit = value;}
        public override List<int> FloorsServed { get => _floorsServed; init => _floorsServed = value; }


        public override string Speed { get => _speed; set => _speed = value; }
        
        
    }
}