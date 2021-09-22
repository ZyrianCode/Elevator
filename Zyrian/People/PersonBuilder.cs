using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Zyrian.People
{
    public class PersonBuilder
    {
        private readonly Person _person;

        public PersonBuilder()
        {
            _person = new();
        }

        /// <summary>
        /// Устанавливает имя человеку
        /// </summary>
        /// <param name="name"> имя </param>
        /// <returns></returns>
        public PersonBuilder SetName(string name)
        {
            _person.Name = name;
            return this;
        }

        /// <summary>
        /// Устанавливает вес
        /// </summary>
        /// <param name="weight"> вес </param>
        /// <returns></returns>
        public PersonBuilder SetWeight(int weight)
        {
            _person.Weight = weight;
            return this;
        }

        /// <summary>
        /// Устанавливает расположение
        /// </summary>
        /// <param name="coordinates"> координаты будущего расположения в лифте </param>
        /// <returns></returns>
        public PersonBuilder SetCoordinates(Coordinates coordinates)
        {
            _person.Coordinates = coordinates;
            return this;
        }

        public Person Build() => _person;
    }
}
