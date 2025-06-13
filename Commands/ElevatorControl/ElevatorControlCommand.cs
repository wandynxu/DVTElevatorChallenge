using Building.Commands.ElevatorControl.Settings;
using Building.Enums;
using Building.Models;
using Building.Services;
using Building.Services.Contracts;
using Elevator.Classes.Concretes;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Building.Commands.ElevatorControl
{
    public sealed class ElevatorControlCommand : Command<ElevatorControlCommandSettings>
    {
        private readonly IElevatorControlService _elevatorControlService;
        public ElevatorControlCommand(IElevatorControlService elevatorControlService) => _elevatorControlService = elevatorControlService;
        
        public override int Execute(CommandContext context, ElevatorControlCommandSettings settings)
        {
            
            settings.PromptForElevatorType();
            Elevators elevator = settings.ElevatorType;

            ElevatorType elevatorType = new ElevatorType
            {
                Id = Guid.NewGuid().ToString()
            };

            if (elevator == Elevators.Passenger)
            {
                settings.PromptForElevatorSpeed(elevator.ToString());
                elevatorType.Speed = settings.ElevatorSpeed.ToString();
            }

            settings.PromptForCurrentFloor();
            elevatorType.CurrentFloor = settings.CurrentFloor;

            settings.PromptForTargetFloor();
            elevatorType.TargetFloor = settings.TargetFloor;

            dynamic elevatorObj = null!;
            switch (elevator)
            {
                case Elevators.Passenger:
                    elevatorObj = new Passenger(elevatorType, elevatorType.Id).GetType();
                    Console.WriteLine($"{elevatorObj}");
                    break;
                case Elevators.Sidewalk:
                    elevatorObj = new Sidewalk(elevatorType, elevatorType.Id);
                    break;
                case Elevators.Service:
                    elevatorObj = new Service(elevatorType, elevatorType.Id);
                    break;
                case Elevators.Emergency:
                    elevatorObj = new Emergency(elevatorType, elevatorType.Id);
                    break;
                case Elevators.Dumbwaiter:
                    elevatorObj = new DumbWaiter(elevatorType, elevatorType.Id);
                    break;
                case Elevators.Freight:
                    elevatorObj = new Freight(elevatorType, elevatorType.Id);
                    break;
            }
            
            //_elevatorControlService =  new ElevatorControlService

            return 0;
        }

    }
}