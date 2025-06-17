using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Entities.Agents;
using InvestigationGame.Entities.Pepoles;
using InvestigationGame.Entities.Sensors;
using InvestigationGame.SetForGame;

namespace InvestigationGame.SystemOperation
{
    //A department responsible for the game's operating system
    internal class Game
    {
        // Starting the game
        public static void Start()
        {
            //List<Sensor> SensorsFactory = new List<Sensor> { new AudioSensor(), new ThermalSensor() };
            FootSoldier agent = new FootSoldier();
            SquadLeader LeaderAgent = new SquadLeader();
            Console.WriteLine("Welcome  Interrogator !!!");
            bool exposed;
            do
            {
                Console.WriteLine($"The agent has {agent.SensorWeakSpot.Count} sensors");
                int index =  GameInputManager.GetValidSensorIndexFromUser(agent);
                string SensorName = GameInputManager.GetValidSensorNameFromUser(agent);
                exposed = AgentExposureAnalyzer.TryExposeAgentWithSensor(SensorName, index, agent);
            }
            while (!exposed);
        }



    }
}
