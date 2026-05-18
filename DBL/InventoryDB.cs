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
            ret.Id = Convert.ToInt32(dict["InventoryID"].ToString());
            ret.PlayerID = Convert.ToInt32(dict["PlayerID"].ToString());
            ret.ItemID = Convert.ToInt32(dict["ItemID"].ToString());
            ret.Item_level = Convert.ToInt32(dict["Item_Level"].ToString());
            ret.IsHidden = Convert.ToBoolean(dict["Inv_IsHidden"].ToString());
            ret.Amount = Convert.ToInt32(dict["Amount"].ToString());
            return ret;
        }

        private async Task<Dictionary<string, object>> InventoryToDict(Inventory inventory)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>()
            {
                { "id", inventory.Id },
                { "PlayerID", inventory.PlayerID },
                { "ItemID", inventory.ItemID },
                { "Item_Level", inventory.Item_level },
                { "IsHidden", inventory.IsHidden },
                { "Amount", inventory.Amount},
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
            inventory.Amount = Convert.ToInt32(row[5]);
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
            return await DeleteAsync(await InventoryToDict(pre));
        }
        public async Task<int> Hard_Delete_Async(Dictionary<string, object> where)
        {
            return await DeleteAsync(where);
        }

        public async Task UseItem(Inventory item)
        {
            //UPDATE `game`.`inventory` SET `Amount` = '68' WHERE (`id` = '3');
            if (item.Amount > 0)
            {
                Inventory post = new Inventory(item);
                post.Amount--;
                await Update_Async(item, post);
            }
            else
            {
                await Delete_Async(item);
            }
        }
        public async Task UseItem(Dictionary<string,object> item)
        {
            Inventory inv = await DictToInventory(item);
            if (inv.Amount > 0)
            {
                Inventory post = new Inventory(inv);
                post.Amount--;
                await Update_Async(inv, post);
            }
            else
            {
                await Delete_Async(inv);
            }
        }
    }
}
