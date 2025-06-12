using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services;

namespace Building.Services.Contracts
{
    public class ElevatorControlService: IElevatorControlService
    {
        public ElevatorControlService()
        {
            
        }

        public void CloseDoor()
        {
            throw new NotImplementedException();
        }

        public void MoveToFloor(int floor)
        {
            throw new NotImplementedException();
        }

        public void OpenDoor()
        {
            throw new NotImplementedException();
        }
    }
}