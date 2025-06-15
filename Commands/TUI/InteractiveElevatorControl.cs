using Building.Classes.Concretes.Elevators;
using Building.Enums;
using Spectre.Console.Cli;
using Building.Models;
using Building.Classes;
namespace Building.Commands.TUI
{
    public sealed class InteractiveElevatorControl : Command<InteractiveElevatorControlSettings>
    {
        public InteractiveElevatorControl()
        {

        }

        public override int Execute(CommandContext context, InteractiveElevatorControlSettings settings)
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

                settings.PromptForCurrentFloor();
                
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

                ElevatorType? obj = settings.ElevatorType switch
                {

                    ElevatorTypes.Passenger => new Passenger(elevator.Id),
                    ElevatorTypes.DumbWaiter => new DumbWaiter(elevator.Id),
                    ElevatorTypes.Emergency => new Emergency(elevator.Id),
                    ElevatorTypes.Freight => new Freight(elevator.Id),
                    ElevatorTypes.Service => new Service(elevator.Id),
                    ElevatorTypes.Sidewalk => new Sidewalk(elevator.Id),
                    _ => null
                };

                Console.WriteLine($"{obj?.Id}");
                exitKey = Console.ReadKey(false).Key;
            //Exit Application    
            } while (exitKey != ConsoleKey.Q);



            return 0;
        }

    }
}