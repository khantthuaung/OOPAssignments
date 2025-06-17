using NUnit.Framework.Legacy;
using SwinAdventure;
using Path = SwinAdventure.Path;
namespace UnitTest;
[TestFixture]
public class TestPathAndMove
{
    private Player player;
    private Location hallway;
    private Location garden;
    private MoveCommand moveCommand;

    [SetUp]
    public void Setup()
    {
        hallway = new Location("Hallway", "A long well lit hallway.");
        garden = new Location("Garden", "A lush garden with flowers.");

        // Add two-way paths
        hallway.AddPath(new Path(new string[] { "south" }, "South Path", "A path leading south.", garden));
        garden.AddPath(new Path(new string[] { "north" }, "North Path", "A path leading back north.", hallway));

        player = new Player("Alex", "an adventurer", hallway);
        moveCommand = new MoveCommand();
    }

    [Test]
    public void TestMoveSouth()
    {
        string result = moveCommand.Execute(player, new string[] { "move", "south" });

        Assert.That(player.Location, Is.EqualTo(garden));
        Assert.That(result, Does.Contain("You move south"));
        Assert.That(result, Does.Contain("Garden"));
    }

    [Test]
    public void TestMoveNorthBack()
    {
        // Move to garden first
        player.Location = garden;

        string result = moveCommand.Execute(player, new string[] { "move", "north" });

        Assert.That(player.Location, Is.EqualTo(hallway));
        Assert.That(result, Does.Contain("You move north"));
        Assert.That(result, Does.Contain("Hallway"));
    }

    [Test]
    public void TestInvalidDirection()
    {
        string result = moveCommand.Execute(player, new string[] { "move", "east" });

        Assert.That(player.Location, Is.EqualTo(hallway)); // Still in original location
        Assert.That(result, Is.EqualTo("There is no path to east"));
    }

    [Test]
    public void TestMissingCommand()
    {
        string result = moveCommand.Execute(player, new string[] { "move" });

        Assert.That(result, Is.EqualTo("Move where?").IgnoreCase);
    }

    [Test]
    public void TestIdentifiablePath()
    {
        Path southPath = hallway.GetPath("south");

        ClassicAssert.IsTrue(southPath.AreYou("south"));
        ClassicAssert.IsFalse(southPath.AreYou("north"));
    }
}
