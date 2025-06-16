using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Entities.Pepoles;
using InvestigationGame.Entities.Sensors;

namespace InvestigationGame
{
    // A class that gives agents random weaknesses
    internal static class ConnectingSensors
    {
        static Random rnd = new Random();
        //static List<Sensor> ExistingSensors = new List<Sensor>();
        public static string[] ExistingSensors = { "Audio", "Thermal" };

        public static List<string> SensorGenerator(IranianAgent agent)
        {
            int ListLength  = 0;
            List<string> SensorsList = new List<string>();
            if(agent.Rank == "Junior")
            {
                ListLength = 2;
            }
            for(int i  = 0;  i<ListLength;i++)
            {
                SensorsList.Add(ExistingSensors[rnd.Next(0, ExistingSensors.Count())]);
            }
            return SensorsList;
        }
    }
}

