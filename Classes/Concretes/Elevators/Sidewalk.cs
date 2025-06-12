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
        public Sidewalk(ElevatorType elevator, string id) : base(type: "Sidewalk", id)
        {
            _elevator = elevator;
        }
        public override int NumberOfElevators { get => (int)Elevators.Sidewalk; }
        public override double WeightCapacity { get => 59.5; }
        public override double WeightLimit { get => 85.4; }
        public override string Speed { get => speed; init => speed = _elevator.Speed ?? ElevatorSpeeds.Normal.ToString();}
        public override int CurrentFloor { get => _currentFloor; set => _currentFloor = _elevator.CurrentFloor; }
        public override bool IsMoving { get => isMoving; set => isMoving = _elevator.IsMoving; }
        public override string Direction { get => direction; set => direction = _elevator.Direction ?? string.Empty; }
        public override bool Operational { get => operational; set => operational = _elevator.IsOperational; }
    }
}