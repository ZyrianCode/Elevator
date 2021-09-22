using ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Zyrian.ElevatorComponents.ElevatorMainControl
{
    public class CommandReciver
    {
        private readonly CommandPoolRetranslator _commandRetranslator;
        private CommandPool _commands;

        public CommandReciver(CommandPoolRetranslator commandRetranslator)
        {
            _commandRetranslator = commandRetranslator;
        }
        public void ReciveCommands() => _commands = _commandRetranslator.RetranslateCommands();
        public CommandPool GetPool() => _commands;
        public void PrintDebugInfo() => Console.WriteLine("Command Reciver recived data from retranslator!");
    }
}
