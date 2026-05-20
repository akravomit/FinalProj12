using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class MonsterDB : BaseDB<Monster>
    {
        //Ding dong dictionaries
        private async Task<Monster> DictToMonster(Dictionary<string, object> dict)
        {
            Monster ret = new Monster();
            ret.id = Convert.ToInt32(dict["id"]);
            ret.name = Convert.ToString(dict["Name"]);
            ret.filepath = Convert.ToString(dict["FilePath"]);
            ret.hp = Convert.ToInt32(dict["HP"]);
            ret.defense = Convert.ToInt32(dict["Defense"]);
            ret.description = Convert.ToString(dict["Description"]);
            ret.size = Convert.ToDouble(dict["Size"]);
            ret.rarity = Convert.ToInt32(dict["Rarity"]);
            ret.isboss = Convert.ToInt32(dict["IsBoss"]);
            ret.monsterElement = Convert.ToInt32(dict["MonsterElement"]);
            ret.ishidden = Convert.ToBoolean(dict["IsHidden"]);
            return ret;
        }
        public async Task<Dictionary<string, object>> MonsterToDict(Monster monster)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>()
            {
                { "id", monster.id },
                { "Name", monster.name },
                { "FilePath", monster.filepath },
                { "HP", monster.hp },
                { "Defense", monster.defense },
                { "Description", monster.description },
                { "Size", monster.size },
                { "Rarity", monster.rarity },
                { "IsBoss", monster.isboss },
                { "MonsterElement", monster.monsterElement },
                { "IsHidden", monster.ishidden }
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
            return "game.monster";
        }
        protected override async Task<Monster> CreateModelAsync(object[] row)
        {
            Monster monster = new Monster();
            monster.id = Convert.ToInt32(row[0]);
            monster.name = Convert.ToString(row[1]);
            monster.filepath = Convert.ToString(row[2]);
            monster.hp = Convert.ToInt32(row[3]);
            monster.defense = Convert.ToInt32(row[4]);
            monster.description = Convert.ToString(row[5]);
            monster.size = Convert.ToDouble(row[6]);
            monster.rarity = Convert.ToInt32(row[7]);
            monster.isboss = Convert.ToInt32(row[8]);
            monster.monsterElement = Convert.ToInt32(row[9]);
            monster.ishidden = Convert.ToBoolean(row[10]);
            return monster;
        }

        // CRUD
        public async Task<List<Monster>> GetAllAsync()
        {
            return await SelectAllAsync();
        }
        public async Task<Monster> GetByUniqueK(string keyname, object val)
        {
            List<Monster> result = await GetByKey(keyname, val);
            if (result == null || result.Count == 0) return null;
            return result[0];
        }
        public async Task<List<Monster>> GetByKey(string keyname, object obj)
        {
            Dictionary<string, object> where = new Dictionary<string, object>();
            where.Add($"{keyname}", obj);
            List<Monster> result = await SelectAllAsync(where);
            if (result.Count == 0) return null;
            return result;
        }
        public async Task<List<Monster>> GetByKeys(Dictionary<string, object> keys)
        {
            List<Monster> result = await SelectAllAsync(keys);
            if (result.Count == 0) return null;
            return result;
        }
        public async Task<Monster> InsertGetMonster(Monster monster)
        {
            return await InsertGetObjAsync(await MonsterToDict(monster)) as Monster;
        }
        public async Task<int> Update_Async(Monster pre, Monster post)
        {
            return await UpdateAsync(await MonsterToDict(post), await MonsterToDict(pre));
        }
        public async Task<int> Delete_Async(Monster pre)
        {
            return await DeleteAsync(await MonsterToDict(pre));
        }
        public async Task<Monster> GetRandomMonster(int LastMonster = 0)
        {
            return (await SelectAllAsync($"SELECT * FROM game.monster WHERE IsHidden = 0 AND id != {LastMonster} ORDER BY RAND() LIMIT 0,1;"))[0];
        }
    }
}
