using Building.Enums;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Building.Commands.TUI
{
    public sealed class InteractiveElevatorControlSettings : CommandSettings
    {
        public ElevatorTypes ElevatorType { get; private set; }
        public ElevatorSpeeds ElevatorSpeed { get; private set; }

        public int CurrentFloor { get; private set; }
        public int TargetFloor { get; private set; }
        public int NumberOfPassengers { get; private set; }
        public double WeightOfGoods { get; private set; }
        public void PromptForElevatorType()
        {
            ElevatorType = AnsiConsole.Prompt(new SelectionPrompt<ElevatorTypes>()
                                                    .Title("Please Select Elevator Type:")
                                                    .MoreChoicesText("[grey](Move up and down)[/]")
                                                    .AddChoices(Enum.GetValues(typeof(ElevatorTypes)).Cast<ElevatorTypes>()));
            switch (ElevatorType)
            {
                case ElevatorTypes.Passenger:
                    AnsiConsole.MarkupLine($"You have selected a [green]{ElevatorType} Elevator.[/]");
                    break;
                case ElevatorTypes.Sidewalk:
                    AnsiConsole.MarkupLine($"You have selected a [blue]{ElevatorType} Elevator.[/]");
                    break;
                case ElevatorTypes.Service:
                    AnsiConsole.MarkupLine($"You have selected a [yellow]{ElevatorType} Elevator.[/]");
                    break;
                case ElevatorTypes.Emergency:
                    AnsiConsole.MarkupLine($"You have selected a [red]{ElevatorType} Elevator.[/]");
                    break;
                case ElevatorTypes.DumbWaiter:
                    AnsiConsole.MarkupLine($"You have selected a [brown]{ElevatorType} Elevator.[/]");
                    break;
                case ElevatorTypes.Freight:
                    AnsiConsole.MarkupLine($"You have selected a [yellow]{ElevatorType} Elevator.[/]");
                    break;
                default:
                    AnsiConsole.MarkupLine("[grey]No elevator type selected.[/]");
                    break;
            }
        }

        public void PromptForElevatorSpeed(string elevatorType)
        {

            ElevatorSpeed = AnsiConsole.Prompt(new SelectionPrompt<ElevatorSpeeds>()
                                                    .Title($"Please Select Elevator Speed -> {elevatorType}:")
                                                    .MoreChoicesText("[grey](Move up and down)[/]")
                                                    .AddChoices(Enum.GetValues(typeof(ElevatorSpeeds)).Cast<ElevatorSpeeds>()));

            AnsiConsole.MarkupLine($"[blue]{ElevatorSpeed}[/] Speed -> [green]{elevatorType}[/] Elevator.");
        }

        public void PromptForCurrentFloor()
        {
            CurrentFloor = AnsiConsole.Prompt(new TextPrompt<int>("Please Enter Current Floor:")
                .Validate(floor =>
                {
                    if (floor < 0)
                    {
                        return ValidationResult.Error("Floor number must be greater than / equal to  0.");
                    }
                    return ValidationResult.Success();
                }));
        }

        public void PromptForNumberOfPassengers()
        {
            NumberOfPassengers = AnsiConsole.Prompt(new TextPrompt<int>("Please Enter Number Of Passengers waiting on current floor:")
                .Validate(passengers =>
                {
                    if (passengers < 1)
                    {
                        return ValidationResult.Error("Number Of Passengers must be greater than 0.");
                    }
                    return ValidationResult.Success();
                }));

        }
        
        public void PromptForWeightOfGoods()
        {
            WeightOfGoods = AnsiConsole.Prompt(new TextPrompt<double>("Please Enter Weight Of Goods:")
                .Validate(goods =>
                {
                    if (goods < 1)
                    {
                        return ValidationResult.Error("Weight Of Goods must be greater than 0.");
                    }
                    return ValidationResult.Success();
                }));

        }
        public void PromptForTargetFloor()
        {
            TargetFloor = AnsiConsole.Prompt(new TextPrompt<int>("Please Enter Target Floor:")
                .Validate(floor =>
                {
                    if (floor < 0)
                    {
                        return ValidationResult.Error("Floor number must be greater than / equal to 0.");
                    }
                    return ValidationResult.Success();
                }));

        }


    }
}