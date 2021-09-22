using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents.CommandRetranslatorComponents
{
    public class CommandFormatter
    {
        public FormattedCommand FormateCommand(Command command, string nameOfButton) => new FormattedCommand(command, nameOfButton);
        public FormattedCommand FormateEmptyCommand() => new FormattedCommand();
    }
}
