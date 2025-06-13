using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using Building.Enums;
using Building.Models;

namespace Elevator.Classes.Concretes
{
    ///<summary>
    /// Transport small loads(Floor to floor).
    /// and are not used for transporting people.
    ///</summary> 
    public sealed class DumbWaiter : Elevator
    {
        private readonly ElevatorType _elevator = default!;
        private int _currentFloor = (int)Floors.Restaurant;
        private string _speed = ElevatorSpeeds.Slow.ToString();
        private double _weightCapacity = 54.0;
        private double _weightLimit = 50.0;
        private int _numberOfElevators = (int)Elevators.Dumbwaiter;
        private List<int> _floorsServed = new List<int> { (int)Floors.Restaurant, (int)Floors.Residential };

        
        public DumbWaiter(ElevatorType elevator, string id) : base(type: "DumbWaiter", id)
        {
            _elevator = elevator;
        }


        public override int NumberOfElevators { get => _numberOfElevators; init => _numberOfElevators = value; }
        public override double WeightCapacity { get => _weightCapacity; init => _weightCapacity = value; }
        public override double WeightLimit { get => _weightLimit; init => _weightCapacity = value;}
        public override List<int> FloorsServed { get => _floorsServed; init => _floorsServed = value; }


        public override string Speed { get => _speed; set => _speed = value; }
        public override int CurrentFloor { get => _currentFloor; set => _currentFloor = _elevator.CurrentFloor; }
        public override bool IsMoving { get => isMoving; set => isMoving = _elevator.IsMoving; }
        
        public override bool Operational { get => operational; set => operational = _elevator.IsOperational; }
        
    }
}