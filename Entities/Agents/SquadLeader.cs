using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Entities.Pepoles;
using InvestigationGame.Entities.Sensors;

namespace InvestigationGame.Entities.Agents
{

    //  A class that handles a squadleader agent
    internal class SquadLeader : FootSoldier
    {
        int TurnCounter = 0;
        static Random rnd = new Random();


        /// <summary>
        /// Constructs a soldier with a default value
        /// </summary>
        /// <param name="rank">defult to SquadLeader</param>
        public SquadLeader(string rank = "SquadLeader") : base(rank)
        {
            this.Rank = rank;
            SensorWeakSpot = ConnectingSensors.SensorGenerator(this);   // Adding sensors to the list
            SensorDamage = new Sensor[SensorWeakSpot.Count];
        }



        /// <summary>
        /// Handles the logic for retaliatory sensor removal by the Iranian agent every 3 turns.
        /// If any sensors are active, one is randomly removed and a message is displayed.
        /// </summary>
        public void RemovesAAttachSensor()
        {
            ++TurnCounter;
            if (TurnCounter % 3 == 0)
            {
                if (!HasActiveSensors()) return;
                RemoveRandomSensor();
                PrintSensorRemovedMessage();
            }
        }

        /// <summary>
        /// Checks for any active sensors.
        /// </summary>
        /// <returns>True if a sensor should be removed; otherwise, false.</returns>
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
        /// Randomly selects and removes an active sensor from the agent.
        /// </summary>
        private void RemoveRandomSensor()
        {
            while (true)
            {
                int random = rnd.Next(0, SensorDamage.Length);
                if (SensorDamage[random] != null)
                {
                    SensorDamage[random] = null;
                    break;
                }
            }
        }

        /// <summary>
        /// Prints a message to the console indicating that a sensor was removed.
        /// </summary>
        private void PrintSensorRemovedMessage()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("The Iranian agent retaliated and removed a sensor.");
            Console.ResetColor();
        }

    }
}