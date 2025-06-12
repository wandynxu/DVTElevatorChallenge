using System.Reflection.Metadata;
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
        private readonly ElevatorType _elevator;
        private int _currentFloor = (int)Floors.Restaurant;
        private bool _authorizedPersonnel = true;
        public DumbWaiter(ElevatorType elevator, string id) : base(type: "DumbWaiter", id)
        {
            _elevator = elevator;
        }

        public override int NumberOfElevators { get => (int)Elevators.Dumbwaiter; }
        public override double WeightCapacity { get => 54.0; }
        public override double WeightLimit { get => 50.0; }
        public override bool AuthorizedPersonnel { get => _authorizedPersonnel; }

        public override string Speed { get => speed; init => speed = _elevator.Speed ?? ElevatorSpeeds.Normal.ToString(); }
        public override int CurrentFloor { get => _currentFloor; set => _currentFloor = _elevator.CurrentFloor; }
        public override bool IsMoving { get => isMoving; set => isMoving = _elevator.IsMoving; }
        public override string Direction { get => direction; set => direction = _elevator.Direction ?? ElevatorDirection.Idle.ToString(); }
        public override bool Operational { get => operational; set => operational = _elevator.IsOperational; }

    }
}