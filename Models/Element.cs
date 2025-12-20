using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Element
    {
        public int id { get; set; }
        public string name { get; set; }
        public int StrongAgainst { get; set; }
        public int WeakAgainst { get; set; }
        public double StrongModifier { get; set; }
        public double WeakModifier { get; set; }
        public Element() { }
        public Element(string _name, int _strong, int _weak, double _strongMod, double _weakMod)
        {
            name = _name;
            StrongAgainst = _strong;
            WeakAgainst = _weak;
            StrongModifier = _strongMod;
            WeakModifier = _weakMod;
        }
        public Element(int _id, string _name, int _strong, int _weak, double _strongMod, double _weakMod) : this (_name, _strong, _weak, _strongMod, _weakMod)
        {
            id = _id;
        }
    }
}
