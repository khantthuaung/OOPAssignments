using NUnit.Framework.Legacy;
using SwinAdventure;
namespace UnitTest;
[TestFixture]
public class CommandTests
{
    private Player player;
    private Location location;
    private Bag bag;
    private Item phone;
    private Item ring;
    private CommandProcessor processor;

    [SetUp]
    public void Setup()
    {
        location = new Location(new string[]{"ground"},"ground", "The theme park entrance.");
        player = new Player("Alex", "an adventurer", location);
        processor = new CommandProcessor();

        // Items
        phone = new Item(new[] { "phone" }, "Modern Phone", "Your personal smartphone.");
        ring = new Item(new[] { "ring" }, "Gold Ring", "A precious gold ring.");

        // Bag setup
        bag = new Bag(new[] { "bag" }, "School Bag", "A small school bag.");
        player.Inventory.Put(phone);
        player.Inventory.Put(bag);
    }
        [Test]
    public void PutItemIntoBag_Success()
    {
        string result = processor.ExecuteCommand(player, new[] { "put", "phone", "in", "bag" });
        Assert.That(result, Does.Contain("You put the Modern Phone in the bag"));

        // Item should now be in the bag
        ClassicAssert.IsNull(player.Inventory.Fetch("phone"));
        ClassicAssert.IsNotNull(bag.Inventory.Fetch("phone"));
    }

    [Test]
    public void DropItemToGround()
    {
        string result = processor.ExecuteCommand(player, new[] { "put", "phone" });
        Assert.That(result, Does.Contain("You dropped Modern Phone"));

        ClassicAssert.IsNull(player.Inventory.Fetch("phone"));
        ClassicAssert.IsNotNull(location.Inventory.Fetch("phone"));
    }

    [Test]
    public void PutItem_YouDontHave()
    {
        string result = processor.ExecuteCommand(player, new[] { "put", "wallet" });
        Assert.That(result, Does.Contain("You don't have wallet"));
    }

    [Test]
    public void TakeItemFromBag_Success()
    {
        bag.Inventory.Put(ring);
        string expected = "You took the Gold Ring from the School Bag";
        string result = processor.ExecuteCommand(player, new[] { "take", "ring", "from", "bag" });
        Assert.That(result, Does.Contain(expected));

        ClassicAssert.IsNotNull(player.Inventory.Fetch("ring"));
        ClassicAssert.IsNull(bag.Inventory.Fetch("ring"));
    }

    [Test]
    public void TakeItemFromGround_Success()
    {
        location.Inventory.Put(ring);

        string result = processor.ExecuteCommand(player, new[] { "take", "ring" });
        Assert.That(result, Does.Contain("You took the Gold Ring"));

        ClassicAssert.IsNotNull(player.Inventory.Fetch("ring"));
    }

    [Test]
    public void TakeItemThatDoesNotExist()
    {
        string result = processor.ExecuteCommand(player, new[] { "take", "key" });
        Assert.That(result, Does.Contain("There is no key here"));
    }


    [Test]
    public void ExecuteUnknownCommand_ReturnsError()
    {
        string result = processor.ExecuteCommand(player, new[] { "fly", "north" });
        ClassicAssert.AreEqual("I don't understand 'fly'.", result);
    }

    [Test]
    public void ExecutePutCommand_Works()
    {
        string result = processor.ExecuteCommand(player, new[] { "put", "phone" });
        Assert.That(result, Does.Contain("You dropped"));
    }

    [Test]
    public void ExecuteTakeCommand_Works()
    {
        location.Inventory.Put(phone);
        string result = processor.ExecuteCommand(player, new[] { "take", "phone" });

        Assert.That(result, Does.Contain("You took the Modern Phone"));
        ClassicAssert.IsNotNull(player.Inventory.Fetch("phone"));
    }
}
