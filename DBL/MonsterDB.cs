using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DBL
{
    public class MonsterDB : BaseDB<Monster>
    {
        protected override async Task<Monster> CreateModelAsync (object[] row)
        {
            Monster monster = new Monster();
            monster._id = (int)row[0];
            monster._name = (string)row[1];
            monster._HP = (int)row[2];
            monster._attacks = (string)row[3];
            monster._defence = (int)row[4];
            monster._description = (string)row[5];
            monster._size = (int)row[6];
            monster._rarity = (int)row[7];
            monster._isBoss = (int)row[8];
            return monster;
        }
        protected override string GetPrimaryKeyName()
        {
            return "id";
        }
        protected override string GetTableName()
        {
            return "gaem.monster";
        }
        public async Task<List<Monster>> GetAll()
        {
            return await SelectAllAsync();
        }
        public async Task<Monster> Insert(Monster monster, string password)
        {
            Dictionary<string, object> data = new Dictionary<string, object>()
            {
                { "id", monster._id },
                { "name", monster._name },
                { "hp", monster._HP },
                { "attacks", monster._attacks },
                { "defence", monster._defence },
                { "description", monster._description },
                { "size", monster._size },
                { "rarity", monster._rarity },
                { "isBoss", monster._isBoss }
            };
            return await InsertGetObjAsync(data) as Monster;
        }
        public async Task Update(Monster old, Monster New)
        {
            Dictionary<string, object> FildValue = new Dictionary<string, object>{
                { "id", old._id },
                { "name", old._name },
                { "hp", old._HP },
                { "attacks", old._attacks },
                { "defence", old._defence },
                { "description", old._description },
                { "size", old._size },
                { "rarity", old._rarity },
                { "isBoss", old._isBoss }
            };
            Dictionary<string, object> Parameters = new Dictionary<string, object>{
                { "id", New._id },
                { "name", New._name },
                { "hp", New._HP },
                { "attacks", New._attacks },
                { "defence", New._defence },
                { "description", New._description },
                { "size", New._size },
                { "rarity", New._rarity },
                { "isBoss", New._isBoss }
            };
            await UpdateAsync(Parameters, FildValue);
        }
        public async Task<int> Delete(Monster monster)
        {
            Dictionary<string, object> data = new Dictionary<string, object>()
            {
                { "id", monster._id },
                { "name", monster._name },
                { "hp", monster._HP },
                { "attacks", monster._attacks },
                { "defence", monster._defence },
                { "description", monster._description },
                { "size", monster._size },
                { "rarity", monster._rarity },
                { "isBoss", monster._isBoss }
            };
            return await DeleteAsync(data);
        }
    }
}
