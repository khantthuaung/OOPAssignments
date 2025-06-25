namespace SwinAdventure;

public class PutCommand : Command
{
    public PutCommand() : base(new string[] { "put", "drop" }) { }

    public override string Execute(Player p, string[] text)
    {
        if (text.Length == 2)
        {
            // put item / drop item => drop to ground (location)
            string itemId = text[1];
            Item item = p.Inventory.Take(itemId);
            if (item == null)
                return $"You don't have {itemId}.";

            p.Location.Inventory.Put(item);
            return $"You dropped {item.Name} at {p.Location.Name}.";
        }

        if (text.Length == 4 && text[2].ToLower() == "in")
        {
            string itemId = text[1];
            string containerId = text[3];

            // Locate container (bag, location, etc.)
            IHaveInventory container = FetchContainer(p, containerId);
            if (container == null)
                return $"I can't find the {containerId}.";

            Item item = p.Inventory.Take(itemId);
            if (item == null)
                return $"You don't have {itemId}.";

            container.Inventory.Put(item);
            return $"You put the {item.Name} in the {containerId}.";
        }

        return "I don't know how to put like that.";
    }
    public IHaveInventory FetchContainer(Player p, string id)
    {
        GameObject obj = p.Locate(id);
        return obj as IHaveInventory;
    }
}
