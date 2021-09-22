using ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents;
using ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents.CommandRetranslatorComponents;
using ElevatorSimulation.Zyrian.ElevatorComponents.ControlPanelComponents.CommandRetranslatorComponents.Commands;
using ElevatorSimulation.Zyrian.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Zyrian.ElevatorComponents.ElevatorMainControl
{
    public class Circuit
    {
        private readonly CommandReciver _commandReciver;
        private CommandPool _cash;
        private string _nameOfButton;
        private Command _commandToExecute;

        private readonly ElevatorEngine _engine;

        private int _currentFloor;

        public Circuit(CommandPoolRetranslator commandPoolRetranslator, ElevatorEngine engine)
        {
            _commandReciver = new(commandPoolRetranslator);
            _engine = engine;
        }

        public void Start()
        {
            Console.WriteLine("Circuit: Схема начала работу, Получаем команды..."); 
            _commandReciver.ReciveCommands();
            #region debug

#if DEBUG
            _commandReciver.PrintDebugInfo();
#endif
            #endregion
            _cash = _commandReciver.GetPool();
            _cash.SortCommands();
            #region debug

#if DEBUG        
            if (_cash != null) { global::System.Console.WriteLine("Пул успешно кэширован." + "\n"); }
                else global::System.Console.WriteLine("Ошибка кэширования пула" + "\n");
#endif
#endregion
            ReadCash(_cash);
        }

        public void ReadCash(CommandPool cash)
        {
            foreach (var command in cash.UnLoadPool())
            {
                TryParseCommand(command);
            }
        }

        public void TryParseCommand(FormattedCommand formattedCommand)
        {
            _nameOfButton = formattedCommand.GetWhatButtonWasPressed();
            _commandToExecute = formattedCommand.GetCommand();
            ExecuteCommands(_nameOfButton, _commandToExecute);
        }

        public void ExecuteCommands(string nameOfButton, Command command)
        {

#if DEBUG
            Console.WriteLine($"Circuit: Выполняется команда {command} \n");
#endif
            int floorToReach = int.Parse(nameOfButton);
            _currentFloor = _engine.GetElevator().GetCurrentFloor();
            if (command is Move)
            {
                _engine.MoveTo(_currentFloor, floorToReach);
                ExecuteCommands(_currentFloor.ToString(), new OpenDoors());
            }
            if(command is OpenDoors or CloseDoors)
            {
                _engine.GetElevator().doorDrive.InteractWithDoors();
                //_engine.GetElevator().PassengerLeaved;
                //_engine.GetElevator().doorDrive.InteractWithDoors();
            }
            if (command is CallToElevatorManager)
            {
                MakeCall();
            }
        }

        public void MakeCall()
        {
            Random random = new();
            List<Person> people =  _engine.GetElevator().GetPassengers();
            people[random.Next(0, people.Count)].SayAboutProblem();
        }
    }
}
