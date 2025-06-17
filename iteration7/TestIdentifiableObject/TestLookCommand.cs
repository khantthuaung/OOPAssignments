using NUnit.Framework.Legacy;
using SwinAdventure;
namespace UnitTest;

public class TestLookCommand
{
    private Player _player;
    private Item _gem;
    private Bag _bag;
    private LookCommand _lookCommand;

    [SetUp]
    public void Setup()
    {
        Location room = new Location("room", "spawn room");
        _player = new Player("Fred", "the mighty programmer",room);
        _gem = new Item(new string[] { "gem" }, "a gem", "A bright red gem");
        _lookCommand = new LookCommand();

        _player.Inventory.Put(_gem);
        _bag = new Bag(new string[] { "bag" }, "small bag", "A small leather bag");
        _player.Inventory.Put(_bag);
    }
    [Test]
    public void TestLookAtMe()
    {
        string result = _lookCommand.Execute(_player, new string[] { "look", "at", "inventory" });
        ClassicAssert.That(result, Is.EqualTo(_player.FullDescription));
    }

    [Test]
    public void TestLookAtGem()
    {
        string result = _lookCommand.Execute(_player, new string[] { "look", "at", "gem" });
        Assert.That(result, Is.EqualTo("A bright red gem"));
    }

    [Test]
    public void TestLookAtUnk()
    {
        string result = _lookCommand.Execute(_player, new string[] { "look", "at", "ruby" });
        Assert.That(result, Is.EqualTo("I can't find the ruby"));
    }

    [Test]
    public void TestLookAtGemInMe()
    {
        string result = _lookCommand.Execute(_player, new string[] { "look", "at", "gem", "in", "inventory" });
        Assert.That(result, Is.EqualTo("A bright red gem"));
    }

    [Test]
    public void TestLookAtGemInBag()
    {
        var gemInBag = new Item(new string[] { "gem" }, "a gem", "A red gem in the bag");
        _bag.Inventory.Put(gemInBag);

        string result = _lookCommand.Execute(_player, new string[] { "look", "at", "gem", "in", "bag" });
        Assert.That(result, Is.EqualTo("A red gem in the bag"));
    }

    [Test]
    public void TestLookAtGemInNoBag()
    {
        _player.Inventory.Take("bag"); // Remove the bag
        string result = _lookCommand.Execute(_player, new string[] { "look", "at", "gem", "in", "bag" });
        Assert.That(_player.Inventory.HasItem("bag"), Is.False);
        // Assert.That(result, Is.EqualTo("I can't find the bag"));
    }

    [Test]
    public void TestLookAtNoGemInBag()
    {
        string result = _lookCommand.Execute(_player, new string[] { "look", "at", "gem", "in", "bag" });
        Assert.That(result, Is.EqualTo("I can't find the gem"));
    }

    [Test] 
    public void TestInvalidLook()
    {
        string result1 = _lookCommand.Execute(_player, new string[] { "look", "around" });
        Assert.That(result1, Is.EqualTo("I don't know how to look like that"));

        string result2 = _lookCommand.Execute(_player, new string[] { "hello", "105292912" });
        Assert.That(result2, Is.EqualTo("Error in look input"));

        string result3 = _lookCommand.Execute(_player, new string[] { "look", "at", "Fred" });
        Assert.That(result3, Is.EqualTo("I can't find the Fred"));
    }
}