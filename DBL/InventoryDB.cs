using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class InventoryDB : BaseDB<Inventory>
    {
        private async Task<Inventory> DictToInventory(Dictionary<string, object> dict)
        {
            Inventory ret = new Inventory();
            ret.Id = Convert.ToInt32(dict["id"]);
            ret.PlayerID = Convert.ToInt32(dict["PlayerID"]);
            ret.ItemID = Convert.ToInt32(dict["ItemID"]);
            ret.Item_level = Convert.ToInt32(dict["ItemLevel"]);
            ret.IsHidden = Convert.ToBoolean(dict["IsHidden"]);
            return ret;
        }

        private async Task<Dictionary<string, object>> InventoryToDict(Inventory inventory)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>()
            {
                { "id", inventory.Id },
                { "PlayerID", inventory.PlayerID },
                { "ItemID", inventory.ItemID },
                { "ItemLevel", inventory.Item_level },
                { "IsHidden", inventory.IsHidden }
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
            return "game.inventory";
        }
        protected override async Task<Inventory> CreateModelAsync(object[] row)
        {
            Inventory inventory = new Inventory();
            inventory.Id = Convert.ToInt32(row[0]);
            inventory.PlayerID = Convert.ToInt32(row[1]);
            inventory.ItemID = Convert.ToInt32(row[2]);
            inventory.Item_level = Convert.ToInt32(row[3]);
            inventory.IsHidden = Convert.ToBoolean(row[4]);
            return inventory;
        }

        // CRUD
        public async Task<List<Inventory>> GetAllAsync()
        {
            return await SelectAllAsync();
        }
        public async Task<Inventory> GetByUniqueK(string keyname, object val)
        {
            List<Inventory> result = await GetByKey(keyname, val);
            if (result == null || result.Count == 0) return null;
            return result[0];
        }
        public async Task<List<Inventory>> GetByKey(string keyname, object obj)
        {
            Dictionary<string, object> where = new Dictionary<string, object>();
            where.Add(keyname, obj);
            List<Inventory> result = await SelectAllAsync(where);
            if (result.Count == 0) return null;
            return result;
        }
        public async Task<Inventory> Insert_Async(Inventory inventory)
        {
            return await InsertGetObjAsync(await InventoryToDict(inventory)) as Inventory;
        }
        public async Task<int> Update_Async(Inventory pre, Inventory post)
        {
            return await UpdateAsync(await InventoryToDict(post), await InventoryToDict(pre));
        }
        public async Task<int> Delete_Async(Inventory pre)
        {
            Inventory post = new Inventory(pre);
            post.IsHidden = true;
            return await Update_Async(pre, post);
        }
        //AI knows what's up with this one
        // Optional: Get all non-hidden items for a specific player
        public async Task<List<Inventory>> GetByPlayerAsync(int playerId)
        {
            Dictionary<string, object> where = new Dictionary<string, object>()
            {
                { "PlayerID", playerId },
                { "IsHidden", false }
            };
            return await SelectAllAsync(where);
        }
    }
}
