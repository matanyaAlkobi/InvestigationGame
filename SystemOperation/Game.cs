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
using InvestigationGame.SystemOperation.GUI;

namespace InvestigationGame.SystemOperation
{
    //A department responsible for the game's operating system
    internal class Game
    {
        static bool exposed;

        /// <summary>
        /// Starts the game with a basic FootSoldier agent and progresses upon success.
        /// </summary>
        //public  void Start()
        //{
        //    List<Sensor> SensorsFactory = new List<Sensor> { new AudioSensor(), new ThermalSensor() };
        //    FootSoldier agent = new FootSoldier();
        //    //SquadLeader LeaderAgent = new SquadLeader();

        //    Console.WriteLine("Welcome  Interrogator !!!");
        //    do
        //    {
        //        Console.WriteLine($"The agent has {agent.SensorWeakSpot.Count} sensors");
        //        int index =  GameInputManager.GetValidSensorIndexFromUser(agent);
        //        string SensorName = GameInputManager.GetValidSensorNameFromUser(agent);
        //        exposed = AgentExposureAnalyzer.TryExposeAgentWithSensor(SensorName, index, agent);
        //    }
        //    while (!exposed);
        //    Console.ForegroundColor = ConsoleColor.Blue;
        //    Console.WriteLine($"Well done, you managed to break an {agent.Rank} Irain.");
        //    Console.WriteLine("You will advance in rank to a more difficult agent.");
        //    Console.ResetColor();
        //    Level2(LeaderAgent);
        //}


        /// <summary>
        /// Plays a turn with the given agent and handles agent-specific behavior.
        /// </summary>
        /// <param name="agent">The agent to play with.</param>
        public void Play(FootSoldier agent)
        {
            AgentConsoleView.ShowWelcomeMessage(agent);
            do
            {
                Console.WriteLine($"The agent has {agent.SensorWeakSpot.Count} sensors");
                int index = GameInputManager.GetValidSensorIndexFromUser(agent);
                string SensorName = GameInputManager.GetValidSensorNameFromUser(agent);
                exposed = AgentExposureAnalyzer.TryExposeAgentWithSensor(SensorName, index, agent);
                HandleAgentBehavior(agent);
            }
            while (!exposed);
            AgentConsoleView.DisplaySuccessMessage(agent);
        }

        /// <summary>
        /// Handles behavior specific to the agent's role.
        /// </summary>
        /// <param name="agent">The agent to evaluate.</param>
        private void HandleAgentBehavior(FootSoldier agent)
        {
            if (agent is IAgentBehavior behaviorAgent)
            {
                behaviorAgent.HandleBehavior();
            }

        }



    }
}
