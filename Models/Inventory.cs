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
        public Inventory () { }
        public Inventory (int playerID, int itemID, int item_level)
        {
            PlayerID = playerID; ItemID = itemID; Item_level = item_level;
        }
        public Inventory (int id, int playerID, int itemID, int item_level) : this (playerID, itemID, item_level)
        { Id = id; }
        public Inventory (Inventory other) : this (other.Id, other.PlayerID, other.ItemID, other.Item_level)
        { }
    }
}
