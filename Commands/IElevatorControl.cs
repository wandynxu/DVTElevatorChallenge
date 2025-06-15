using Building.Classes;

namespace Building.Commands
{
    public interface IElevatorControl
    {
        Task SimulateElevator(ElevatorType elevatorType);
        void SetDirection(ElevatorType elevatorType);
        void SetStatus(ElevatorType elevatorType);
        
    }
}