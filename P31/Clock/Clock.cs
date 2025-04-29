using System.Security.Principal;
using CounterApp;
using SplashKitSDK;


namespace ClockApp
{
    public class Clock
    {
        private Counter _hour;
        private Counter _minute;
        private Counter _second;

        public Clock()
        {
            _hour = new Counter("Hour");
            _minute = new Counter("Minute");
            _second = new Counter("Second");
        }
        public void Tick()
        {
            IncrementSecond();
        }
        private void IncrementSecond()
        {
            _second.Increment();
            if (_second.Ticks == 60)
            {
                _second.Reset();
                IncrementMinute();
            }
        }
        private void IncrementMinute()
        {
            _minute.Increment();
            if (_minute.Ticks == 60)
            {
                _minute.Reset();
                IncrementHour();
            }
        }
        private void IncrementHour()
        {
            _hour.Increment();
            if (_hour.Ticks == 13)
            {
                _hour.Reset();
                _hour.Increment();
            }
        }

        public void Reset()
        {
            _hour.Reset();
            _minute.Reset();
            _second.Reset();
        }
        public string GetTime()
        {
            return $"{_hour.Ticks:D2}:{_minute.Ticks:D2}:{_second.Ticks:D2}";
        }
        //properties
        public string Hour
        {
         get
         {
                return _hour.Ticks.ToString("D2");
         }   
        }
        public string Minute
        {
            get
            {
                return _minute.Ticks.ToString("D2");
            }
        }
        public string Second
        {
            get
            {
                return _second.Ticks.ToString("D2");
            }
        }
    }
}