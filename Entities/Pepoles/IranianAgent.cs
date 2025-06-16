using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGame.Entities.Pepoles
{
    internal class IranianAgent
    {
        public string Rank { get; set; }

        public string[] SensorWeakSpot { get; set; }

        public IranianAgent(string Rank) 
        {
            this.Rank = Rank;
        }

    }
}
