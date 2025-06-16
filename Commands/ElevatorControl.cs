using Building.Classes;
using Building.Enums.Elevator;

namespace Building.Commands
{
    public class ElevatorControl : IElevatorControl
    {
        private List<Dictionary<string, object>> requests = new();

        private ElevatorState _elevatorState;
        private ElevatorType _elevatorType;
        public ElevatorControl(ElevatorState elevatorState)
        {
            _elevatorState = elevatorState;
        }

        public void SetElevatorType(ElevatorType elevatorType)
        {
            _elevatorType = elevatorType;
        }

        public async Task SimulateElevator(Models.Elevator requestElevator)
        {

            //Request Elevator
            Console.WriteLine($"Requesting Elevator:{_elevatorType.Type} -> {_elevatorType.Id}");
            if (requestElevator.NumberOfPassengers > 0)
            {
                Console.WriteLine($"{requestElevator.NumberOfPassengers} Passengers waiting on Floor {requestElevator.CurrentFloor}");
            }
            else if (requestElevator.WeightOfGoods > 0)
            {
                Console.WriteLine($"{requestElevator.WeightOfGoods} kgs to be lifted on Floor {requestElevator.CurrentFloor}");
            }
            
            requests.Add(new Dictionary<string, object>
            {
                {"Id", _elevatorType.Id },
                {"Name", requestElevator.Name},
                {"CurrentFloor", requestElevator.CurrentFloor},
                {"TargetFloor", requestElevator.TargetFloor},
                {"NumberOfPassengers", requestElevator.NumberOfPassengers},
                {"WeightOfGoods", requestElevator.WeightOfGoods},
            });
            
            //var eligibleToRequest = requests
            await Request(requestElevator);

            Console.WriteLine(_elevatorType);
        }

        private async Task Request(Models.Elevator requestElevator)
        {

            if (requestElevator.CurrentFloor > _elevatorType.CurrentFloor)
            {
                _elevatorState.Up(requestElevator.CurrentFloor, requestElevator.TargetFloor);
                _elevatorType.Direction = Direction.Up.ToString();
            }
            else
            {
                _elevatorState.Down(requestElevator.CurrentFloor, requestElevator.TargetFloor);
                _elevatorType.Direction = Direction.Down.ToString();
            }
            _elevatorType.State = State.InMotion.ToString(); 
            //await Move(targetFloor);
        }

        private async Task Move(int floor)
        {
            _elevatorType.CurrentFloor = floor;
            //_elevatorType.State =
        }

        private void Stop()
        {

            _elevatorType.State = State.Stationary.ToString();
        }


    }
}