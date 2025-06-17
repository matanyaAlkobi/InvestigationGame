using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Entities.Pepoles;
using InvestigationGame.Entities.Sensors;

namespace InvestigationGame.Entities.Agents
{
    internal class SquadLeader : FootSoldier
    {
        public SquadLeader(string rank = "SquadLeader") : base (rank)
        {
            this.Rank = rank;
            SensorWeakSpot = ConnectingSensors.SensorGenerator(this);   // Adding sensors to the list
            SensorDamage = new Sensor[SensorWeakSpot.Count];
        }
    }
}
