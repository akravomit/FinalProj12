using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Item
    {
        public int id { get; set; }
        public string filepath { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int rarity { get; set; } //Star-based rarity level
        public int value { get; set; } //Base value in coins, affected by rarity
        public int item_type { get; set; } //Item class
        public int item_increment { get; set; } //Item value increment per level (attack strength, etc)
        public int element_id { get; set; } //FK -> element
        public bool is_hidden { get; set; }
        public Item() { }
        public Item(string filepath, string name, string description, int rarity, int value, int item_type, int item_increment, int element_id, bool is_hidden)
        {
            this.filepath = filepath;
            this.name = name;
            this.description = description;
            this.rarity = rarity;
            this.value = value;
            this.item_type = item_type;
            this.item_increment = item_increment;
            this.element_id = element_id;
            this.is_hidden = is_hidden;
        }
        public Item(int id, string filepath, string name, string description, int rarity, int value, int item_type, int item_increment, int element_id, bool is_hidden) : this (filepath, name, description,rarity,value,item_type, item_increment, element_id,is_hidden) { this.id = id; }
        public Item(Item other) : this (other.id, other.filepath, other.name, other.description, other.rarity, other.value, other.item_type, other.item_increment, other.element_id, other.is_hidden) { }
    }
}
