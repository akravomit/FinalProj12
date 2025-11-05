using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Entry
    {
        public int _id {  get; set; }
        public string _name { get; set; }
        public int _monsterID { get; set; }
        public string _dateSlain { get; set; }
        public int _kills { get; set; }
        public string _playerfirstkill { get; set; }
        public Entry() { }
        public Entry(int id, string name, int monsterID, string dateSlain, int kills, string playerfirstkill)
        {
            _id = id;
            _name = name;
            _monsterID = monsterID;
            _dateSlain = dateSlain;
            _kills = kills;
            _playerfirstkill = playerfirstkill;
        }
        public override string ToString()
        {
            string ret = string.Empty;
            ret += $"Catalog entry num.{_id}:\r\n";
            ret += $"[Monster: {_name}, Id in database: {_monsterID}]\r\n";
            ret += $"[Times slain: {_kills}]\r\n";
            ret += $"[First kill is by {_playerfirstkill} on {_dateSlain}]\r\n";
            return ret;
        }
    }
}
