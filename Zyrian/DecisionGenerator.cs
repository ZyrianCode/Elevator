using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSimulation.Zyrian
{
    public class DecisionGenerator
    {
        private Random _random = new();
        public string GenerateDecision() => _random.Next(0, 10).ToString();
    }
}
