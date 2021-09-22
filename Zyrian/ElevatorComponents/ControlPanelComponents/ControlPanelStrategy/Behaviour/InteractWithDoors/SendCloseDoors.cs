using ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents.CommandRetranslatorComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents.ControlPanelStrategy.Behaviour.InteractWithDoors
{
    public class SendCloseDoors : IInteractableWithDoors
    {
        public FormattedCommand InteractWithDoors(string nameOfButton, Command command) => new CommandFormatter().FormateCommand(command, nameOfButton);
    }
}
