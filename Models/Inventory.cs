using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public int PlayerID { get; set; } //FK of owner of the item
        public int ItemID { get; set; } //FK of the item
        public int Item_level { get; set; } //Instead of in the item table, as it can change per player only. Default 1 (no change)
        public bool IsHidden { get; set; } //In case I want to delete by hiding and not outright deleting it
        public int Amount { get; set; } //How did I forget to add this until now, March?! :skull:
        public Inventory () { }
        public Inventory (int playerID, int itemID, int item_level, bool isHidden, int amount)
        {
            PlayerID = playerID; 
            ItemID = itemID; 
            Item_level = item_level;
            IsHidden = isHidden;
            Amount = amount;
        }
        public Inventory (int id, int playerID, int itemID, int item_level, bool isHidden, int amount) : this (playerID, itemID, item_level, isHidden, amount)
        { Id = id; }
        public Inventory (Inventory other) : this (other.Id, other.PlayerID, other.ItemID, other.Item_level, other.IsHidden, other.Amount)
        { }
    }
}
