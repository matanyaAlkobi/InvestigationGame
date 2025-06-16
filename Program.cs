using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Entities.Pepoles;
using InvestigationGame.SystemOperation;

namespace InvestigationGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game.Start();


            List<string> hh = new List<string>();
            IranianAgent ia = new IranianAgent("Junior");
            foreach(string item in hh)
            {
                Console.WriteLine(item);

            }
        }
    }
}
