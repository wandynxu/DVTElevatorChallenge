using Building.Commands.ElevatorControl.Settings;
using Building.Enums;
using Building.Models;
using Elevator.Classes.Concretes;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Building.Commands.ElevatorControl
{
    public sealed class ElevatorTypesCommand : Command<ElevatorTypesCommandSettings>
    {

        public override int Execute(CommandContext context, ElevatorTypesCommandSettings settings)
        {
            var elevatorType = AnsiConsole.Prompt(new SelectionPrompt<Elevators>()
                                        .Title("Please select an elevator type:")
                                        .MoreChoicesText("[grey](Move up and down)[/]")
                                        .AddChoices(Enum.GetValues(typeof(Elevators)).Cast<Elevators>()));

            dynamic elevatorObjType = null!;
            switch (elevatorType)
            {
                case Elevators.Passenger:
                    AnsiConsole.MarkupLine($"You have selected a [green]{elevatorType} Elevator.[/]");
                    ElevatorType elevator = new ElevatorType
                    {
                        Id = Guid.NewGuid().ToString(),
                        CurrentFloor = 0,
                        TargetFloor = 0,
                        IsMoving = false,
                        IsOperational = true,
                        Direction = "Idle"
                    };
                    elevatorObjType = new Passenger(elevator, elevator.Id);
                    break;
                case Elevators.Sidewalk:
                    AnsiConsole.MarkupLine($"You have selected a [blue]{elevatorType} Elevator.[/]");
                    elevator = new ElevatorType
                    {
                        Id = Guid.NewGuid().ToString(),
                        CurrentFloor = 0,
                        TargetFloor = 0,
                        IsMoving = false,
                        IsOperational = true,
                        Direction = "Idle",
                    };
                    elevatorObjType = new Sidewalk(elevator, elevator.Id);
                    break;
                case Elevators.Service:
                    AnsiConsole.MarkupLine($"You have selected a [yellow]{elevatorType} Elevator.[/]");
                    elevator = new ElevatorType
                    {
                        Id = Guid.NewGuid().ToString(),
                        CurrentFloor = 0,
                        TargetFloor = 0,
                        IsMoving = false,
                        IsOperational = true,
                        Direction = "Idle",
                    };
                    elevatorObjType = new Service(elevator, elevator.Id);
                    break;
                case Elevators.Emergency:
                    AnsiConsole.MarkupLine($"You have selected a [red]{elevatorType} Elevator.[/]");

                    elevator = new ElevatorType
                    {
                        Id = Guid.NewGuid().ToString(),
                        CurrentFloor = 0,
                        TargetFloor = 0,
                        IsMoving = false,
                        IsOperational = true,
                        Direction = "Idle",
                    };
                    elevatorObjType = new Emergency(elevator, elevator.Id);
                    break;
                case Elevators.Dumbwaiter:
                    AnsiConsole.MarkupLine($"You have selected a [brown]{elevatorType} Elevator.[/]");
                    elevator = new ElevatorType
                    {
                        Id = Guid.NewGuid().ToString(),
                        CurrentFloor = 0,
                        TargetFloor = 0,
                        IsMoving = false,
                        IsOperational = true,
                        Direction = "Idle",
                    };
                    elevatorObjType = new DumbWaiter(elevator, elevator.Id);
                    break;
                case Elevators.Freight:
                    AnsiConsole.MarkupLine($"You have selected a [yellow]{elevatorType} Elevator.[/]");
                    elevator = new ElevatorType
                    {
                        Id = Guid.NewGuid().ToString(),
                        CurrentFloor = 0,
                        TargetFloor = 0,
                        IsMoving = false,
                        IsOperational = true,
                    };
                    elevatorObjType = new Freight(elevator, elevator.Id);
                    break;
                default:
                    AnsiConsole.MarkupLine("[grey]No elevator type selected.[/]");
                    break;
            }
            return 0;
        }

    }
}