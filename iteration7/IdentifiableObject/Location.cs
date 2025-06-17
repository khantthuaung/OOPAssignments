namespace SwinAdventure;

public class Location : GameObject, IHaveInventory
{
    private Inventory _inventory;
    private List<Path> _paths;
    public Location(string name, string desc) : base(new string[] { name.ToLower() }, name, desc)
    {

        _paths = new List<Path>();
        _inventory = new Inventory();
    }
    public GameObject Locate(string id)
    {
        if (AreYou(id)) { return this; }
        return Inventory.Fetch(id);
    }
    public void AddPath(Path path)
    {
        _paths.Add(path);
    }
    public Path GetPath(string direction)
    {
        foreach (Path p in _paths)
        {
            if (p.AreYou(direction))
            {
                return p;
            }
        }
        return null;
    }
    public Inventory Inventory { get { return _inventory; } }
    public override string FullDescription
    {
        get
        {
            string exits = "";
        foreach (Path path in _paths)
        {
            exits += $"- {path.FirstID} to {path.Destination.Name}\n";
        }
        return $"You are at {base.Name}\nThis is a {base.FullDescription}\n.In this {base.Name}, you can see \n{Inventory.ItemList}\nFrom this area, you can go \n{exits}";
        }
    }
}