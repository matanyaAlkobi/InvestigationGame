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
        private static int ActivateCount = 0;

        /// <summary>
        /// Constructs a new PulseSensor with optional sensor type and name.
        /// </summary>
        /// <param name="SensorType">Type of the sensor. Defaults to "Pulse".</param>
        /// <param name="SensorName">Name of the sensor. Defaults to "Pulse".</param>
        public PulseSensor(string SensorType = "Pulse", string SensorName = "Pulse") : base(SensorType, SensorName)
        {

        }

        /// <summary>
        /// Activates the sensor for a given agent. Breaks after 3 uses.
        /// </summary>
        /// <param name="agent">The Iranian agent to test against.</param>
        /// <returns>True if the sensor is broken, otherwise false.</returns>
        public override bool Activate(IranianAgent agent)
        {
            if (agent.SensorWeakSpot.Contains(SensorName))
            {
                ++ActivateCount;
                Console.WriteLine(($"Sensor {SensorName} is Active for the {ActivateCount} time"));
            }

            if (ActivateCount >= 3)
            {  
                Console.WriteLine( ("Sensor has broken after 3 activations."));
                return true;
            }
            return false;

        }
    }
}
