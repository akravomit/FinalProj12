using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Entry
    {
        public int id { get; set; }
        public int monster_id { get; set; } //FK of monster killed
        public int player_id { get; set; } //FK of player who killed the monster
        public DateTime date_slain { get; set; } //Date of the first kill
        public int times_killed { get; set; } //Self explanatory
        public Entry () { }
        public Entry (int monster_id, int player_id, DateTime date, int kills)
        {
            this.monster_id = monster_id;
            this.player_id = player_id;
            this.date_slain = date;
            this.times_killed = kills;
        }
        public Entry(int id, int monster_id, int player_id, DateTime date, int kills) : this (monster_id,player_id,date,kills) { this.id = id; }
        public Entry (Entry other) : this (other.id, other.monster_id, other.player_id, other.date_slain, other.times_killed) { }
    }
}
