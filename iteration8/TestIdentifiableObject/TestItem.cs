using NUnit.Framework.Legacy;
using SwinAdventure;
namespace UnitTest
{
    [TestFixture]
    public class ItemTests
    {
        [Test]
        public void TestItemIsIdentifiable()
        {
            var item = new Item(new string[] { "sword", "blade" }, "bronze sword", "A shiny bronze sword.");
            ClassicAssert.IsTrue(item.AreYou("sword"));
            ClassicAssert.IsTrue(item.AreYou("blade"));
            ClassicAssert.IsFalse(item.AreYou("axe"));
        }

        [Test]
        public void TestShortDescription()
        {
            var item = new Item(new string[] { "sword", "blade" }, "bronze sword", "A shiny bronze sword.");
            ClassicAssert.AreEqual("bronze sword (sword)", item.ShortDescription);
        }

        [Test]
        public void TestFullDescription()
        {
            var item = new Item(new string[] { "sword" }, "bronze sword", "A shiny bronze sword.");
            ClassicAssert.AreEqual("A shiny bronze sword.", item.FullDescription);
        }
    }
}