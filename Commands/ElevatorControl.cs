using Building.Classes;

namespace Building.Commands
{
    public class ElevatorControl: IElevatorControl
    {
        private ElevatorState _elevatorState;
        public ElevatorControl(ElevatorState elevatorState)
        {
            _elevatorState = elevatorState;
        }
        public Task SimulateElevator(ElevatorType elevatorType, Models.Elevator elevator)
        {
            
            // TODO: Implement elevator simulation logic here
            return Task.CompletedTask;
        }
    }
}