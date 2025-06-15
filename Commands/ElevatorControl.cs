using Building.Classes;

namespace Building.Commands
{
    public class ElevatorControl : IElevatorControl
    {
        private List<Dictionary<string, int>> requests = new();
        private ElevatorState _elevatorState;
        public ElevatorControl(ElevatorState elevatorState)
        {
            _elevatorState = elevatorState;
        }

        public async Task SimulateElevator(ElevatorType elevatorType)
        {
            
            //Request Elevator
            Console.WriteLine($"Requesting Elevator -> {elevatorType.Type}: {elevatorType.Id}");
            Request(elevatorType);

            Console.WriteLine(elevatorType);
        }
        
        private void Request(ElevatorType elevatorType)
        {
            requests.Add(new Dictionary<string, int>
            { 
                //{"Type", type}
            });

            
            throw new NotImplementedException();
        }

        private void Move()
        {
            throw new NotImplementedException();
        }

        private void Stop()
        {
            throw new NotImplementedException();
        }

        private void SetDirection(string direction)
        {
            throw new NotImplementedException();
        }

        private void SetStatus(string status)
        {
            throw new NotImplementedException();
        }

        
    }
}