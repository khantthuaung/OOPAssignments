using System.Reflection.Metadata.Ecma335;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _location;
        public Player(string name, string desc,Location location) : base(new string[] { "me", "inventory" }, name, desc)
        {
            _location = location;
            _inventory = new Inventory();
        }
        public GameObject Locate(string id)
        {
            if (AreYou(id)) return this;
            GameObject item = Inventory.Fetch(id);
            if (item != null) return item;
            return Location.Locate(id);
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