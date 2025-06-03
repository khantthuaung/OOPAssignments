namespace SwinAdventure
{
    public class Bag : Item,IHaveInventory
    {
        private Inventory _inventory;
        public Bag(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
        }
        public GameObject Locate(string id)
        {

            if (AreYou(id))
            {
                return this;
            }
            return _inventory.Fetch(id);
        }
        public override string FullDescription
        {
            get
            {
                string itemsDescription = _inventory.ItemList;
                if (string.IsNullOrEmpty(itemsDescription))
                {
                    return $"{base.FullDescription}. It's empty.";
                }
                else
                {
                    return $"{base.FullDescription}.\nIn the {Name}, you can see:\n{itemsDescription}";
                }
            }
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }
    }
}