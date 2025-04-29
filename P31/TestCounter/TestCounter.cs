using NUnit.Framework.Legacy;
using CounterApp;

namespace CounterTests
{
    [TestFixture]
    public class CounterTest
    {
        private Counter _counter;

        [SetUp]
        public void Setup()
        {
            _counter = new Counter("TestCounter");
        }

        [Test]
        public void CounterStartsAtZero()
        {
#pragma warning disable NUnit2005 // Consider using Assert.That(actual, Is.EqualTo(expected)) instead of ClassicAssert.AreEqual(expected, actual)
            ClassicAssert.AreEqual(0, _counter.Ticks, "Counter should start at 0");
#pragma warning restore NUnit2005 // Consider using Assert.That(actual, Is.EqualTo(expected)) instead of ClassicAssert.AreEqual(expected, actual)
        }

        [Test]
        public void CounterIncrementsByOne()
        {
            _counter.Increment();
            Assert.That(_counter.Ticks, Is.EqualTo(1), "Counter should be 1 after one increment");
        }

        [Test]
        public void CounterIncrementsMultipleTimes()
        {
            for (int i = 0; i < 5; i++)
            {
                _counter.Increment();
            }
            Assert.That(_counter.Ticks, Is.EqualTo(5), "Counter should be 5 after five increments");
        }

        [Test]
        public void CounterResetsToZero()
        {
            _counter.Increment();
            _counter.Increment();
            _counter.Reset();
            Assert.That(_counter.Ticks, Is.EqualTo(0), "Counter should be 0 after reset");
        }
    }
}
