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
            FootSoldier agent = new FootSoldier();
            SquadLeader LeaderAgent = new SquadLeader();
            Game game = new Game();
            game.Play(agent);
            game.Play(LeaderAgent);
        }
    }
}
