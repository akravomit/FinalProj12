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
        public int StrongAgainst { get; set; } //FK of element which the element overpowers
        public int WeakAgainst { get; set; } //FK of the element that overpowers this one

        //Both StrongAgainst and WeakAgainst are inspired the Feng Shui school of thought, specifically the interaction of elements.
        //It's the most intuitive way to balance things in my opinion.
        public double StrongModifier { get; set; } //Modifier of the element against the element it overpowers, damage dealt by this element towards the other
        public double WeakModifier { get; set; } //Modifier of the element against it is weak against, of the damage dealt from this element towards the one it is weak against.
        public bool isHidden { get; set; } //For deletion purposes
        public Element() { }
        public Element(string _name, int _strong, int _weak, double _strongMod, double _weakMod, bool IsHidden)
        {
            name = _name;
            StrongAgainst = _strong;
            WeakAgainst = _weak;
            StrongModifier = _strongMod;
            WeakModifier = _weakMod;
            isHidden = IsHidden;
        }
        public Element(int _id, string _name, int _strong, int _weak, double _strongMod, double _weakMod, bool IsHidden) : this (_name, _strong, _weak, _strongMod, _weakMod, IsHidden) { id = _id; }
        public Element (Element other) : this (other.id, other.name, other.StrongAgainst, other.WeakAgainst, other.StrongAgainst, other.WeakModifier, other.isHidden) { }
    }
}
