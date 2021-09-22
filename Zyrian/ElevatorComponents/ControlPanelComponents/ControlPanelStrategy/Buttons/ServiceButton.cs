using ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents.CommandRetranslatorComponents;
using ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents.ControlPanelStrategy.Behaviour.Feedback;
using ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents.ControlPanelStrategy.Behaviour.InteractWithDoors;
using ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents.ControlPanelStrategy.Behaviour.MoveElevator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents.ControlPanelStrategy.Buttons
{
    public class ServiceButton : Button
    {
        public ServiceButton(string name, Command command)
        {
            MoveBehaviour = new SendNoMove();
            FeedBackBehaviour = new SendCallToElevatorManagerCommand();
            InteractWithDoorsBehaviour = new SendNoInteract();
            Name = name;
            Command = command;
        }

        public override string Name { get; set; }
        public override Command Command { get; set; }

        public override FormattedCommand Apply() => CallToElevatorService(Name);
    }
}
