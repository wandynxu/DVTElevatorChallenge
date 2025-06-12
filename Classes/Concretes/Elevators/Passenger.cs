using Building.Enums;
using Building.Models;

namespace Elevator.Classes.Concretes
{
    ///<summary>
    /// Residential & Express.
    ///</summary>
    public class Passenger: Elevator
    {
        private readonly ElevatorType _elevator;
        private int _currentFloor = (int)Floors.Ground;
        private bool _authorizedPersonnel = false;
        
        public Passenger(ElevatorType elevator, string id) : base(type: "Passenger", id)
        {
            _elevator = elevator;
        }
        public override int NumberOfElevators { get => (int)Elevators.Passenger; }
        public override double WeightCapacity { get => 120.6; }
        public override double WeightLimit { get => 100.5; }
        public override bool AuthorizedPersonnel { get => _authorizedPersonnel; }
        public override string Speed { get => speed; init => speed = _elevator.Speed ?? ElevatorSpeeds.Normal.ToString(); }
        public override int CurrentFloor { get => _currentFloor; set => _currentFloor = _elevator.CurrentFloor; }
        public override bool IsMoving { get => isMoving; set => isMoving = _elevator.IsMoving; }
        public override string Direction { get => direction; set => direction = _elevator.Direction ?? ElevatorDirection.Idle.ToString(); }
        public override bool Operational { get => operational; set => operational = _elevator.IsOperational; }
    }
}