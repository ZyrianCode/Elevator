using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents
{
    public class DoorDrive
    {
        private readonly Doors _doors;

        public DoorDrive(Doors doors)
        {
            _doors = doors;
        }

        public void InteractWithDoors()
        {
            if (!_doors.IsOpen)
            {
                _doors.Open();
            }
            else if (_doors.IsOpen)
            {
                _doors.Close();
            }
        }

        public void OpenDoor() {

            if (!_doors.IsOpen){
                _doors.Open();
            }
            
        }

        public void CloseDoor() {

            if (_doors.IsOpen){
                _doors.Close();
            }
        }

    }
}
