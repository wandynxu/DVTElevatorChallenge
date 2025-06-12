using Spectre.Console.Cli;

namespace Building.Commands.ElevatorControl
{
    public class DirectionCommand : Command<DirectionCommand.Settings>
    {
        public class Settings : CommandSettings
        {
            [CommandOption("-d|--direction <DIRECTION>")]
            public string Direction { get; set; } = string.Empty;

            [CommandOption("-e|--elevator <ELEVATOR>")]
            public string? ElevatorId { get; set; }
        }

        public override int Execute(CommandContext context, Settings settings)
        {
            throw new NotImplementedException();
        }
    }
}