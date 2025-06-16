using Building.Classes.Concretes.Elevators;
using Building.Enums.Elevator;
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

                    Types.Passenger => new Passenger(elevatorId),
                    Types.DumbWaiter => new DumbWaiter(elevatorId),
                    Types.Emergency => new Emergency(elevatorId),
                    Types.Freight => new Freight(elevatorId),
                    Types.Service => new Service(elevatorId),
                    Types.Sidewalk => new Sidewalk(elevatorId),
                    _ => null
                };

                if (elevatorType is not null)
                {
                    elevatorTypes.Add(elevatorType);
                    if (settings.ElevatorType is Types.Passenger)
                    {
                        settings.PromptForElevatorSpeed(settings.ElevatorType.ToString());
                        speed = settings.ElevatorSpeed.ToString();
                    }
                    else if (settings.ElevatorType is Types.Emergency)
                    {
                        speed = Speed.Fast.ToString();
                    }
                    else if (settings.ElevatorType is Types.DumbWaiter)
                    {
                        speed = Speed.Slow.ToString();
                    }

                    settings.PromptForCurrentFloor();

                    if (settings.ElevatorType is Types.Passenger or Types.Emergency or Types.Service)
                    {
                        settings.PromptForNumberOfPassengers(elevatorType.PassengerLimit);
                        numberOfPassengers = settings.NumberOfPassengers;
                    }
                    else if (settings.ElevatorType is Types.DumbWaiter or Types.Freight or Types.Sidewalk)
                    {
                        settings.PromptForWeightOfGoods(elevatorType.WeightLimit);
                        weightOfGoods = settings.WeightOfGoods;
                    }

                    settings.PromptForTargetFloor(maxFloors);

                    Models.Elevator requestElevator = new Models.Elevator
                    {
                        Name = settings.ElevatorType.ToString(),
                        CurrentFloor = settings.CurrentFloor,
                        TargetFloor = settings.TargetFloor,
                        Speed = speed,
                        NumberOfPassengers = numberOfPassengers,
                        WeightOfGoods = weightOfGoods
                    };
                    
                    _elevatorControl.SetElevatorType(elevatorType);
                    await Task.Run(() =>
                    {
                        _elevatorControl.SimulateElevator(requestElevator);
                    });
                    AnsiConsole.MarkupLine($"Press Any [green]Enter[/] to continue / [red] [[Q/q]] [/] to exit application.");
                }
                  
                exitKey = Console.ReadKey(false).Key;
                //Exit Application    
            } while (exitKey != ConsoleKey.Q);

            return 0;
        }

    }
}