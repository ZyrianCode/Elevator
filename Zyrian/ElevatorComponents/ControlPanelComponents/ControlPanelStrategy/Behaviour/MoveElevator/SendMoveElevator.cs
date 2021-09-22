using ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents.CommandRetranslatorComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents.ControlPanelStrategy.Behaviour.MoveElevator
{
    public class SendMoveElevator : IMovable
    {
        public FormattedCommand Move(string name, Command command) =>
            new CommandFormatter().FormateCommand(command, name);
    }
}
