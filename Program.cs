using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Entities.Agents;
using InvestigationGame.Entities.Pepoles;
using InvestigationGame.Entities.Sensors;
using InvestigationGame.SystemOperation;

namespace InvestigationGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();
            gameManager.StartInvestigationGame();


        }
    }
}
