namespace SwinAdventure;

public class LookCommand : Command
{

    public LookCommand() : base(new string[] { "look" }) { }
    public override string Execute(Player p, string[] text)
    {

        if (text[0].ToLower() != "look")
        {
            return "Error in look input";
        }
        if(text.Length== 1 && text[0].ToLower() == "look")
        {
            return p.Location.FullDescription;
        }
        if (text.Length != 3 && text.Length != 5)
        {
            return "I don't know how to look like that";
        }
        if (text[1].ToLower() != "at")
        {
            return "What do you want to look at?";
        }
        if (text.Length == 5 && text[3].ToLower() != "in")
        {
            return "What do you want to look in?";
        }
        string itemId = text[2];
        IHaveInventory container;

        if (text.Length == 3)
        {
            container = p;
        }
        else
        {
            string containerId = text[4];
            container = FetchContainer(p, containerId);
            if (container == null)
            {
                return $"I can't find the {containerId}";
            }
        }
        return LookAtIn(itemId, container);   
    }

    private IHaveInventory FetchContainer(Player p, string containerId)
    {
        GameObject obj = p.Locate(containerId);
        return obj as IHaveInventory;
    }
    private string LookAtIn(string thingId, IHaveInventory container)
    {
        GameObject item = container.Locate(thingId);
        if (item == null)
        {
            return $"I can't find the {thingId}";
        }
        return item.FullDescription;
    }
}