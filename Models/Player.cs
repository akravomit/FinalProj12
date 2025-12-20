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
        public int hp { get; set; }
        public int mana { get; set; }
        public int coins { get; set; }
        public bool is_hidden { get; set; }
        public int owner_id { get; set; } //FK to user ID
        public Player() { }
        public Player(int id, string name, int hp, int mana, int coins, bool is_hidden, int owner_id)
        {
            this.id = id;
            this.name = name;
            this.hp = hp;
            this.mana = mana;
            this.coins = coins;
            this.is_hidden = is_hidden;
            this.owner_id = owner_id;
        }
    }
}
