using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Item_Type_Name
    {
        public int id { get; set; }
        public int type { get; set; } //The value in `Item_Type` in the `Item` class
        public string name { get; set; } //The name of the item type
        public bool isHidden { get; set; } //In case I don't want to use a hard delete
        public Item_Type_Name() { }
        public Item_Type_Name(int type, string name, bool IsHidden) 
        {
            this.type = type;
            this.name = name;
            this.isHidden = IsHidden;
        }
        public Item_Type_Name(int id, int type, string name, bool IsHidden) : this (type, name, IsHidden) { this.id = id; }
        public Item_Type_Name(Item_Type_Name other) : this (other.id, other.type, other.name, other.isHidden) { }
    }
}
