using NUnit.Framework.Legacy;
using SwinAdventure;
namespace UnitTest
{

    [TestFixture]
    public class InventoryTests
    {
        private Inventory inventory;
        private Item item1;
        private Item item2;

        [SetUp]
        public void Setup()
        {
            inventory = new Inventory();
            item1 = new Item(new string[] { "sword" }, "bronze sword", "A shiny bronze sword.");
            item2 = new Item(new string[] { "shield" }, "wooden shield", "A sturdy wooden shield.");
            inventory.Put(item1);
            inventory.Put(item2);
        }

        [Test]
        public void TestFindItem()
        {
            Assert.That(inventory.Fetch("sword"), Is.EqualTo(item1));
            Assert.That(inventory.Fetch("shield"), Is.EqualTo(item2));
        }

        [Test]
        public void TestNoItemFind()
        {
            ClassicAssert.IsNull(inventory.Fetch("axe"));
        }

        [Test]
        public void TestFetchItem()
        {
            var fetchedItem = inventory.Fetch("sword");
            Assert.That(fetchedItem, Is.EqualTo(item1));
            ClassicAssert.IsTrue(inventory.HasItem("sword"));
        }

        [Test]
        public void TestTakeItem()
        {
            var takenItem = inventory.Take("sword");
            Assert.That(takenItem, Is.EqualTo(item1));
            ClassicAssert.IsFalse(inventory.HasItem("sword"));
        }

        [Test]
        public void TestItemList()
        {
            string expected = "\tbronze sword (sword)\n\twooden shield (shield)";
            Assert.That(inventory.ItemList, Is.EqualTo(expected));
        }
    }
}
