using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Player
    {
        public int id { get; set; }
        public string name { get; set; } //Max 20 chars
        public int hp { get; set; } //Default 100
        public int mana { get; set; } //Default 20
        public int coins { get; set; } //Default 0
        public bool is_hidden { get; set; } //Default false
        public int owner_id { get; set; } //FK to user ID
        public Player() { }
        public Player(string name, int hp, int mana, int coins, bool is_hidden, int owner_id)
        {
            this.name = name;
            this.hp = hp;
            this.mana = mana;
            this.coins = coins;
            this.is_hidden = is_hidden;
            this.owner_id = owner_id;
        }
        public Player (int id, string name, int hp, int mana, int coins, bool is_hidden, int owner_id) : this (name, hp, mana, coins, is_hidden, owner_id) { this.id = id; }
        public Player (Player other) : this (other.id, other.name, other.hp, other.mana, other.coins, other.is_hidden, other.owner_id) { }
        public Player (string name,int owner_id) : this (name, 100, 20, 0, false, owner_id) { }
        //Default constructor for new users
    }
}
