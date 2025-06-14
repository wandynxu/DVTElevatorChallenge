namespace Building.Commands.ElevatorControl
{
    public interface IElevatorControlCommand
    {
        void Stop();
        void OpenDoor();
        void ClosedDoor();
        void Up();
        void Down();
        void Execute();
    }
}