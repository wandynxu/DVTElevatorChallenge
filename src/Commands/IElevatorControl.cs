using Building.Classes;

namespace Building.Commands
{
    public interface IElevatorControl
    {
        void SetElevatorType(ElevatorType elevatorType);

        int SimulateElevator(Models.Elevator requestElevator);
        
    }
}