using Building.Enums;
using Building.Models;

namespace Elevator.Classes.Concretes
{
    ///<summary>
    /// Heavy Goods.
    /// Can also be used by people.
    ///</summary>
    public sealed class Freight : Elevator
    {
        private readonly ElevatorType _elevator;
        private int _currentFloor = (int)Floors.Basement;
        private bool _authorizedPersonnel = true;
        
        public Freight(ElevatorType elevator, string id) : base(type: "Freight", id)
        {
            _elevator = elevator;
        }
        public override int NumberOfElevators { get => (int)Elevators.Freight; }
        public override double WeightCapacity { get => 120.5; }
        public override double WeightLimit { get => 141.74; }
        public override bool AuthorizedPersonnel { get => _authorizedPersonnel; }
        public override string Speed { get => speed; init => speed = _elevator.Speed ?? ElevatorSpeeds.Normal.ToString(); }
        public override int CurrentFloor { get => _currentFloor; set => _currentFloor = _elevator.CurrentFloor; }
        public override bool IsMoving { get => isMoving; set => isMoving = _elevator.IsMoving; }
        public override string Direction { get => direction; set => direction = _elevator.Direction ?? ElevatorDirection.Idle.ToString(); }
        public override bool Operational { get => operational; set => operational = _elevator.IsOperational; }
    }
}