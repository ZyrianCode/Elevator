using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents.CommandRetranslatorComponents
{
    public class CommandBuilder
    {
        private Command _command;

        public CommandBuilder SetType(Command command)
        {
            _command = command;
            return this;
        }

        public CommandBuilder SetNumberFloor(string floor)
        {
            _command.SetNumberOfFloor(floor);
            return this;
        }

        public Command Build() => _command;
    }
}
