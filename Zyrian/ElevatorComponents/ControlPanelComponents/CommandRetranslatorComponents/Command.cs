using ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents.CommandRetranslatorComponents.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents.CommandRetranslatorComponents
{
    public abstract class Command
    {
        private int _numberOfFloorWhereWasCall;
        public abstract void ExecuteInstructions();
        public void SetNumberOfFloor(string numberOfFloor) => _numberOfFloorWhereWasCall = int.Parse(numberOfFloor);
    }
}
