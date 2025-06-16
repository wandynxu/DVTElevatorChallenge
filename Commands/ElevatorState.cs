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

        public void Up(int floor, int targetFloor)
        {
            Console.WriteLine($"Elevator Moving Up From Floor {floor} To Floor {targetFloor}...");
        }

        public void Down(int floor, int targetFloor)
        {
            Console.WriteLine($"Elevator Moving Down From Floor {floor} To Floor {targetFloor}...");
        }
    }
}