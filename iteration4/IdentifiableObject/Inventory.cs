namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }
        public bool HasItem(string id)
        {
            return _items.Any(_item => _item.AreYou(id));
        }
        public void Put(Item item)
        {
            _items.Add(item);
        }
        public Item? Take(string id)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i].AreYou(id))
                {
                    Item takenItem = _items[i];
                    _items.RemoveAt(i);
                    return takenItem;
                }
            }
            return null;
        }
        public Item? Fetch(string id)
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id)) return item;
            }
            return null;
        }
        public string ItemList
        {
            get
            {
                string list = "";
                foreach (Item item in _items)
                {
                    list += item.ShortDescription + "\n";
                }
                return list.TrimEnd();
            }
        }
    }
}