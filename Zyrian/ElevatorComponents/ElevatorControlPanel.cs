using ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents;
using ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents.CommandRetranslatorComponents;
using ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents.CommandRetranslatorComponents.Commands;
using ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents.ControlPanelStrategy.Behaviour.InteractWithDoors;
using ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents.ControlPanelStrategy.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Zyrian.ElevatorComponents
{
    public class ElevatorControlPanel
    {
        private CommandPool _commandPool = new();
        private CommandSender _commandSender;
        //private CommandPoolRetranslator _commandPoolRetranslator;
        //private MainElevatorControlBlock _mainElevatorControlBlock;

        private readonly List<Button> _buttons = new()
        {
            new MoveButton("1", new Move()),
            new MoveButton("2", new Move()),
            new MoveButton("3", new Move()),
            new MoveButton("4", new Move()),
            new MoveButton("5", new Move()),
            new MoveButton("6", new Move()),
            new MoveButton("7", new Move()),
            new MoveButton("8", new Move()),
            new MoveButton("9", new Move()),
            new MoveButton("10", new Move()),

            new InterractWithDoorsButton("OpenDoors", new SendOpenDoors(), new OpenDoors()),
            new InterractWithDoorsButton("CloseDoors", new SendCloseDoors(), new CloseDoors()),

            new ServiceButton("CallToElevatorManager", new CallToElevatorManager())
        };

        public CommandPool ApplyUserRequest(string nameOfButtonRequestedToPress)
        {
            foreach (var button in _buttons)
            {
                if (button.Name == nameOfButtonRequestedToPress)
                {
                    _commandSender = new(_commandPool);
                    _commandPool = _commandSender.SendCommands(button.Apply());
                }
            }
            return _commandPool;
        }
        public CommandPool ApplyUserRequest(Button button) => ApplyUserRequest(button.Name);
    }
}
