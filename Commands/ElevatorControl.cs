using System.Data.Common;
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
            
            requests.Add(new Dictionary<string, object>
            {
                {"id", _elevatorType.Id },
                {"name", requestElevator.Name},
                {"currentFloor", requestElevator.CurrentFloor},
                {"targetFloor", requestElevator.TargetFloor},
                {"numberOfPassengers", requestElevator.NumberOfPassengers},
                {"weightOfGoods", requestElevator.WeightOfGoods},
            });
            
            await ValidateRequest(requestElevator);

            Console.WriteLine(_elevatorType);
        }
          
        private async Task ValidateRequest(Models.Elevator requestElevator)
        {

            //var eligibleToRequest = requests.Where(x => _elevatorType.Id ) 
            //await Move(targetFloor);
        }

        private async Task Move(Models.Elevator requestElevator)
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
            _elevatorType.CurrentFloor = requestElevator.TargetFloor;

            _elevatorType.State = State.InMotion.ToString();
        }

        private void Stop()
        {

            _elevatorType.State = State.Stationary.ToString();
        }


    }
}