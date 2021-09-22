using ElevatorSimulation.Zyrian;
using System;
using System.Collections.Generic;
using ElevatorSimulation.Zyrian.People;
using ElevatorSimulation.Zyrian.SimulationComponents;

namespace ElevatorSimulation
{
    class Program
    {
        static void Main(string[] args)
        {

            //ElevatorSimulationApi api = new();
            //api.Start();
            Person person = new PersonBuilder().SetName("Андрей").SetWeight(60).Build();

            Simulation simulation = new SimulationBuilder().Initialize().CreatePerson(person)
                .SetFromWhichFloorWillCalling(0).SimulatePersonJoiningToHouse().SimulateElevatorCalling()
                .SimulateStartingElevatorMainBlock().Build();
            simulation.ToString();

        }
    }
}
