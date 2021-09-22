using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Zyrian.ElevatorComponents
{
    public class Doors
    {
        public bool IsOpen { get; set; }

        public void Open() {
            IsOpen = true;
            Console.WriteLine("Двери открылись!"); 
        }
        public void Close() {
            IsOpen = false;
            Console.WriteLine("Двери закрылись!");
        }
    }
}
