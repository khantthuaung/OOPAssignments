using NUnit.Framework.Legacy;
using SwinAdventure;

namespace UnitTest
{


    [TestFixture]
    public class PlayerTests
    {
        private Player player;
        private Item sword;
        private Item shield;

        [SetUp]
        public void Setup()
        {
            Location room = new Location(new string[] {"room"},"room", "spawn room");
            player = new Player("Hero", "a brave warrior",room);
            sword = new Item(new string[] { "sword" , "bronze sword"},"a bronze sword" ,"A shiny bronze sword.");
            shield = new Item(new string[] { "shield" , "wooden shield"},"a wooden shield", "A sturdy wooden shield.");
            player.Inventory.Put(sword);
            player.Inventory.Put(shield);
        }

        [Test]
        public void TestPlayerIsIdentifiable()
        {
            ClassicAssert.IsTrue(player.AreYou("me"));
            ClassicAssert.IsTrue(player.AreYou("inventory"));
            ClassicAssert.IsFalse(player.AreYou("you"));
        }

        [Test]
        public void TestPlayerLocatesItems()
        {
            Assert.That(player.Locate("sword"), Is.EqualTo(sword));
            Assert.That(player.Locate("shield"), Is.EqualTo(shield));
        }

        [Test]
        public void TestPlayerLocatesItself()
        {
            Assert.That(player.Locate("me"), Is.EqualTo(player));
            Assert.That(player.Locate("inventory"), Is.EqualTo(player));
        }

        [Test]
        public void TestPlayerLocatesNothing()
        {
            ClassicAssert.IsNull(player.Locate("axe"));
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            string expected = "You are Hero, a brave warrior.\nYou are carrying:\n" +
                          "\ta bronze sword (sword)\n" +
                          "\ta wooden shield (shield)";
            Assert.That(player.FullDescription, Is.EqualTo(expected));
        }
    }
}
