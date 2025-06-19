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
    internal class InvestigationGame
    {
        static bool exposed;


        /// <summary>
        /// Plays a turn with the given agent and handles agent-specific behavior.
        /// </summary>
        /// <param name="agent">The agent to play with.</param>
        public void Play(BaseAgent agent)
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
        private void HandleAgentBehavior(BaseAgent agent)
        {
            if (agent is IAgentBehavior behaviorAgent)
            {
                behaviorAgent.HandleBehavior();
            }

        }



    }
}
