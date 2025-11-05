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
        public int hp { get; set; }
        public int defence { get; set; }
        public string description { get; set; }
        public float size { get; set; }
        public int rarity { get; set; }
        public bool isboss { get; set; }
        public int attackid { get; set; }
        public int monsterelement { get; set; }
        public Monster() { }
        public Monster(int _id, string _name, int _hp, int _defence, string _description, float _size, int _rarity, bool _isboss, int _attackid, int _monsterelement)
        {
            id = _id;
            name = _name;
            hp = _hp;
            defence = _defence;
            description = _description;
            size = _size;
            rarity = _rarity;
            isboss = _isboss;
            attackid = _attackid;
            monsterelement = _monsterelement;
        }
        public Monster(Monster m)
        {
            id = m.id;
            name = m.name;
            hp = m.hp;
            defence = m.defence;
            description = m.description;
            size = m.size;
            rarity = m.rarity;
            isboss = m.isboss;
            attackid = m.attackid;
            monsterelement = m.monsterelement;
        }
    }
}
