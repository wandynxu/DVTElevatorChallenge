using Spectre.Console.Cli;

namespace Building.Commands.ElevatorControl
{
    public class OperationCommand: AsyncCommand<OperationCommand.Settings>
    {
        public class Settings : CommandSettings
        {
            [CommandOption("-o|--operation <OPERATION>")]
            public string Operation { get; set; } = string.Empty;

            [CommandOption("-e|--elevator <ELEVATOR>")]
            public string? ElevatorId { get; set; }
        }

        public override Task<int> ExecuteAsync(CommandContext context, Settings settings)
        {
            // Implementation of the command logic goes here
            throw new NotImplementedException();
        }
    }
    
}