namespace Building.Commands.ElevatorControl
{
    public class ElevatorControlState
    {
        public void Stop()
        {
            Console.WriteLine("Elevator Stopped.");
        }
        public void OpenDoor()
        {
            Console.WriteLine("Elevator Door Opening...");
        }

        public void ClosedDoor()
        {
            Console.WriteLine("Elevator Door Closing...");
        }

        public void Up()
        {
            Console.WriteLine("Elevator Moving Up...");
        }

        public void Down()
        {
            Console.WriteLine("Elevator Moving Down...");
        }
    }
}