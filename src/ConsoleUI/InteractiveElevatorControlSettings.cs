using Building.Enums;
using Building.Enums.Elevator;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Building.ConsoleUI
{
    public sealed class InteractiveElevatorControlSettings : CommandSettings
    {
        public Types ElevatorType { get; private set; }
        public Speed ElevatorSpeed { get; private set; }

        public int CurrentFloor { get; private set; }
        public int TargetFloor { get; private set; }
        public int NumberOfPassengers { get; private set; }
        public double WeightOfGoods { get; private set; }
        public void PromptForElevatorType()
        {
            ElevatorType = AnsiConsole.Prompt(new SelectionPrompt<Types>()
                                                    .Title("Please Request Elevator:")
                                                    .MoreChoicesText("[grey](Move up and down)[/]")
                                                    .AddChoices(Enum.GetValues(typeof(Types)).Cast<Types>()));
            
                                                    
            switch (ElevatorType)
            {
                case Types.Passenger:
                    AnsiConsole.MarkupLine($"You have selected a [green]{ElevatorType} Elevator.[/]");
                    break;
                case Types.Sidewalk:
                    AnsiConsole.MarkupLine($"You have selected a [blue]{ElevatorType} Elevator.[/]");
                    break;
                case Types.Service:
                    AnsiConsole.MarkupLine($"You have selected a [yellow]{ElevatorType} Elevator.[/]");
                    break;
                case Types.Emergency:
                    AnsiConsole.MarkupLine($"You have selected a [red]{ElevatorType} Elevator.[/]");
                    break;
                case Types.DumbWaiter:
                    AnsiConsole.MarkupLine($"You have selected a [grey]{ElevatorType} Elevator.[/]");
                    break;
                case Types.Freight:
                    AnsiConsole.MarkupLine($"You have selected a [yellow]{ElevatorType} Elevator.[/]");
                    break;
                default:
                    AnsiConsole.MarkupLine("[grey]No elevator type selected.[/]");
                    break;
            }
        }

        public void PromptForElevatorSpeed(string elevatorType)
        {

            ElevatorSpeed = AnsiConsole.Prompt(new SelectionPrompt<Speed>()
                                                    .Title($"Please Select Elevator Speed -> {elevatorType}:")
                                                    .MoreChoicesText("[grey](Move up and down)[/]")
                                                    .AddChoices(Enum.GetValues(typeof(Speed)).Cast<Speed>()));
            
            AnsiConsole.MarkupLine($"[blue]{ElevatorSpeed} Speed [/] -> [green]{elevatorType} Elevator[/].");
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

        public void PromptForNumberOfPassengers(int passengerLimit)
        {
            NumberOfPassengers = AnsiConsole.Prompt(new TextPrompt<int>("Please Enter Number Of Passengers Waiting On Current Floor:")
                .Validate(passengers =>
                {
                    if (passengers > passengerLimit)
                    {
                        return ValidationResult.Error($"Number Of Passengers must be less than {passengerLimit}.");
                    }
                    return ValidationResult.Success();
                }));

        }
        
        public void PromptForWeightOfGoods(double weightLimit)
        {
            WeightOfGoods = AnsiConsole.Prompt(new TextPrompt<double>("Please Enter Weight Of Goods:")
                .Validate(goods =>
                {
                    if (goods > weightLimit)
                    {
                        return ValidationResult.Error($"Weight Of Goods must be less than {weightLimit} Kgs.");
                    }
                    return ValidationResult.Success();
                }));

        }
        public void PromptForTargetFloor(int maxFloors)
        {
            TargetFloor = AnsiConsole.Prompt(new TextPrompt<int>("Please Enter Target Floor:")
                .Validate(floor =>
                {
                    if (floor > maxFloors)
                    {
                        return ValidationResult.Error($"Floor number must be less than {maxFloors}.");
                    }
                    return ValidationResult.Success();
                }));

        }


    }
}