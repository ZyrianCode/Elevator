using ElevatorSimulation.Zyrian.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Zyrian.ElevatorComponents
{
    public class ElevatorEngine
    {
        private Elevator _elevator;

        public void SetElevator(Elevator elevator) => _elevator = elevator;
        public Elevator GetElevator() => _elevator;

        public void MoveTo(int startFloor, int floorToReach)
        {
            while (startFloor != floorToReach)
            {
                if (startFloor < floorToReach)
                {
                    startFloor++;
                    _elevator.SetFloor(startFloor);
                }
                if (startFloor > floorToReach)
                {
                    startFloor--;
                    _elevator.SetFloor(startFloor);
                }
                if (startFloor == floorToReach)
                {

                    Console.WriteLine("Приехали! Открываем двери!");
                }
            }
        }
        
    }

}
