namespace CLIShop
{
    public class Item
    {
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public double Weight { get; set; }
        public Item()
        {
        }

        public Item(string? name, double price, string? description, double weight)
        {
            Name = name;
            Price = price;
            Description = description;
            Weight = weight;
        }

        public Item(string? name, double? price, string? description, double? weight)
        {
            Name = name;
            Price = price ?? 0;
            Description = description;
            Weight = weight ?? 0;
        }
    }
    public class City
    {
        public string Name;
        // List of available items
        public List<Item> Items = new List<Item>();
        public City(string name)
        {
            Name = name;
        }
        public void AddItem(Item item)
        {
            Items.Add(item);
        }
        public List<string> GetItemNames()
        {
            List<string> itemNames = new List<string>();
            foreach (Item item in Items)
            {
                itemNames.Add(item.Name);
            }
            return itemNames;
        }
        public int GetItemCount() { return Items.Count; }
    }
    public class Cart
    {
        // Dictionary of item and their quantities
        public Dictionary<Item, int> Items = new Dictionary<Item, int>();
        public double Total;
        public double DeliveryPrice = 0;
        public void AddItem(Item item)
        {
            // If the item is already in the cart, increment the quantity
            if (Items.ContainsKey(item))
            {
                Items[item]++;
            }
            // Otherwise, add the item to the cart
            else
            {
                Items.Add(item, 1);
            }
            RecalculateTotal();
        }
        public void RemoveItem(Item item, int quantity)
        {
            int newQuantity = Items[item] - quantity;
            if (newQuantity <= 0)
            {
                Items.Remove(item);
            }
            else
            {
                Items[item] = newQuantity;
            }
        }
        public void ClearCart()
        {
            Items.Clear();
            RecalculateTotal();
        }
        void RecalculateTotal()
        {
            Total = 0;
            foreach (KeyValuePair<Item, int> item in Items)
            {
                Total += item.Key.Price * item.Value;
            }
        }

        public double GetTotal()
        {
            return Total + DeliveryPrice;
        }
        public Dictionary<Item, int> GetItems()
        {
            return Items;
        }

        public string GetCartSummary() {
            var output = "";
            var cart_items = this.GetItems();
            if (cart_items.Count == 0)
            {
                return("Your cart is empty!");
            }
            output += ("Your cart:\n");
            foreach (var item in cart_items)
            {
                output += $"{item.Key.Name} - x{item.Value} ({item.Key.Price * item.Value} UAH)\n";
            }
            return output;
        }

        public void setDeliveryPrice(double price)
        {
            DeliveryPrice = price;
        }
    }
}
