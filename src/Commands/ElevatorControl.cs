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

        public int SimulateElevator(Models.Elevator requestElevator)
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

            int outcome = ValidateRequest(requestElevator);

            Console.WriteLine(_elevatorType);
            return 0;
        }

        private int ValidateRequest(Models.Elevator requestElevator)
        {
            int elevatorPassengerLimit = _elevatorType.PassengerLimit;
            double elevatorWeightLimit = _elevatorType.WeightLimit;

            //Check Passenger/Weight Limit
            if (requestElevator.NumberOfPassengers > 0)
            {
                int currNumberOfPassengers = requests.Where(x => x.ContainsKey("id") && x["id"]?.ToString() == _elevatorType.Id).Sum(x => Convert.ToInt32(x["numberOfPassengers"]));
            }
            else if (requestElevator.WeightOfGoods > 0)
            {
                int currWeightOfGoods = requests.Where(x => x.ContainsKey("id") && x["id"]?.ToString() == _elevatorType.Id).Sum(x => Convert.ToInt32(x["weightOfGoods"]));
            }

            //await Move(targetFloor);

            return 0;
        }

        private void Move(Models.Elevator requestElevator)
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
            _elevatorType.CurrentNumberOfPassengers = requestElevator.NumberOfPassengers;

            _elevatorType.State = State.InMotion.ToString();
        }

        private void Stop()
        {

            _elevatorType.State = State.Stationary.ToString();
        }


    }
}