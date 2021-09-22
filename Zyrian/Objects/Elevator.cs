using ElevatorSimulation.Zyrian.ElevatorComponents;
using ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents;
using ElevatorSimulation.Zyrian.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Zyrian.Objects
{
    public class Elevator
    {
        private readonly ElevatorControlPanel _controlPanel = new();
        private readonly Doors _doors = new();
        public DoorDrive doorDrive;
        private readonly List<Person> _people = new();

        public event EventHandler PassengerLeaved;

        private int _weightLimit = 450;
        private int _currentWeight = 0;
        private int _countOfFloors = 10;
        private int _currentFloor;

        public Elevator()
        {
            _doors.IsOpen = false;
            doorDrive = new(_doors);           
        }


        public void Join(Person person)
        {
            if (_currentWeight + person.Weight >= _weightLimit)
            {
                Console.WriteLine("Лифт забит!");
            }
            else
            {
                _people.Add(person);
                _currentWeight += person.Weight;
            }
        }

        public Person Leave(Person person)
        {
            _currentWeight -= person.Weight;
            _people.Remove(person);
            PassengerLeaved?.Invoke(this, new EventArgs());
            return person;
        }
        public void SetFloor(int newFloor) => _currentFloor = newFloor;
        public int GetCurrentWeight() => _currentWeight;
        public int GetCurrentFloor() => _currentFloor;
        public ElevatorControlPanel GetControlPanel() => _controlPanel;
        public List<Person> GetPassengers() => _people;
    }
}
