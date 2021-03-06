using ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents.CommandRetranslatorComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents.ControlPanelStrategy.Behaviour.InteractWithDoors
{
    public class SendNoInteract : IInteractableWithDoors
    {
        public FormattedCommand InteractWithDoors(string nameOfButton, Command command) => new CommandFormatter().FormateEmptyCommand();
    }
}
