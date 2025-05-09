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
            ClassicAssert.AreEqual(item1, inventory.Fetch("sword"));
            ClassicAssert.AreEqual(item2, inventory.Fetch("shield"));
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
            ClassicAssert.AreEqual(item1, fetchedItem);
            ClassicAssert.IsTrue(inventory.HasItem("sword"));
        }

        [Test]
        public void TestTakeItem()
        {
            var takenItem = inventory.Take("sword");
            ClassicAssert.AreEqual(item1, takenItem);
            ClassicAssert.IsFalse(inventory.HasItem("axe"));
        }

        [Test]
        public void TestItemList()
        {
            string expected = "bronze sword (sword)\nwooden shield (shield)";
            ClassicAssert.AreEqual(expected, inventory.ItemList);
        }
    }
}
