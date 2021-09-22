using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents.CommandRetranslatorComponents
{
    public class FormattedCommand
    {
        private readonly Command _command;
        private readonly string _nameOfButtonFrom;

        public FormattedCommand()
        {

        }

        public FormattedCommand(Command command, string nameOfButtonFrom)
        {
            _command = command;
            _nameOfButtonFrom = nameOfButtonFrom;
        }
        public string GetWhatButtonWasPressed() => _nameOfButtonFrom;
        public Command GetCommand() => _command;
    }
}
