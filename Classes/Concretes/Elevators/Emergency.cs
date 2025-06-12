using Building.Enums;
using Building.Models;

namespace Elevator.Classes.Concretes
{
    ///<summary>
    /// Only Evacuation Purposes.
    ///</summary>
    public class Emergency : Elevator
    {
        private readonly ElevatorType _elevator;
        private int _currentFloor = (int)Floors.Ground;
        private bool _authorizedPersonnel = true;
        public Emergency(ElevatorType elevator, string id) : base(type: "Emergency", id)
        {
            _elevator = elevator;
        }

        public override int NumberOfElevators { get => (int)Elevators.Emergency; }
        public override double WeightCapacity { get => 79.5; }
        public override double WeightLimit { get => 5.4; }
        public override bool AuthorizedPersonnel { get => _authorizedPersonnel; }

        public override string Speed { get => speed; init => speed = _elevator.Speed ?? ElevatorSpeeds.Normal.ToString(); }
        public override int CurrentFloor { get => _currentFloor; set => _currentFloor = _elevator.CurrentFloor; }
        public override bool IsMoving { get => isMoving; set => isMoving = _elevator.IsMoving; }
        public override string Direction { get => direction; set => direction = _elevator.Direction ?? ElevatorDirection.Idle.ToString(); }
        public override bool Operational { get => operational; set => operational = _elevator.IsOperational; }
    }    
}