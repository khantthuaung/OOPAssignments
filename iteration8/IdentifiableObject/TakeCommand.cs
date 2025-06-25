using System.ComponentModel;

namespace SwinAdventure;

public class TakeCommand : Command
{
    public TakeCommand() : base(new string[]{"pickup","take"})
    {
    }

    public override string Execute(Player p, string[] text)
    {
        if (text.Length != 2 && text.Length != 4)
            return "I don't understand what you want to take.";

        string itemId = text[1];
        
        if (text.Length == 2)
        {
            // take from current location
            GameObject item = p.Location.Inventory.Take(itemId);
            if (item == null)
                return $"There is no {itemId} here.";

            if (item is Item takenItem)
            {
                p.Inventory.Put(takenItem);
                return $"You took the {takenItem.Name} from {p.Location.Name}";
            }
            return $"{itemId} is not an item you can take.";
        }
        else if (text.Length == 4 && text[2].ToLower() == "from")
        {
            string containerId = text[3];
            GameObject container = p.Locate(containerId);

            if (container is IHaveInventory hasInventory)
            {
                GameObject item = hasInventory.Inventory.Take(itemId);
                if (item == null)
                    return $"There is no {itemId} in the {container.Name}.";

                if (item is Item takenItem)
                {
                    p.Inventory.Put(takenItem);
                    return $"You took the {takenItem.Name} from the {container.Name}.";
                }
                return $"{itemId} is not an item you can take.";
            }
            return $"I can't find the {containerId}.";
        }
        return "I don't understand how to take like that.";
    }
}