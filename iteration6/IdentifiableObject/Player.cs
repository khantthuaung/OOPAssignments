using System.Reflection.Metadata.Ecma335;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _location;
        public Player(string name, string desc,Location location) : base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
            _location = location;
        }
        public GameObject Locate(string id)
        {
            if (AreYou(id)) return this;
            GameObject item = Inventory.Fetch(id);
            if (item != null) return item;
            if (Location != null) return Location.Locate(id); 
            return null;
        }
        public override string FullDescription
        {
            get
            {
                return $"You are {Name}, {base.FullDescription}.\nYou are carrying:\n{Inventory.ItemList}";
            }
        }
        public Inventory Inventory
        {
            get { return _inventory; }
        }
        public Location Location
        {
            get { return _location; }
            set { _location = value; }
        }
    }
}