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
    public abstract class Button
    {
        protected IFeedback FeedBackBehaviour;
        protected IMovable MoveBehaviour;
        protected IInteractableWithDoors InteractWithDoorsBehaviour;
        public abstract string Name { get; set; }
        public abstract Command Command { get; set; }

        protected Button()
        {
            FeedBackBehaviour = new SendNoCall();
            MoveBehaviour = new SendNoMove();
            InteractWithDoorsBehaviour = new SendNoInteract();
        }

        public IInteractableWithDoors SetInteractWithDoorsBehaviour(IInteractableWithDoors newInteractWithDoorsBehaviour) =>
            InteractWithDoorsBehaviour = newInteractWithDoorsBehaviour;

        protected FormattedCommand CallToElevatorService(string nameOfButton) => FeedBackBehaviour.Call(Name, Command);
        protected FormattedCommand Move(string nameOfButton) => MoveBehaviour.Move(Name, Command);
        protected FormattedCommand InteractWithDoors(string nameOfButton) => InteractWithDoorsBehaviour.InteractWithDoors(Name, Command);
        public abstract FormattedCommand Apply();
    }

}
