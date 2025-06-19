using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Entities.Pepoles;

namespace InvestigationGame.SystemOperation.GUI
{

    /// <summary>
    /// Provides console-based UI methods for displaying messages related to agents.
    /// </summary>
    internal static class AgentConsoleView
    {


        /// <summary>
        /// Displays a welcome message with the agent's rank in green.
        /// </summary>
        /// <param name="agent">The agent whose rank is shown.</param>
        public static void ShowWelcomeMessage(BaseAgent agent)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Welcome to the level of {agent.Rank}");
            Console.ResetColor();
        }


        /// <summary>
        /// Displays a success message and promotion notice in blue.
        /// </summary>
        /// <param name="agent">The agent whose rank is referenced.</param>
        public static void DisplaySuccessMessage(BaseAgent agent)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Well done, you managed to break an {agent.Rank} Irain.");
            Console.WriteLine("You will advance in rank to a more difficult agent.");
            Console.ResetColor();
        }
    }
}
