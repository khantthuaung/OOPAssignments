using SwinAdventure;
using NUnit.Framework.Legacy;
namespace UnitTest;

[TestFixture]
public class TestLocation
{
    private Location room;
    private Item gem;
    private Player player;

    [SetUp]
    public void SetUp()
    {
        room = new Location(new string[] {"hall"},"hall", "a large empty hall");
        gem = new Item(new string[] { "Gem", "a gem" }, "A beautiful gem", "A beautiful gem that you found in the chest");
        player = new("Fred", "a mighty adventurer",room);
        player.Location = room;
        room.Inventory.Put(gem);
    }
    [Test]
    public void Location_IdentifiesItself()
    {
        ClassicAssert.IsTrue(room.AreYou("hall"));
        Assert.That(room.Locate("hall"), Is.EqualTo(room));
    }
    [Test]
    public void Location_CanLocateItemInInventory()
    {
        GameObject found = room.Locate("gem");
        ClassicAssert.IsNotNull(found);
        ClassicAssert.AreEqual(gem, found);
    }
    [Test]
    public void Player_CanLocateItemInTheirLocation()
    {
        GameObject found = player.Locate("gem");
        ClassicAssert.IsNotNull(found);
        ClassicAssert.AreEqual(gem, found);
    }

}