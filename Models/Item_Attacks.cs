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
        public double Attack_Increment { get; set; }
        public bool IsHidden { get; set; }
        public Item_Attacks () { }
        public Item_Attacks (int itemID, int attackID, double attackIncrement, bool IsHidden) 
        {
            this.ItemID = itemID;
            this.AttackID = attackID;
            this.IsHidden = IsHidden;
        }
        public Item_Attacks (int Id, int itemID, int attackID, double attackIncrement, bool IsHidden) : this (itemID, attackID, attackIncrement, IsHidden) { id = Id; }
        public Item_Attacks (Item_Attacks other) : this (other.id, other.ItemID, other.AttackID, attackIncrement, other.IsHidden) { }
    }
}
