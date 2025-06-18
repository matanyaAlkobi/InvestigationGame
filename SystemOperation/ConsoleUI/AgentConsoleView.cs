using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Entities.Pepoles;

namespace InvestigationGame.SystemOperation.GUI
{
    internal static class AgentConsoleView
    {

        public static void ShowWelcomeMessage(FootSoldier agent)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Welcome to the level of {agent.Rank}");
            Console.ResetColor();
        }

        public static void DisplaySuccessMessage(FootSoldier agent)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Well done, you managed to break an {agent.Rank} Irain.");
            Console.WriteLine("You will advance in rank to a more difficult agent.");
            Console.ResetColor();
        }
    }
}
