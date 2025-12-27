using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class Monster_Attacks_DB : BaseDB<Monster_Attacks>
    {
        //Dictionaries
        private async Task<Monster_Attacks> DictToMonster_Attacks(Dictionary<string, object> dict)
        {
            Monster_Attacks ret = new Monster_Attacks();
            ret.id = Convert.ToInt32(dict["id"]);
            ret.monsterId = Convert.ToInt32(dict["MonsterID"]);
            ret.attackId = Convert.ToInt32(dict["AttackID"]);
            ret.attack_Increment = Convert.ToInt32(dict["Attack_Increment"]);
            ret.isHidden = Convert.ToBoolean(dict["IsHidden"]);
            return ret;
        }
        private async Task<Dictionary<string, object>> Monster_AttacksToDict(Monster_Attacks monsterAttacks)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>()
            {
                { "id", monsterAttacks.id },
                { "MonsterID", monsterAttacks.monsterId },
                { "AttackID", monsterAttacks.attackId },
                { "Attack_Increment", monsterAttacks.attack_Increment },
                { "IsHidden", monsterAttacks.isHidden }
            };
            return dict;
        }

        // Overrides
        protected override string GetPrimaryKeyName()
        {
            return "id";
        }
        protected override string GetTableName()
        {
            return "game.monster_attacks";
        }
        protected override async Task<Monster_Attacks> CreateModelAsync(object[] row)
        {
            Monster_Attacks monsterAttacks = new Monster_Attacks();
            monsterAttacks.id = Convert.ToInt32(row[0]);
            monsterAttacks.monsterId = Convert.ToInt32(row[1]);
            monsterAttacks.attackId = Convert.ToInt32(row[2]);
            monsterAttacks.attack_Increment = Convert.ToInt32(row[3]);
            monsterAttacks.isHidden = Convert.ToBoolean(row[4]);
            return monsterAttacks;
        }

        // CRUD
        public async Task<List<Monster_Attacks>> GetAllAsync()
        {
            return await SelectAllAsync();
        }
        public async Task<Monster_Attacks> GetByUniqueK(string keyname, object val)
        {
            List<Monster_Attacks> result = await GetByKey(keyname, val);
            if (result == null || result.Count == 0) return null;
            return result[0];
        }
        public async Task<List<Monster_Attacks>> GetByKey(string keyname, object obj)
        {
            Dictionary<string, object> where = new Dictionary<string, object>();
            where.Add(keyname, obj);
            List<Monster_Attacks> result = await SelectAllAsync(where);
            if (result.Count == 0) return null;
            return result;
        }
        public async Task<Monster_Attacks> InsertGetMonster_Attacks(Monster_Attacks monsterAttacks)
        {
            return await InsertGetObjAsync(await Monster_AttacksToDict(monsterAttacks)) as Monster_Attacks;
        }
        public async Task<int> Update_Async(Monster_Attacks pre, Monster_Attacks post)
        {
            return await UpdateAsync(await Monster_AttacksToDict(post), await Monster_AttacksToDict(pre));
        }
        public async Task<int> Delete_Async(Monster_Attacks pre)
        {
            Monster_Attacks post = new Monster_Attacks(pre);
            post.isHidden = true;
            return await Update_Async(pre, post);
        }
    }
}
