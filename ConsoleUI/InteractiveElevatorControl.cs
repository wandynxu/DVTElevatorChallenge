using Building.Classes.Concretes.Elevators;
using Building.Enums;
using Spectre.Console.Cli;
using Building.Classes;
using Building.Commands;
using Spectre.Console;
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
                else if (settings.ElevatorType is ElevatorTypes.Emergency)
                {
                    speed = ElevatorSpeed.Fast.ToString();
                }
                else if (settings.ElevatorType is ElevatorTypes.DumbWaiter)
                {
                    speed = ElevatorSpeed.Slow.ToString();
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
                {
                    elevatorType.CurrentFloor = elevator.CurrentFloor;
                    elevatorType.TargetFloor = elevator.TargetFloor;
                    elevatorType.Speed = elevator.Speed;
                    elevatorType.CurrentNumberOfPassengers = elevator.NumberOfPassengers;
                    elevatorType.CurrentWeightOfGoods = elevator.WeightOfGoods;
                    
                    await _elevatorControl.SimulateElevator(elevatorType);
                }

                AnsiConsole.MarkupLine($"Press Any [green]Enter[/] to continue/[red] [Q] [/] to exit application.");
                exitKey = Console.ReadKey(false).Key;
                //Exit Application    
            } while (exitKey != ConsoleKey.Q);

            return 0;
        }

    }
}