namespace Building.Services
{
    /// <summary>
    /// Interface for elevator control service.
    /// </summary>
    public interface IElevatorControlService
    {
        /// <summary>
        /// Moves the elevator to the specified floor.
        /// </summary>
        /// <param name="floor">The floor to move the elevator to.</param>
        void MoveToFloor(int floor);
        
        /// <summary>
        /// Opens the elevator doors.
        /// </summary>
        void OpenDoor();
        
        /// <summary>
        /// Closes the elevator doors.
        /// </summary>
        void CloseDoor();
    }
}