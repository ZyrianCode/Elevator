using ElevatorSimulation.Zyrian.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Zyrian.Objects.HouseComponents
{
    public class GroundFloor : Floor
    {
        private string _numberOfFloor;

        public GroundFloor(string numberOfFloor) : base(numberOfFloor)
        {
            _numberOfFloor = numberOfFloor;
        }

        public override void Join(Person person)
        {
            base.Join(person);
        }

        public override void Leave(Person person)
        {
            base.Leave(person);
        }
    }
}
