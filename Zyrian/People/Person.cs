using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents.ControlPanelStrategy.Buttons;
using ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents;
using ElevatorSimulation.Zyrian.ElevatorComponents;
using ElevatorSimulation.Zyrian.Objects;

namespace ElevatorSimulation.Zyrian.People
{
    public class Person
    {
        private DecisionGenerator _decisionGenerator = new();
        public int Weight { get; set; }
        public string Name { get; set; }
        public Coordinates Coordinates { get; set; }

        public PersonBuilder CreateBuilder() => new();

        //Вынести этот метод в другое место и сделать список нажатий
        public CommandPool InteractWithElevatorControlPanel(ElevatorControlPanel panel) => panel.ApplyUserRequest(ClickButton(MakeDecision()));
        public Person LeaveFromElevator() => this;
        public Person JoinToElevator() => this;
        public CommandPool CallElevator(Button button, Elevator elevator) => 
            elevator.GetControlPanel().ApplyUserRequest(button);
        private string ClickButton(string nameOfButton) => nameOfButton;
        private string MakeDecision() => _decisionGenerator.GenerateDecision();
        public void SayAboutProblem() => Console.WriteLine("Я застряло, помомгите...");

    }
}
