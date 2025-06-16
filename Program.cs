using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Entities.Pepoles;

namespace InvestigationGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> hh = new List<string>();
            IranianAgent ia = new IranianAgent("Junior");
            hh = ia.SensorGenerator();
            foreach(string item in hh)
            {
                Console.WriteLine(item);

            }
        }
    }
}
