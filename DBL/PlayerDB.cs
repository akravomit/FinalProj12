using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class PlayerDB : BaseDB<Player>
    {
        private async Task<Player> DictToPlayer(Dictionary<string, object> dict)
        {
            Player ret = new Player();
            ret.id = Convert.ToInt32(dict["id"]);
            ret.name = Convert.ToString(dict["name"]);
            ret.hp = Convert.ToInt32(dict["HP"]);
            ret.mana = Convert.ToInt32(dict["Mana"]);
            ret.coins = Convert.ToInt32(dict["Coins"]);
            ret.is_hidden = Convert.ToBoolean(dict["IsHidden"]);
            ret.owner_id = Convert.ToInt32(dict["OwnerID"]);
            return ret;
        }
        private async Task<Dictionary<string, object>> PlayerToDict(Player player)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>()
            {
                { "name", player.name },
                { "HP", player.hp },
                { "Mana", player.mana },
                { "Coins", player.coins },
                { "IsHidden", player.is_hidden },
                { "OwnerID", player.owner_id }
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
            return "game.player";
        }
        protected override async Task<Player> CreateModelAsync(object[] row)
        {
            Player player = new Player();
            player.id = Convert.ToInt32(row[0]);
            player.name = Convert.ToString(row[1]);
            player.hp = Convert.ToInt32(row[2]);
            player.mana = Convert.ToInt32(row[3]);
            player.coins = Convert.ToInt32(row[4]);
            player.is_hidden = Convert.ToBoolean(row[5]);
            player.owner_id = Convert.ToInt32(row[6]);
            return player;
        }

        // CRUD
        public async Task<List<Player>> GetAllAsync()
        {
            return await SelectAllAsync();
        }
        public async Task<Player> GetByUniqueK(string keyname, object val)
        {
            List<Player> result = await GetByKey(keyname, val);
            if (result == null || result.Count == 0) return null;
            return result[0];
        }
        public async Task<List<Player>> GetByKey(string keyname, object obj)
        {
            Dictionary<string, object> where = new Dictionary<string, object>();
            where.Add(keyname, obj);
            List<Player> result = await SelectAllAsync(where);
            if (result.Count == 0) return null;
            return result;
        }
        public async Task<List<Player>> GetByKeys(Dictionary<string,object> where)
        {
            List<Player> result = await SelectAllAsync(where);
            if (result.Count is 0) return null;
            return result;
        }
        public async Task<Player> InsertGetPlayer(Player player)
        {
            if (await GetByKeys(new Dictionary<string, object>(){{"name",player.name},{"OwnerID",player.owner_id},{"IsHidden",false}}) is null)
            { return await InsertGetObjAsync(await PlayerToDict(player)) as Player; }
            else { return null; }
        }
        public async Task<int> Update_Async(Player pre, Player post)
        {
            return await UpdateAsync(await PlayerToDict(post), await PlayerToDict(pre));
        }
        public async Task<int> Delete_Async(Player pre)
        {
            Player post = new Player(pre);
            post.is_hidden = true;
            return await Update_Async(pre, post);
        }
        public async Task<int> Hard_Delete_Async(Dictionary<string, object> where)
        {
            return await DeleteAsync(where);
        }

        //Derivatives
        public async Task<List<Player>> GetByOwner(int ownerId)
        {
            Dictionary<string, object> where = new Dictionary<string, object>()
            {
                { "OwnerID", ownerId },
                { "IsHidden", false }
            };
            return await GetByKeys(where);
        }
        public async Task<List<Player>> GetVisible()
        {
            Dictionary<string, object> where = new Dictionary<string, object>()
            {
                { "IsHidden", false }
            };
            return await GetByKeys(where);
        }
    }
}
