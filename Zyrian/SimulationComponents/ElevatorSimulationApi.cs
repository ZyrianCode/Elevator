using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents;
using ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents.ControlPanelStrategy.Buttons;
using ElevatorSimulation.Zyrian.ElevatorComponents.ElevatorMainControl;
using ElevatorSimulation.Zyrian.Objects;
using ElevatorSimulation.Zyrian.Objects.HouseComponents;
using ElevatorSimulation.Zyrian.People;

namespace ElevatorSimulation.Zyrian.SimulationComponents
{
    public class ElevatorSimulationApi
    {
        private House _house;
        private List<Floor> _floors;
        private CommandPool _commandPool;
        private MainElevatorControlBlock _elevatorControlBlock;
        private Button _button;
        private Elevator _elevator;
        private Person _person;
        private List<Person> _people;

        private int _numberOfFloorCallingFrom;
        private List<int> _numbersOfFloorCallingFrom;


        /// <summary>
        /// Инициализирует базовые компоненты, необходимые для того, чтобы можно было начинать моделировать различные ситуации на основе API
        /// Необходимыми компонентами являются: Дом, пул команд, этажи дома, главный блок управления лифтом
        /// </summary>
        public void InitializeComponents()
        {
            _house = new House();
            //_person = new();
            _commandPool = new CommandPool();
            _elevatorControlBlock = _house.GetElevatorMainBlock();
            _floors = _house.GetFloors();

            #region debug
#if DEBUG        
            Console.WriteLine("Создался дом " + "\n"); 
            //Console.WriteLine($"Создался Человек {typeof(Person)} с весом {_person.Weight}" + "\n"); 
            Console.WriteLine("Получили главный блок управления" + "\n"); 
            Console.WriteLine("Получили этажи дома" + "\n"); 
#endif
            #endregion  
        }

        /// <summary>
        /// Принимает человека
        /// </summary>
        /// <param name="person"> человек </param>
        public void TakePerson(Person person) => _person = person;

        /// <summary>
        /// Принимает группу людей
        /// </summary>
        /// <param name="people"> список людей </param>
        public void TakePeople(List<Person> people) => _people = people;


        /// <summary>
        /// Устанавливает номер этажа с которого будет производиться вызов лифта
        /// </summary>
        /// <param name="numberOfFloorCallingFrom"> номер этажа </param>
        public void SetFromWhichFloorWillCalling(int numberOfFloorCallingFrom) => _numberOfFloorCallingFrom = numberOfFloorCallingFrom;

        /// <summary>
        /// Устанавливает номера этажей с которых последовательно будет производиться вызов лифта
        /// </summary>
        /// <param name="numbersOfFloorCallingFrom"> список этажей </param>
        public void SetFromWhichFloorWillCalling(List<int> numbersOfFloorCallingFrom) => _numbersOfFloorCallingFrom = numbersOfFloorCallingFrom;

        /// <summary>
        /// Симулирует вызов лифта на определённый этаж
        /// </summary>
        /// <param name="numberOfFloorCallingFrom"></param>
        /// <returns></returns>
        public void SimulateElevatorCalling()
        {
            for (int i = _numberOfFloorCallingFrom; i < _numberOfFloorCallingFrom + 1; i++)
            {
                _button = _floors[i].GetButton();
                Console.WriteLine("Кнопка вызова лифта с " + i + " этажа");

                _people = _floors[i].GetPeople();
                Console.Write($"Человек с {i}-го этажа ") ;

                for (int j = 0; j < 1; j++)
                {
                    _commandPool = _people[j].CallElevator(_button, _house.GetElevator());
                    Console.WriteLine("вызвал лифт. Запрос обработан. Пул команд успешно получен. \n");
                    #region debug
#if DEBUG
                    Console.WriteLine($"{_commandPool.UnLoadPool()} \n");

                    foreach (var command in _commandPool.UnLoadPool())
                    {
                        Console.WriteLine($"кнопка: {command.GetWhatButtonWasPressed()}, команда: {command.GetCommand()} \n");
                    }
#endif
                    #endregion
                }
            }
        }

        /// <summary>
        /// Симулирует заход человека в дом
        /// </summary>
        public void SimulatePersonJoiningToHouse()
        {
            _house.TakePerson(_person);
            Console.WriteLine($"{_person.Name} с весом {_person.Weight} зашёл в дом! \n");
        }

        /// <summary>
        /// Симулирует заход группы людей в дом
        /// </summary>
        public void SimulatePeopleJoiningToHouse(List<Person> people)
        {
            _house.TakePeople(people);
            foreach (var person in people)
            {
                Console.WriteLine($"{_person.Name} с весом {_person.Weight} зашёл в дом! \n");
            }

        }

        /// <summary>
        /// Симулирует заход человека в дом
        /// </summary>
        public void SimulatePersonLeavingHouse()
        {
            _house.RemovePerson(_person);
            Console.WriteLine("Добавили в дом Петю \n");
        }

        /// <summary>
        /// Симулирует заход группы людей в дом
        /// </summary>
        public void SimulatePeopleLeavingHouse(List<Person> people)
        {
            _house.RemovePeople(people);
            Console.WriteLine("Добавили в дом Петю \n");
        }

        /// <summary>
        /// Симулирует старт лифта запуском главного блока управления
        /// </summary>
        public void SimulateStartingElevatorMainBlock()
        {
            _elevator = _house.GetElevator();
            #region debug
#if DEBUG
            Console.WriteLine("Запускаем главный блок управления");
            Console.WriteLine("Ретранслятор начинает работу по передаче пула команд приёмнику \n");
#endif
            #endregion
            _elevatorControlBlock.Start(new CommandPoolRetranslator(_commandPool), _elevator); //Запускаем главный блок управления
   
            Console.WriteLine("Всё прошло успешно!");
        }

        /// <summary>
        /// Симулирует заход людей в лифт
        /// </summary>
        /// <param name="numberOfFloorCallingFrom"></param>
        public void SimulateJoiningToElevator(int numberOfFloorCallingFrom)
        {
            for (int i = numberOfFloorCallingFrom; i < numberOfFloorCallingFrom + 1; i++)
            {
                _floors[i].Leave(_people[i]);
                _elevator.Join(_people[i].JoinToElevator());
                _people.Remove(_people[i]);
            }
        }

        /// <summary>
        /// Симулирует выход из лифта
        /// </summary>
        public void SimulateLeavingElevator()
        {
            _people = _elevator.GetPassengers();
            for (int i = 0; i < 1; i++)
            {
                _floors[_elevator.GetCurrentFloor()].Join(_elevator.Leave(_people[i]));
                //Подумать над тем, какой конкретно человек будет выходить (что-то нужно сделать с индексом);
                //Возможно придётся создать реестр нажатий от всех пользователей в лифте и вытаскивать информацию из реестра
                //о том, кто и какую нажимал кнопку, тот и выходит на нужный этаж.
            }
        }

        /// <summary>
        /// Симулирует взаимодействие пользователя с панелью управления лифтом
        /// </summary>
        public void InteractWithPanel()
        {
            //Сюда создать массив тех, кто хочет нажать. Те, кто нажать не хочет, выходят с теми с кем совпал этаж.
            for (int i = 0; i < 1; i++)
            {
                _people = _elevator.GetPassengers();
                _people[i].InteractWithElevatorControlPanel(_elevator.GetControlPanel());
            }
        }
    }
}
