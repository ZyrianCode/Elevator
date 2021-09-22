using ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents.CommandRetranslatorComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents
{
    public class CommandPool
    {
        private List<FormattedCommand> _commands = new();
        public void LoadCommands(FormattedCommand formattedCommand) => _commands.Add(formattedCommand);
        public List<FormattedCommand> UnLoadPool() => _commands;
        public void SortCommands() => _commands.Sort();
    }
}
