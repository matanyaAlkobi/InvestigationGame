using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGame.Entities.Agents
{
    /// <summary>
    /// Interface defining agent-specific behaviors during gameplay.
    /// Implementing classes provide their unique behavior logic.
    /// </summary>
    internal interface IAgentBehavior
    {
        void HandleBehavior();
    }
}
