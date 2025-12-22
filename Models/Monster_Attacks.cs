using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Monster_Attacks
    {
        public int id { get; set; }
        public int monsterId { get; set; } //FK -> Monster
        public int attackId { get; set; } //FK -> Attack
        public int attack_Increment { get; set; } //Attack multiplier, monster-specific
        public Monster_Attacks() { }
        public Monster_Attacks(int MonsterID, int AttackID, int Attack_Increment) 
        {
            monsterId = MonsterID;
            attackId = AttackID;
            attack_Increment = Attack_Increment;
        }
        public Monster_Attacks(int Id, int monsterId, int attackId, int attack_Increment) : this(monsterId, attackId, attack_Increment)
        {
            id = Id;
        }
        public Monster_Attacks (Monster_Attacks other) : this (other.id, other.monsterId, other.attackId, other.attack_Increment) { }
    }
}
