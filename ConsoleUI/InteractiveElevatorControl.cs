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
            int maxFloors = Building.maxFloors;
            int maxElevators = Building.maxElevators;
            List<ElevatorType> elevatorTypes = new();
            ConsoleKey exitKey;

            do
            {
                string speed = string.Empty;
                int numberOfPassengers = 0;
                double weightOfGoods = 0.0;

                settings.PromptForElevatorType();
                string elevatorId = Guid.NewGuid().ToString();
                ElevatorType? elevatorType = settings.ElevatorType switch
                {

                    ElevatorTypes.Passenger => new Passenger(elevatorId),
                    ElevatorTypes.DumbWaiter => new DumbWaiter(elevatorId),
                    ElevatorTypes.Emergency => new Emergency(elevatorId),
                    ElevatorTypes.Freight => new Freight(elevatorId),
                    ElevatorTypes.Service => new Service(elevatorId),
                    ElevatorTypes.Sidewalk => new Sidewalk(elevatorId),
                    _ => null
                };

                if (elevatorType is not null)
                {
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
                        settings.PromptForNumberOfPassengers(elevatorType.PassengerLimit);
                        numberOfPassengers = settings.NumberOfPassengers;
                    }
                    else if (settings.ElevatorType is ElevatorTypes.DumbWaiter or ElevatorTypes.Freight or ElevatorTypes.Sidewalk)
                    {
                        settings.PromptForWeightOfGoods(elevatorType.WeightLimit);
                        weightOfGoods = settings.WeightOfGoods;
                    }

                    settings.PromptForTargetFloor(maxFloors);

                    Models.Elevator elevator = new Models.Elevator
                    {
                        Name = settings.ElevatorType.ToString(),
                        CurrentFloor = settings.CurrentFloor,
                        TargetFloor = settings.TargetFloor,
                        Speed = speed,
                        NumberOfPassengers = numberOfPassengers,
                        WeightOfGoods = weightOfGoods
                    };


                    elevatorType.CurrentFloor = elevator.CurrentFloor;
                    elevatorType.TargetFloor = elevator.TargetFloor;
                    elevatorType.Speed = elevator.Speed;
                    elevatorType.CurrentNumberOfPassengers = elevator.NumberOfPassengers;
                    elevatorType.CurrentWeightOfGoods = elevator.WeightOfGoods;

                    elevatorTypes.Add(elevatorType);
                    if (elevatorTypes.Count() != maxElevators)
                    {
                        await _elevatorControl.SimulateElevator(elevatorType);
                    }
                    else
                    {

                    }

                }

                AnsiConsole.MarkupLine($"Press Any [green]Enter[/] to continue / [red] [[Q/q]] [/] to exit application.");
                exitKey = Console.ReadKey(false).Key;
                //Exit Application    
            } while (exitKey != ConsoleKey.Q);

            return 0;
        }

    }
}