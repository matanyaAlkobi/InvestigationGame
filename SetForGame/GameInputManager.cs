using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestigationGame.Entities.Pepoles;

namespace InvestigationGame.SetForGame
{
    internal class GameInputManager
    {

        // A method that will take an index and return it
        public static int GetValidSensorIndexFromUser(IranianAgent agent)
        {
            ;
            bool check = false;
            int index;
            do
            {
                Console.WriteLine($"Please choose index between 0 and {agent.SensorWeakSpot.Count}");
                string input = Console.ReadLine();

                if (int.TryParse(input, out index))
                {
                    if (!(index >= 0 && index < agent.SensorWeakSpot.Count))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error!! The number entered is incorrect.");
                        Console.ResetColor();
                    }
                    else
                    {
                        check = true;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid number.");
                    Console.ResetColor();
                }

            }
            while (!check || !(index >= 0 && index < agent.SensorWeakSpot.Count));
            return index;
        }


        /// <summary>
        /// A method that receives the sensor name from the user
        /// </summary>
        /// <param name="agent"></param>
        /// <returns> Sensor name </returns>
        public static string GetValidSensorNameFromUser(IranianAgent agent)
        {
            string sensorName = "";
            bool valid = false;
            do
            {
                Console.WriteLine("The agent has these sensors.");
                foreach (var item in agent.SensorWeakSpot)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("enter a sensor  name");
                sensorName = Console.ReadLine();
                if (ConnectingSensors.ExistingSensors.Contains(sensorName))
                {
                    valid = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error!! The sensor name entered is incorrect.");
                    Console.ResetColor();
                }

            }
            while (!ConnectingSensors.ExistingSensors.Contains(sensorName) || !valid);
            return sensorName;
        }
    }
}
