using ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents;
using ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents.CommandRetranslatorComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents.CommandRetranslatorComponents
{
    public class CommandSender
    {
        private readonly CommandPool _commandPool;

        public CommandSender(CommandPool commandPool)
        {
            _commandPool = commandPool;
        }

        public CommandPool SendCommands(FormattedCommand formattedCommand)
        {
            _commandPool.LoadCommands(formattedCommand);
            return _commandPool;
        }
    }
}
