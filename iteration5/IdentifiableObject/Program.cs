namespace SwinAdventure;

public class Program
{
    public static void Main(string[] args)
    {
        string playerName;
        string playerDescription;

        Console.WriteLine("Enter your name, Adventurer!");
        Console.Write("Name -> ");
        playerName = Console.ReadLine();
        Console.WriteLine("Now how do you describe yourself, Adventurer!");
        Console.Write("Description -> ");
        playerDescription = Console.ReadLine();

        Player me = new(playerName, playerDescription);

        Item shield = new(new string[] { "shield", "broken shield" }, "A broken shield", "A sheild that's been through alot");
        Item sword = new(new string[] { "sword", "dull sword" }, "A dull sword", "A sword that's been fought for its life");

        me.Inventory.Put(shield);
        me.Inventory.Put(sword);
        Bag bag = new(new string[] { "bag", "brown bag" }, "A brown bag", "A small brown bag already have two holes");
        me.Inventory.Put(bag);
        Item ring = new(new string[] { "ring", "gold ring" }, "A gold ring", "A high value ring that's been passed down to you");
        bag.Inventory.Put(ring);

        while (true)
        {
            string command = "";
            Console.Write("Command -> ");
            command = Console.ReadLine();
            string[] parts = command.ToLower().Split(' ');
            switch (parts[0])
            {
                case "exit":
                case "end":
                    {
                        Console.WriteLine("Bye Adventurer!");
                        return;
                    }
                case "look":
                case "inventory":
                case "inv":
                    {
                        Console.WriteLine(new LookCommand().Execute(me, parts));
                        break;
                    }
                default:
                    {
                        Console.WriteLine("I don't know how to respone that.");
                        break;
                    }
            }
        }
    }
}