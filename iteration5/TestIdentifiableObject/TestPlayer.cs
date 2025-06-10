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
            player = new Player("Hero", "a brave warrior");
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
            ClassicAssert.AreEqual(sword, player.Locate("sword"));
            ClassicAssert.AreEqual(shield, player.Locate("shield"));
        }

        [Test]
        public void TestPlayerLocatesItself()
        {
            ClassicAssert.AreEqual(player, player.Locate("me"));
            ClassicAssert.AreEqual(player, player.Locate("inventory"));
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
            ClassicAssert.AreEqual(expected, player.FullDescription);
        }
    }
}
