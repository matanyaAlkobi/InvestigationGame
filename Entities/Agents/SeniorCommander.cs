using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Entities.Pepoles;
using InvestigationGame.Entities.Sensors;

namespace InvestigationGame.Entities.Agents
{
    /// <summary>
    /// Represents a senior commander agent with ability to remove sensors every 3 turns.
    /// </summary>
    internal class SeniorCommander : BaseAgent,  IAgentBehavior
    {
        /// <summary>
        /// Counts the number of turns passed.
        /// </summary>
        int TurnCounter = 0;
        static Random rnd = new Random();


        /// <summary>
        /// Initializes a new instance of the <see cref="SeniorCommander"/> class,
        /// setting its rank and assigning initial sensor weaknesses and damage array.
        /// </summary>
        /// <param name="rank">The rank of the agent, default is "SeniorCommander".</param>
        public SeniorCommander(string rank = "SeniorCommander") : base(rank)
        {
            this.Rank = rank;
            SensorWeakSpot = ConnectingSensors.SensorGenerator(this);   // Adding sensors to the list
            SensorDamage = new Sensor[SensorWeakSpot.Count];
        }

        /// <summary>
        /// Executes the specific behavior of the agent,
        /// in this case removing an 2 attached sensor.
        /// </summary>
        public void HandleBehavior()
        {
            RemovesAAttachSensor();
        }
        /// <summary>
        /// Called each turn to potentially remove damaged sensors every 3 turns.
        /// </summary>
        public void RemovesAAttachSensor()
        {
            ++TurnCounter;
            if (TurnCounter % 3 == 0)
            {
                if (!HasActiveSensors()) return;
                int num = RemoveRandomSensor();
                PrintSensorRemovedMessage(num);
            }
        }


        /// <summary>
        /// Checks if there are any active (non-null) sensors remaining.
        /// </summary>
        /// <returns>True if active sensors exist; otherwise false.</returns>
        private bool HasActiveSensors()
        {
            if (!SensorDamage.Any(s => s != null))
            {
                Console.WriteLine("No active sensors to remove.");
                return false;
            }
            return true;
        }


        /// <summary>
        /// Removes up to two random active sensors by setting them to null.
        /// </summary>
        /// <returns>The number of sensors removed.</returns>
        private int RemoveRandomSensor()
        {
            int counter = 0;
            do
            {
                int random = rnd.Next(0, SensorDamage.Length);
                if (SensorDamage[random] != null)
                {
                    SensorDamage[random] = null;
                    ++counter;
                }
                if (!HasActiveSensors()) return counter;
            }
            while (counter < 2);
            return counter;
        }


        /// <summary>
        /// Prints a message indicating how many sensors were removed.
        /// </summary>
        /// <param name="num">The number of sensors removed.</param>
        private void PrintSensorRemovedMessage(int num)
        {
            for (int i = 0; i < num; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"The senior commander's agent responded and removed sensor.");
            }
            Console.ResetColor();

        }
    }
}
