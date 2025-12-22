using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Attack
    {
        public int id { get; set; }
        public string filepath { get; set; } //File path for the sprite of this attack
        public string name { get; set; }
        public int damage { get; set; } //Flat damage done on the first turn where it is applied
        public int decay { get; set; } //Turns or legnth of the attack
        public double decay_factor { get; set; } //Decrease increment for each turn
        public int duration { get; set; } //Duration of turns the attack sticks for
        public int ElementID { get; set; } //FK for elements
        public bool IsHidden { get; set; } //Saved as int in the Database
        public Attack() { }
        public Attack(string filepath, string name, int damage, int decay, double decay_factor, int duration, int elementID, bool isHidden)
        {
            this.filepath = filepath;
            this.name = name;
            this.damage = damage;
            this.decay = decay;
            this.decay_factor = decay_factor;
            this.duration = duration;
            ElementID = elementID;
            IsHidden = isHidden;
        }
        public Attack (int id, string filepath, string name, int damage, int decay, double decay_factor, int duration, int elementID, bool isHidden) : this (filepath, name, damage, decay, decay_factor, duration, elementID, isHidden) { this.id = id; }
        public Attack (Attack other) : this (other.id, other.filepath, other.name, other.damage, other.decay, other.decay_factor, other.duration, other.ElementID, other.IsHidden) { }
    }
}
