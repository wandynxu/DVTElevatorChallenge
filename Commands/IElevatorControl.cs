using Building.Classes;

namespace Building.Commands
{
    public interface IElevatorControl
    {
        void SetElevatorType(ElevatorType elevatorType);

        Task SimulateElevator(Models.Elevator requestElevator);
        
    }
}