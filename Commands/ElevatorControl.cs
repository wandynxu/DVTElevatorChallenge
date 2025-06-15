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
            elevatorType.ToString();
            return Task.CompletedTask;
        }
        
        
        public void SetDirection(string direction)
        {
            throw new NotImplementedException();
        }

        public void SetStatus(string status)
        {
            throw new NotImplementedException();
        }
    }
}