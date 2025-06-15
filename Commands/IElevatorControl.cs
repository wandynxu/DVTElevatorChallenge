using Building.Classes;

namespace Building.Commands
{
    public interface IElevatorControl
    {
        Task SimulateElevator(ElevatorType elevatorType, Models.Elevator elevator);
    }
}