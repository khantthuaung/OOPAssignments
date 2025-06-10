namespace SwinAdventure;

public class Location : GameObject, IHaveInventory
{
    private Inventory _inventory;
    public Location(string name, string desc) : base(new string[] { name.ToLower() }, name, desc)
    {
        _inventory = new Inventory();
    }
    public GameObject Locate(string id)
    {
        if (AreYou(id)) { return this; }
        return Inventory.Fetch(id);
    }
    public Inventory Inventory { get { return _inventory; } }
    public override string FullDescription
    {
        get
        {
        return $"You are at {base.Name}\nThis is a {base.FullDescription}\nIn this {base.Name}, you can see {Inventory.ItemList}";
        }
    }
}