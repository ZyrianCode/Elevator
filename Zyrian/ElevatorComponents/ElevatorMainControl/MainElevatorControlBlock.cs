using ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents;
using ElevatorSimulation.Zyrian.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Zyrian.ElevatorComponents.ElevatorMainControl
{
    public class MainElevatorControlBlock
    {
        private Circuit _circuit;
        private ElevatorEngine _engine = new();

        public MainElevatorControlBlock()
        {

        }

        public MainElevatorControlBlock(CommandPoolRetranslator commandPoolRetranslator)
        {
            _circuit = new(commandPoolRetranslator, _engine);
        }

        public void Start(CommandPoolRetranslator commandPoolRetranslator, Elevator elevator)
        {
            _engine.SetElevator(elevator);
            _circuit = new(commandPoolRetranslator, _engine);
            _circuit.Start();
        }
    }
}
