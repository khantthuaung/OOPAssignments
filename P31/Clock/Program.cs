using System;
using SplashKitSDK;

namespace ClockApp
{
    public class Program
    {
        public static void Main()
        {
            int secondTotal = 86400;
            Clock myClock = new Clock();
            for (int i = 0; i < 3600; i++) // 3600 seconds = 1 hour
            {
                myClock.Tick();
            }
            for (int i = 0; i < secondTotal; i++)
            {
                myClock.Tick();
                Console.WriteLine(myClock.GetTime());
                // Thread.Sleep(1000);
            }
            //Get the current process
            System.Diagnostics.Process proc =
            System.Diagnostics.Process.GetCurrentProcess();
            Console.WriteLine("Current process: {0}", proc.ToString());
            //Display the total physical memory size allocated for the current process
            Console.WriteLine("Physical memory usage: {0} bytes",
            proc.WorkingSet64);
            // Display peak memory statistics for the process.
            Console.WriteLine("Peak physical memory usage {0} bytes",
            proc.PeakWorkingSet64);
        }

    }
}