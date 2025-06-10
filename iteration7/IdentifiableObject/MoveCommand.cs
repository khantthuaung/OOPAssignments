namespace SwinAdventure;

public class MoveCommand : Command
{
    public MoveCommand(string[] ids) :
    base(new string[] { "move", "head", "leave", "go" })
    {}

    public override string Execute(Player p, string[] text)
    {
        throw new NotImplementedException();
    }
}