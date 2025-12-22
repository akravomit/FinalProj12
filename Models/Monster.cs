using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Monster
    {
        public int id { get; set; }
        public string name { get; set; }
        public string filepath { get; set; }
        public int hp { get; set; }
        public int defense { get; set; }
        public string description { get; set; } //To be displayed in entries, max 300
        public double size { get; set; } //In case I'm bored enough to add RNG-based dodges to the game, this will help determine it
        public int rarity { get; set; } //Rarity of the monster, shows as stars
        public int isboss { get; set; } //Not bool, for minibosses. 0 = normal, 1 = miniboss, 2 = boss.
        public int monsterElement { get; set; }
        public bool ishidden { get; set; } //In case I hate this monster enough to delete it
        public Monster () { }
        public Monster (string Name, string Filepath, int HP, int Defense, string Description, double Size, int Rarity, int Isboss, int MonsterElement, bool IsHidden)
        {
            name = Name;
            filepath = Filepath;
            hp = HP;
            defense = Defense;
            description = Description;
            size = Size;
            rarity = Rarity;
            isboss = Isboss;
            monsterElement = MonsterElement;
            ishidden = IsHidden;
        }
        public Monster (int Id, string Name, string Filepath, int HP, int Defense, string Description, double Size, int Rarity, int Isboss, int MonsterElement, bool IsHidden) : this (Name, Filepath, HP, Defense, Description, Size, Rarity, Isboss, MonsterElement, IsHidden)
        { id = Id; }
        public Monster(Monster other) : this(other.id, other.name, other.filepath, other.hp, other.defense, other.description, other.size, other.rarity, other.isboss, other.monsterElement, other.ishidden) { }
    }
}
