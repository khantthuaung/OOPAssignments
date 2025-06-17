namespace SwinAdventure;

public class MoveCommand : Command
{
    public MoveCommand() :
    base(new string[] { "move", "head", "leave", "go" }){}

    public override string Execute(Player p, string[] text)
    {
        if (text.Length < 2) return "Move where?";

        string direction = text[1];
        Path path = p.Location.GetPath(direction);

        if (path == null)
            return $"There is no path to {direction}";

        path.PlayerMove(p);
        return $"You move {direction} to {p.Location.Name}.\n{p.Location.FullDescription}"; 
    }
}