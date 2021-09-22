using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorSimulation.Zyrian.People;
using ElevatorSimulation.Zyrian.SimulationComponents;

namespace ElevatorSimulation.Zyrian
{
    public class SimulationBuilder
    {
        private readonly Simulation _simulation;
        private readonly ElevatorSimulationApi _elevatorSimulationApi;

        public SimulationBuilder()
        {
            _simulation = new();
            _elevatorSimulationApi = new();
        }

        /// <summary>
        /// Инициализирует параметры API
        /// </summary>
        /// <returns></returns>
        public SimulationBuilder Initialize()
        {
            _elevatorSimulationApi.InitializeComponents();
            return this;
        }

        /// <summary>
        /// Создаёт человека
        /// </summary>
        /// <param name="name"> Имя </param>
        /// <param name="weight"> Вес </param>
        /// <param name="coordinates"> Местоположение, которое будет в лифте </param>
        /// <returns></returns>
        public SimulationBuilder CreatePerson(string name, int weight, Coordinates coordinates)
        {
            Person person = new PersonBuilder().SetName(name).SetWeight(weight).SetCoordinates(coordinates).Build();
            _elevatorSimulationApi.TakePerson(person);
            return this;
        }

        /// <summary>
        ///  Добавляет в API созданного человека
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public SimulationBuilder CreatePerson(Person person)
        {
            _elevatorSimulationApi.TakePerson(person);
            return this;
        }

        /// <summary>
        ///  Добавляет в API группу людей
        /// </summary>
        /// <param name="people"> список людей </param>
        /// <returns></returns>
        public SimulationBuilder CreatePeople(List<Person> people)
        {
            _elevatorSimulationApi.TakePeople(people);
            return this;
        }

        /// <summary>
        ///  Сообщает API номер этажа, с которого будет происходить вызов лифта
        /// </summary>
        /// <param name="numberOfFloor"></param>
        /// <returns></returns>
        public SimulationBuilder SetFromWhichFloorWillCalling(int numberOfFloor)
        {
            _elevatorSimulationApi.SetFromWhichFloorWillCalling(numberOfFloor);
            return this;
        }

        /// <summary>
        ///  Сообщает API номера этажей, с которых будет последовательно производиться вызов лифта
        /// </summary>
        /// <param name="numbersOfFloor"> список номеров этажей </param>
        /// <returns></returns>
        public SimulationBuilder SetFromWhichFloorWillCalling(List<int> numbersOfFloor)
        {
            _elevatorSimulationApi.SetFromWhichFloorWillCalling(numbersOfFloor);
            return this;
        }

        /// <summary>
        /// Симулирует заход человека в лифт
        /// </summary>
        /// <returns></returns>
        public SimulationBuilder SimulatePersonJoiningToHouse()
        {
            _elevatorSimulationApi.SimulatePersonJoiningToHouse();
            return this;
        }

        /// <summary>
        /// Симулирует вызов лифта
        /// </summary>
        /// <returns></returns>
        public SimulationBuilder SimulateElevatorCalling()
        {
            _elevatorSimulationApi.SimulateElevatorCalling();
            return this;
        }

        /// <summary>
        /// Симулирует запуск главного блока управления лифтом
        /// </summary>
        /// <returns></returns>
        public SimulationBuilder SimulateStartingElevatorMainBlock()
        {
            _elevatorSimulationApi.SimulateStartingElevatorMainBlock();
            return this;
        }

        /// <summary>
        /// Собираем симуляцию
        /// </summary>
        /// <returns></returns>
        public Simulation Build()
        {
            return _simulation;
        }
    }
}
