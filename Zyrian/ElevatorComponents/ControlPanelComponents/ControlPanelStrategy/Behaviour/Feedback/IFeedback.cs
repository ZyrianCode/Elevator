using ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents.CommandRetranslatorComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents.ControlPanelStrategy.Behaviour.Feedback
{
    public interface IFeedback
    {
        public FormattedCommand Call(string nameOfButton, Command command);
    }
}
