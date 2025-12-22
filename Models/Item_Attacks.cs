using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Item_Attacks
    {
        public int id { get; set; }
        public int ItemID { get; set; } //FK -> Item
        public int AttackID { get; set; } //FK -> Attack
        public Item_Attacks () { }
        public Item_Attacks (int itemID, int attackID) 
        {
            this.ItemID = itemID;
            this.AttackID = attackID;
        }
        public Item_Attacks (int Id, int itemID, int attackID) : this (itemID, attackID) { id = Id; }
        public Item_Attacks (Item_Attacks other) : this (other.id, other.ItemID, other.AttackID) { }
    }
}
