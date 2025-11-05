using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Player
    {
        public int _id {  get; set; }
        public string _name { get; set; }
        public int _hp { get; set; }
        public int _CHP { get; set; }
        public int _mana { get; set; }
        public int _CMP { get; set; }
        public int _coins { get; set; }
        public int SWORDLevel { get; set; }
        public int GUNLevel { get; set; }
        public int WANDLevel { get; set; }
        public int ARMORLevel { get; set; }
        public int ARMORType { get; set; }
        public Player() { }
        public Player(int id, string name, int hp, int mana, int coins, int sWORDLevel, int gUNLevel, int wANDLevel, int aRMORLevel, int aRMORType)
        {
            _id = id;
            _name = name;
            _hp = hp;
            _CHP = hp;
            _mana = mana;
            _CMP = mana;
            _coins = coins;
            SWORDLevel = sWORDLevel;
            GUNLevel = gUNLevel;
            WANDLevel = wANDLevel;
            ARMORLevel = aRMORLevel;
            ARMORType = aRMORType;
        }
        public Player(string name)
        {
            _name = name;
            _hp = 100;
            _CHP = _hp;
            _mana = 20;
            _CMP = _mana;
            _coins = 0;
            SWORDLevel = 0;
            GUNLevel = 0;
            WANDLevel = 0;
            ARMORLevel = 0;
            ARMORType = 0;
        }
        public Player(Player player)
        {
            _id=player._id;
            _name = player._name;
            _hp = player._hp;
            _CHP = player._hp;
            _mana = player._mana;
            _CMP = player._mana;
            _coins = player._coins;
            SWORDLevel = player.SWORDLevel;
            GUNLevel = player.GUNLevel;
            WANDLevel = player.WANDLevel;
            ARMORLevel = player.ARMORLevel;
            ARMORType = player.ARMORType;
        }
        public override string ToString()
        {
            string ret = string.Empty;
            ret += $"[{_name}'s stats:   ]\r\n";
            ret += $"[HP: {_CHP}/{_hp}][MANA: {_CMP}/{_mana} ][coins: {_coins}] \r\n";
            ret += $"[weapon levels: sword:{SWORDLevel}, gun:{GUNLevel}, wand:{WANDLevel}][armor level: {ARMORLevel}][armor type:";
            switch (ARMORType)
            {
                case 1:
                    ret += "Heavy (Melee)]";
                    break;
                case 2:
                    ret += "Light (Ranged)]";
                    break;
                case 3:
                    ret += "Breathing (Magic)]";
                    break;
                default:
                    ret += "none]";
                    break;
            }
            return ret;
        }
        public bool IsDefault()
        {
            bool ret = false;
            if (_hp == 100) ret = true;
            else { return false; }
            if (_mana == 20) ret = true;
            else { return false; }
            if (_coins == 0) ret = true;
            else { return false; }
            if (SWORDLevel == 0) ret = true;
            else { return false; }
            if (GUNLevel == 0) ret = true;
            else { return false; }
            if (WANDLevel == 0) ret = true;
            else { return false; }
            if (ARMORLevel == 0) ret = true;
            else { return false; }
            if (ARMORType == 0) ret = true;
            else { return false; }
            return ret;
        }
    }
}
