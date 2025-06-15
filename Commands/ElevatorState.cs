namespace Building.Commands
{
    public class ElevatorState
    {
        public void Stop()
        {
            Console.WriteLine("Elevator Stopped.");
        }
        public void OpenDoor()
        {
            Console.WriteLine("Elevator Door Opening...");
        }

        public void CloseDoor()
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