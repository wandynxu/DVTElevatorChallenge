using Building.Enums;
using Building.Models;


namespace Elevator.Classes.Concretes
{
    ///<summary>
    /// Moving materials to and from a basement and open directly onto a sidewalk
    /// Can also be used by people.
    ///</summary>
    public sealed class Sidewalk: Elevator
    {
        private readonly ElevatorType _elevator;
        private int _currentFloor = (int)Floors.Basement;
        private string _speed = ElevatorSpeeds.Slow.ToString();
        private double _weightCapacity = 59.5;
        private double _weightLimit = 85.4;
        private int _numberOfElevators = (int)Elevators.Sidewalk;
        private List<int> _floorsServed = new List<int> { (int)Floors.Basement, (int)Floors.Ground };
        public Sidewalk(ElevatorType elevator, string id) : base(type: "Sidewalk", id)
        {
            _elevator = elevator;
        }
        public override int NumberOfElevators { get => _numberOfElevators; init => _numberOfElevators = value;}
        public override double WeightCapacity { get => _weightCapacity; init => _weightCapacity = value; }
        public override double WeightLimit { get => _weightLimit; init => _weightCapacity = value;}
        public override List<int> FloorsServed { get => _floorsServed; init => _floorsServed = value; }

        public override string Speed { get => _speed; set => _speed = value; }
        public override int CurrentFloor { get => _currentFloor; set => _currentFloor = _elevator.CurrentFloor; }
        public override bool IsMoving { get => isMoving; set => isMoving = _elevator.IsMoving; }
        public override bool Operational { get => operational; set => operational = _elevator.IsOperational; }
    }
}