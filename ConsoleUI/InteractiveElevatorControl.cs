using Building.Classes.Concretes.Elevators;
using Building.Enums;
using Spectre.Console.Cli;
using Building.Classes;
using Building.Commands;
namespace Building.ConsoleUI
{
    public sealed class InteractiveElevatorControl : AsyncCommand<InteractiveElevatorControlSettings>
    {
        private readonly IElevatorControl _elevatorControl;
        public InteractiveElevatorControl(IElevatorControl elevatorControl)
        {
            _elevatorControl = elevatorControl;
        }

        public override async Task<int> ExecuteAsync(CommandContext context, InteractiveElevatorControlSettings settings)
        {
            ConsoleKey exitKey;
            do
            {
                string speed = string.Empty;
                int numberOfPassengers = 0;
                double weightOfGoods = 0.0;

                settings.PromptForElevatorType();
                if (settings.ElevatorType is ElevatorTypes.Passenger)
                {
                    settings.PromptForElevatorSpeed(settings.ElevatorType.ToString());
                    speed = settings.ElevatorSpeed.ToString();
                }

                settings.PromptForCurrentFloor();

                if (settings.ElevatorType is ElevatorTypes.Passenger or ElevatorTypes.Emergency or ElevatorTypes.Service)
                {
                    settings.PromptForNumberOfPassengers();
                    numberOfPassengers = settings.NumberOfPassengers;
                }
                else if (settings.ElevatorType is ElevatorTypes.DumbWaiter or ElevatorTypes.Freight or ElevatorTypes.Sidewalk)
                {
                    settings.PromptForWeightOfGoods();
                    weightOfGoods = settings.WeightOfGoods;
                }

                settings.PromptForTargetFloor();

                Models.Elevator elevator = new Models.Elevator
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = settings.ElevatorType.ToString(),
                    CurrentFloor = settings.CurrentFloor,
                    TargetFloor = settings.TargetFloor,
                    Speed = speed,
                    NumberOfPassengers = numberOfPassengers,
                    WeightOfGoods = weightOfGoods

                };

                ElevatorType? elevatorType = settings.ElevatorType switch
                {

                    ElevatorTypes.Passenger => new Passenger(elevator.Id),
                    ElevatorTypes.DumbWaiter => new DumbWaiter(elevator.Id),
                    ElevatorTypes.Emergency => new Emergency(elevator.Id),
                    ElevatorTypes.Freight => new Freight(elevator.Id),
                    ElevatorTypes.Service => new Service(elevator.Id),
                    ElevatorTypes.Sidewalk => new Sidewalk(elevator.Id),
                    _ => null
                };
                
                if (elevatorType is not null)
                    await _elevatorControl.SimulateElevator(elevatorType, elevator);
                 
                exitKey = Console.ReadKey(false).Key;
                //Exit Application    
            } while (exitKey != ConsoleKey.Q);



            return 0;
        }

    }
}