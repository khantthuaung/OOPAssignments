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
        }

    }
}