using System;

namespace ECS.TestForUsabillity
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing ECS.");

            Console.Write("Set threshold: ");

            int thr = Convert.ToInt32(Console.ReadLine());

            // Make an ECS with a threshold of 23
            var control = new ECS(thr, new TempSensor(), new Heater());

            for (int i = 1; i <= 15; i++)
            {
                Console.WriteLine($"Running regulation number {i}");

                control.Regulate(); 
            }
        }
    }
}
