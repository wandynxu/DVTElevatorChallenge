using Building.Classes;

namespace Building.Commands
{
    public interface IElevatorControl
    {
        Task SimulateElevator(ElevatorType elevatorType);
        void SetDirection(string direction);
        void SetStatus(string status);
        
    }
}