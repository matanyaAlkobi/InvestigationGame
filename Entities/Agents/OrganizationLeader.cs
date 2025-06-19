using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Entities.Pepoles;
using InvestigationGame.Entities.Sensors;

namespace InvestigationGame.Entities.Agents
{
    internal class OrganizationLeader : BaseAgent ,  IAgentBehavior
    {
        int TurnCounter = 0;
        static Random rnd = new Random();
        public OrganizationLeader(string Rank = "OrganizationLeader"): base(Rank)
        {
            this.Rank = Rank;
            SensorWeakSpot = ConnectingSensors.SensorGenerator(this);   // Adding sensors to the list
            SensorDamage = new Sensor[SensorWeakSpot.Count];
        }

        /// <summary>
        /// Executes the specific behavior of the agent,
        /// in this case removing an attached sensor.
        /// </summary>
        public void HandleBehavior()
        {
            RemovesAAttachSensor();
            TrackTurnsAndResetSensors();
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


        /// <summary>
        /// Increments the turn counter. Every 20 turns, resets the agent's sensor weaknesses and damage list.
        /// </summary>
        private void TrackTurnsAndResetSensors()
        {
            if (TurnCounter % 20 == 0)
            {
                if (!HasActiveSensors()) return;
                SensorWeakSpot = ConnectingSensors.SensorGenerator(this);   // Adding sensors to the list
                SensorDamage = new Sensor[SensorWeakSpot.Count];
                DisplaySensorResetMessage();
                
            }

        }


        /// <summary>
        /// Displays a message indicating that all sensors were removed and weaknesses were reset.
        /// </summary>
        private void DisplaySensorResetMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("The agent removed all attached sensors and reset his list of weaknesses.");
            Console.ResetColor();
        }
    }
}
