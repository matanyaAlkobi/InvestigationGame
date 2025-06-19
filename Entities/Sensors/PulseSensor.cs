using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Entities.Pepoles;

namespace InvestigationGame.Entities.Sensors
{

    /// <summary>
    /// Represents a pulse sensor that activates when triggered by an Iranian agent's weakness.
    /// The sensor "breaks" (simulated) after 3 successful activations.
    /// </summary>
    internal class PulseSensor : Sensor
    {
        private int ActivateCount = 0;

        /// <summary>
        /// Constructs a new PulseSensor with optional sensor type and name.
        /// </summary>
        /// <param name="SensorType">Type of the sensor. Defaults to "Pulse".</param>
        /// <param name="SensorName">Name of the sensor. Defaults to "Pulse".</param>
        public PulseSensor(string SensorType = "Pulse", string SensorName = "Pulse") : base(SensorType, SensorName)
        {

        }

        /// <summary>
        /// Activates the sensor at a specific index. Increases usage count only on a successful hit. 
        /// Sensor breaks after 3 successful activations.
        /// </summary>
        /// <param name="agent">The agent to scan.</param>
        /// <returns>True if the sensor hits at the target index; otherwise, false.</returns>
        public override bool Activate(FootSoldier agent, int index)
        {
            ++ActivateCount;
            if (ActivateCount >= 3)
            {
                RemoveBrokenSensors(agent, index);
                return false;
            }
            
            Console.WriteLine(($"Sensor {SensorName} is Active for the {ActivateCount} time"));
            if (agent.SensorWeakSpot[index] == SensorName)
            {
                Console.WriteLine(($"Because of the damage, the sensor's number of times decreased to {ActivateCount}."));
                return true;
            }
            return false;
        }
        public bool IsBroken => ActivateCount >= 3;


        /// <summary>
        /// Removes a broken sensor from the agent and displays a message.
        /// </summary>
        /// <param name="agent">The FootSoldier instance.</param>
        /// <param name="index">The index of the broken sensor.</param>
        private void RemoveBrokenSensors(FootSoldier agent, int index)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(("Sensor has broken after 3 activations."));
            Console.ResetColor();
            agent.SensorDamage[index] = null;
        }
    }
}
