using Building.Commands.ElevatorControl.Settings;
using Building.Enums;
using Building.Models;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Building.Commands.ElevatorControl
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
                int currentFloor = 0;
                int targetFloor = 0;

                settings.PromptForElevatorType();
                if (settings.ElevatorType == Elevators.Passenger)
                {
                    settings.PromptForElevatorSpeed(settings.ElevatorType.ToString());
                    speed = settings.ElevatorSpeed.ToString();
                }

                if (settings.ElevatorType == Elevators.Passenger || settings.ElevatorType == Elevators.Emergency || settings.ElevatorType == Elevators.Service)
                {
                    settings.PromptForNumberOfPassengers();
                    numberOfPassengers = settings.NumberOfPassengers;
                }
                else if (settings.ElevatorType == Elevators.Dumbwaiter || settings.ElevatorType == Elevators.Freight || settings.ElevatorType == Elevators.Sidewalk)
                {
                    settings.PromptForWeightOfGoods();
                    weightOfGoods = settings.WeightOfGoods;
                }

                settings.PromptForCurrentFloor();
                currentFloor = settings.CurrentFloor;

                settings.PromptForTargetFloor();
                targetFloor = settings.TargetFloor;

                ElevatorType elevatorType = new ElevatorType
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = settings.ElevatorType.ToString(),
                    CurrentFloor = currentFloor,
                    TargetFloor = targetFloor,
                    Speed = speed,
                    NumberOfPassengers = numberOfPassengers,
                    WeightOfGoods = weightOfGoods

                };

                exitKey = Console.ReadKey(false).Key;
            //Exit Application    
            } while (exitKey != ConsoleKey.Q);



            return 0;
        }

    }
}