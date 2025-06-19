using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Entities.Agents;
using InvestigationGame.Entities.Pepoles;

namespace InvestigationGame.SystemOperation
{
    internal class GameManager
    {
        public void StartInvestigationGame()
        {
            //BaseAgent SoldierAgent = new BaseAgent();
            //SquadLeader LeaderAgent = new SquadLeader();
            //SeniorCommander CommandorAgent = new SeniorCommander();

            InvestigationGame game = new InvestigationGame();
            //game.Play(new BaseAgent());
            //game.Play(new SquadLeader());
            //game.Play(new SeniorCommander());
            game.Play(new OrganizationLeader());

        }

    }
}
