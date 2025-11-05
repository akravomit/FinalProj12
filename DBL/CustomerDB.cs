using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class CustomerDB : BaseDB<Player>
    {
        protected override async Task<Player> CreateModelAsync(object[] row)
        {
            Player player = new Player();
            player._id = int.Parse(row[0].ToString());
            player._name = row[1].ToString();
            player._hp = int.Parse(row[2].ToString());
            player._mana = int.Parse(row[3].ToString());
            player._coins = int.Parse(row[4].ToString());
            player.SWORDLevel = (int)row[5];
            player.GUNLevel = (int)row[6];
            player.WANDLevel = (int)row[7];
            player.ARMORLevel = (int)row[8];
            player.ARMORType = (int)row[9];
            return player;
        }
        protected override string GetPrimaryKeyName()
        {
            return "id";
        }
        protected override string GetTableName()
        {
            return "gaem.player";
        }
        public async Task<List<Player>> GetAll()
        {
            return await SelectAllAsync();
        }
        public async Task<Player> Insert(Player player, string password)
        {
            Dictionary<string,object> data = new Dictionary<string, object>()
            {
                { "id",player._id},
                { "name",player._name},
                { "hp",100 },
                { "mana", 20 },
                { "coins", 0 },
                { "swordlevel", 0 },
                { "gunlevel", 0 },
                { "wandlevel", 0 },
                { "armorlevel", 0 },
                { "armortype", 0 }
            };
            return await InsertGetObjAsync(data) as Player;
        }
        public async Task Update(Player player, Player New)
        {
            Dictionary<string, object> FildValue = new Dictionary<string, object>{
                { "id",player._id},
                { "name",player._name},
                { "hp",player._hp },
                { "mana", player._mana },
                { "coins", player._coins },
                { "swordlevel", player.SWORDLevel },
                { "gunlevel", player.GUNLevel },
                { "wandlevel", player.WANDLevel },
                { "armorlevel", player.ARMORLevel },
                { "armortype", player.ARMORType }
            };
            Dictionary<string, object> Parameters = new Dictionary<string, object>{
                { "id",New._id},
                { "name",New._name},
                { "hp",New._hp },
                { "mana", New._mana },
                { "coins", New._coins },
                { "swordlevel", New.SWORDLevel },
                { "gunlevel", New.GUNLevel },
                { "wandlevel", New.WANDLevel },
                { "armorlevel", New.ARMORLevel },
                { "armortype", New.ARMORType }
            };
            await UpdateAsync(Parameters, FildValue);
        }
        public async Task<int> Delete(Player player)
        {
            Dictionary<string, object> par = await PrepareDictionaryAsync(player);
            return await DeleteAsync(par);
        }
        private static async Task<Dictionary<string,object>> PrepareDictionaryAsync(Player player)
        {
            Dictionary<string,object> ret = new Dictionary<string, object>
            {
                { "id",player._id},
                { "name",player._name},
                { "hp",player._hp },
                { "mana", player._mana },
                { "coins", player._coins },
                { "swordlevel", player.SWORDLevel },
                { "gunlevel", player.GUNLevel },
                { "wandlevel", player.WANDLevel },
                { "armorlevel", player.ARMORLevel },
                { "armortype", player.ARMORType }
            };
            return ret;
        }
    }
}
