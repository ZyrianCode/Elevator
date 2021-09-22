using ElevatorSimulation.Zyrian.ElevatorComponents.ElevatorMainControl;
using ElevatorSimulation.Zyrian.Objects.HouseComponents;
using ElevatorSimulation.Zyrian.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Zyrian.Objects
{
    public class House
    {
        private readonly Elevator _elevator = new();
        private readonly MainElevatorControlBlock _mainElevatorControlBlock = new();

        private readonly List<Floor> _floors = new()
        {
            new GroundFloor("1"),
            new Floor("2"),
            new Floor("3"),
            new Floor("5"),
            new Floor("6"),
            new Floor("7"),
            new Floor("8"),
            new Floor("9"),
            new Floor("10"),
        };

        public List<Floor> GetFloors() => _floors;

        public void TakePerson(Person person) => _floors[0].Join(person);
        public void TakePeople(List<Person> people) => _floors[0].Join(people);

        public void RemovePerson(Person person) => _floors[0].Leave(person);
        public void RemovePeople(List<Person> people) => _floors[0].Leave(people);

        public void SetMainBlockElevator() { }
        public Elevator GetElevator() => _elevator;
        public MainElevatorControlBlock GetElevatorMainBlock() => _mainElevatorControlBlock;
    }
}
