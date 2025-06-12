using Building.Commands.ElevatorControl.Settings;
using Spectre.Console.Cli;

namespace Building.Commands.ElevatorControl
{
    public sealed class FloorCommand : Command<FloorCommandSettings>
    {
        
        public override int Execute(CommandContext context, FloorCommandSettings settings)
        {
            throw new NotImplementedException();
        }
    }
}