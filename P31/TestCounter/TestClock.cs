using NUnit.Framework.Legacy;
using ClockApp;

namespace ClockTests
{
    [TestFixture]
    public class ClockTest
    {
        private Clock _clock;

        [SetUp]
        public void Setup()
        {
            _clock = new Clock();
        }

        [Test]
        public void ClockStartsAtMidnight()
        {
            Assert.That(_clock.GetTime(), Is.EqualTo("00:00:00"));
        }

        [Test]
        public void ClockTicksOneSecond()
        {
            _clock.Tick();
            Assert.That(_clock.GetTime(), Is.EqualTo("00:00:01"));
        }

        [Test]
        public void ClockTicksSixtySeconds()
        {
            for (int i = 0; i < 60; i++)
            {
                _clock.Tick();
            }
            Assert.That(_clock.GetTime(), Is.EqualTo("00:01:00"));
        }

        [Test]
        public void ClockTicksOneHour()
        {
            for (int i = 0; i < 3600; i++) // 60 * 60 = 3600 seconds
            {
                _clock.Tick();
            }
            Assert.That(_clock.GetTime(), Is.EqualTo("01:00:00"));
        }
    }
}
