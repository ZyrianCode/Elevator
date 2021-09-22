using ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents.CommandRetranslatorComponents.Commands;
using ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents.ControlPanelStrategy.Buttons;
using ElevatorSimulation.Zyrian.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Zyrian.Objects.HouseComponents
{
    public class Floor
    {
        private readonly string _numberOfFloor;
        private readonly List<Person> _people = new();

        private readonly Button _button;

        public Floor(string numberOfFloor)
        {
            _numberOfFloor = numberOfFloor;
            _button = new MoveButton(_numberOfFloor, new Move());
        }

        public string GetNumberOfFloor() => _numberOfFloor;
        public Button GetButton() => _button;
        public List<Person> GetPeople() => _people;

        public virtual void Join(Person person) => _people.Add(person);
        public virtual void Join(List<Person> people) => _people.AddRange(people);

        public virtual void Leave(List<Person> people) => _people.RemoveRange(0, people.Count());
        public virtual void Leave(Person person) => _people.Remove(person);

    }
}
