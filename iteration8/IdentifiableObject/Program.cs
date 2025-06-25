namespace SwinAdventure;

public class Program
{
    public static void Main()
    {
        string playerName;
        string playerDescription;
        CommandProcessor processor = new CommandProcessor();

        Console.WriteLine("Enter your name, Adventurer!");
        Console.Write("Name -> ");
        playerName = Console.ReadLine();
        Console.WriteLine("Now how do you describe yourself, Adventurer!");
        Console.Write("Description -> ");
        playerDescription = Console.ReadLine();

        Location spawnPoint = new(new string[]{"gate"},"Front Gate", "a Front Gate of the theme park.");
        Player me = new(playerName, playerDescription, spawnPoint);
        me.Location = spawnPoint;

        //locations
        Location ferrisWheel = new(new string[]{"ferris"},"Ferris Wheel", "a ferris wheel area that many people are lining to ride.");
        Location jungleRide = new(new string[]{"jungle"},"Jungle Ride", "a water ride with the vibe full of jungle.\n You can even hear the bird noise from the front.");
        Location hauntedHouse = new(new string[]{"haunted"},"Haunted House", "a really scary haunted house that many screaming voices are coming from there.");
        Location iceCreamShop = new(new string[]{"shop"},"Ice-cream Shop", "an icecream shop that many parents are lining up for their chilren.");
        Location boatRace = new(new string[]{"boat"},"Boat Race", "a boat race where you can participate.\nA race just began.");

        //exits for each location
        //from spawn
        Path spawnEast = new(new string[] { "east" ,"e"}, "Concerete Path", "a path leadig to ferris wheel area", ferrisWheel);
        spawnPoint.AddPath(spawnEast);

        Path ferrisEast = new(new string[] { "east" ,"e"}, "Concerete Path", "a path leading to Jungle Ride area", jungleRide);
        Path ferrisWest = new(new string[] { "west","w" }, "Concerete Path", "a path leading back to gate. ", spawnPoint);
        ferrisWheel.AddPath(ferrisEast);
        ferrisWheel.AddPath(ferrisWest);
        Path jungleWest = new(new string[] { "west" ,"w"}, "Concerete Path", "a path leading back to Ferris Wheel area", ferrisWheel);
        Path jungleNorth = new(new string[] { "north" ,"n"}, "Dirt Path", "a path leading to Haunted House area", hauntedHouse);
        jungleRide.AddPath(jungleWest);
        jungleRide.AddPath(jungleNorth);
        Path hauntEast = new(new string[] { "east" ,"e"}, "Small Bridge", "a path leading to Ice Cream Shop", iceCreamShop);
        Path hauntSouth = new(new string[] { "south" ,"s" }, "Dirt Path", "a path leading back to Jungle Ride Area", jungleRide);
        Path hauntSe = new(new string[] { "southeast" ,"se" }, "Stone Path", "a path leading to Boat Racing Area", boatRace);
        hauntedHouse.AddPath(hauntEast);
        hauntedHouse.AddPath(hauntSouth);
        hauntedHouse.AddPath(hauntSe);
        Path iceSouth = new(new string[] { "south","s" }, "Concerete Path", "a path leading to Boat Racing Area", boatRace);
        Path iceWest = new(new string[] { "west","w" }, "Small Bridge", "a path leading back to Haunted House Area", hauntedHouse);
        iceCreamShop.AddPath(iceSouth);
        iceCreamShop.AddPath(iceWest);
        Path boatNw = new(new string[] { "northwest","nw" }, "Stone Path", "a path leading to Haunted House Area", hauntedHouse);
        Path boatNorth = new(new string[] { "north" ,"n"}, "Concerete Path", "a path leading to Ice Cream Area", iceCreamShop);
        boatRace.AddPath(boatNw);
        boatRace.AddPath(boatNorth);
        
        //items
        Item phone = new(new string[] { "phone", "modern phone" }, "A modern phone", "A phone that you have been using for 2 years.");
        Item wallet = new(new string[] { "wallet", "old wallet" }, "An old wallet", "A wallet that your dad gifted on your 10th birthday.");
        Bag bag = new(new string[] { "bag", "school bag" }, "A school bag", "A blue school bag that you take everywhere you go.");
        Item ring = new(new string[] { "ring", "gold ring" }, "A gold ring", "A high value ring that's been passed down to you");

        Bag oldBag = new(new string[] { "oldbag", "torn bag" }, "a torn bag", "A torn bag someone left behind");
        Item ticket = new(new string[] { "ticket", "entry ticket" }, "An entry ticket", "A ticket to the theme park.");
        Item miniFan = new(new string[] { "fan", "small fan" }, "A small fan", "A small fan that can make you cool");
        Item coin = new(new string[] { "coin", "bronze coin" }, "A bronze coin", "A bronze coin that someone dropped");
        Item flower = new(new string[] { "flower", "yellow flower" }, "A yellow flower", "A yellow flower growing near the Jungle Ride");
        Item skull = new(new string[] { "skull", "plastic skull" }, "A plastic skull", "A plastic scary skull that you found in Haunted House");
        Item iceCream = new(new string[] { "icecream", "vanilla icecream" }, "A vanilla icecream", "People say this vanilla icecream is the best");
        Item miniBoat = new(new string[] { "miniboat", "red miniboat" }, "A red miniboat", "Staffs are giving out miniboat for the kids");
        Item book = new(new string[] { "book", "small book" }, "a small book", "a book that is inside a torn bag");

        //player initial inventory
        me.Inventory.Put(phone);
        me.Inventory.Put(wallet);
        me.Inventory.Put(bag);
        bag.Inventory.Put(ring);
        oldBag.Inventory.Put(book);

        //locations inventories
        //spawn
        spawnPoint.Inventory.Put(ticket);

        //ferrisWheel
        ferrisWheel.Inventory.Put(miniFan);
        ferrisWheel.Inventory.Put(oldBag);

        //jungle
        jungleRide.Inventory.Put(coin);
        jungleRide.Inventory.Put(flower);

        //haunted house
        hauntedHouse.Inventory.Put(skull);

        //icecream
        iceCreamShop.Inventory.Put(iceCream);

        //boat race
        boatRace.Inventory.Put(miniBoat);
        
        Console.WriteLine("Welcome to Swin Adventure!\nYou have arrived at the front gate of the theme park.");
        while (true)
        {
            string command = "";
            Console.Write("Command -> ");
            command = Console.ReadLine();
            string[] parts = command.ToLower().Split(' ');

            if (parts[0] == "exit" || parts[0] == "end")
            {
                Console.WriteLine("Bye Adventurer!");
                return;
            }
            Console.WriteLine(processor.ExecuteCommand(me, parts));
        }
    }

}