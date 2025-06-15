using Building.Classes;

namespace Building.Commands
{
    public class ElevatorControl : IElevatorControl
    {
        private ElevatorState _elevatorState;
        public ElevatorControl(ElevatorState elevatorState)
        {
            _elevatorState = elevatorState;
        }

        public Task SimulateElevator(ElevatorType elevatorType)
        {

            Console.WriteLine($"Now Simulating {elevatorType.Type} Elevator");

            Console.WriteLine(elevatorType);
            return Task.CompletedTask;
        }
        
        
        public void SetDirection(ElevatorType elevatorType)
        {
            throw new NotImplementedException();
        }

        public void SetStatus(ElevatorType elevatorType)
        {
            throw new NotImplementedException();
        }
    }
}