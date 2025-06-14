namespace Building.Services
{
    /// <summary>
    /// Interface for elevator control service.
    /// </summary>
    public interface IElevatorControlService<T>
    {

        T MoveToFloor(int floor);

        Task<T> OpenDoor();

        Task<T> CloseDoor();

        T IsMoving();
        
        T Direction();

    }
}