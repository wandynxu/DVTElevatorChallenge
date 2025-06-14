namespace Building.Commands.ElevatorControl
{
    public class ElevatorControl
    {
        private IElevatorControlCommand _command = null!;
        public void SetCommand(IElevatorControlCommand command)
        {
            _command = command;
        }
        public void PressButton()
        {
            _command.Execute();
        }
    }
}