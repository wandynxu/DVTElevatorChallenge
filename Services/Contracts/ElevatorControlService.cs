namespace Building.Services.Contracts
{
    public sealed class ElevatorControlService<T> : IElevatorControlService<T>
    {
        private T _elevator;
        public ElevatorControlService(T elevator)
        {
            _elevator = elevator;
        }

        public async Task<T> OpenDoor()
        {
            throw new NotImplementedException();
        }
        public async Task<T> CloseDoor()
        {
            throw new NotImplementedException();
        }

        public T MoveToFloor(int floor)
        {
            throw new NotImplementedException();
        }

        public T IsMoving()
        {
            throw new NotImplementedException();
        }

        public T Direction()
        {
            throw new NotImplementedException();
        }
    }
}