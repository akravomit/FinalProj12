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
        public int monster_id { get; set; }
        public int player_id { get; set; }
        public DateTime date_slain { get; set; }
        public int times_killed { get; set; }
        public Entry () { }
        public Entry (int id, int monster_id, int player_id, DateTime date, int kills)
        {
            this.id = id;
            this.monster_id = monster_id;
            this.player_id = player_id;
            this.date_slain = date;
            this.times_killed = kills;
        }
    }
}
