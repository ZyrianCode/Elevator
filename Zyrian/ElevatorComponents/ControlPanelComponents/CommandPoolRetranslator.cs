using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents
{
    public class CommandPoolRetranslator
    {
        private readonly CommandPool _commandPool;

        public CommandPoolRetranslator(CommandPool commandPool)
        {
            _commandPool = commandPool;
        }
        public CommandPool RetranslateCommands() => _commandPool;
    }
}
