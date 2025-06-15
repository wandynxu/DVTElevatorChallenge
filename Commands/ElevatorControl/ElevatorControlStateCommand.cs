namespace Building.Commands.ElevatorControl
{
    public class ElevatorControlStateCommand : IElevatorControlCommand
    {
        private ElevatorControlState _elevatorControlState;
        public ElevatorControlStateCommand(ElevatorControlState elevatorControlState)
        {
            _elevatorControlState = elevatorControlState;
        }

        public void ClosedDoor()
        {
            _elevatorControlState.ClosedDoor();
        }

        public void Down()
        {
            _elevatorControlState.Down();
        }

        public void OpenDoor()
        {
            _elevatorControlState.OpenDoor();
        }

        public void Stop()
        {
            _elevatorControlState.Stop();
        }

        public void Up()
        {
            _elevatorControlState.Up();
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}