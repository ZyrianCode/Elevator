using ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents.CommandRetranslatorComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents.ControlPanelStrategy.Behaviour.MoveElevator
{
    public class SendNoMove : IMovable
    {
        public FormattedCommand Move(string nameOfButton, Command command) => new CommandFormatter().FormateEmptyCommand();
    }
}
