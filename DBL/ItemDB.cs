using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class ItemDB : BaseDB<Item>
    {
        //Dictionary shenanigans
        private async Task<Item> DictToItem(Dictionary<string, object> dict)
        {
            Item ret = new Item();
            ret.id = Convert.ToInt32(dict["id"]);
            ret.filepath = Convert.ToString(dict["FilePath"]);
            ret.name = Convert.ToString(dict["Name"]);
            ret.description = Convert.ToString(dict["Description"]);
            ret.rarity = Convert.ToInt32(dict["Rarity"]);
            ret.value = Convert.ToInt32(dict["Value"]);
            ret.item_type = Convert.ToInt32(dict["ItemType"]);
            ret.item_increment = Convert.ToInt32(dict["ItemIncrement"]);
            ret.element_id = Convert.ToInt32(dict["ElementID"]);
            ret.is_hidden = Convert.ToBoolean(dict["IsHidden"]);
            return ret;
        }
        private async Task<Dictionary<string, object>> ItemToDict(Item item)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>()
            {
                { "id", item.id },
                { "FilePath", item.filepath },
                { "Name", item.name },
                { "Description", item.description },
                { "Rarity", item.rarity },
                { "Value", item.value },
                { "ItemType", item.item_type },
                { "ItemIncrement", item.item_increment },
                { "ElementID", item.element_id },
                { "IsHidden", item.is_hidden }
            };
            return dict;
        }

        // Overrides
        protected override string GetPrimaryKeyName() { return "id"; }
        protected override string GetTableName() { return "items"; }
        protected override async Task<Item> CreateModelAsync(object[] row)
        {
            Item item = new Item();
            item.id = Convert.ToInt32(row[0]);
            item.filepath = Convert.ToString(row[1]);
            item.name = Convert.ToString(row[2]);
            item.description = Convert.ToString(row[3]);
            item.rarity = Convert.ToInt32(row[4]);
            item.value = Convert.ToInt32(row[5]);
            item.item_type = Convert.ToInt32(row[6]);
            item.item_increment = Convert.ToInt32(row[7]);
            item.element_id = Convert.ToInt32(row[8]);
            item.is_hidden = Convert.ToBoolean(row[9]);
            return item;
        }

        // CRUD
        public async Task<List<Item>> GetAllAsync()
        {
            return await SelectAllAsync();
        }
        public async Task<Item> GetByUniqueK(string keyname, object val)
        {
            List<Item> result = await GetByKey(keyname, val);
            if (result == null || result.Count == 0) return null;
            return result[0];
        }
        public async Task<List<Item>> GetByKey(string keyname, object obj)
        {
            Dictionary<string, object> where = new Dictionary<string, object>();
            where.Add(keyname, obj);
            List<Item> result = await SelectAllAsync(where);
            if (result.Count == 0) return null;
            return result;
        }
        public async Task<Item> InsertGetItem(Item item)
        {
            return await InsertGetObjAsync(await ItemToDict(item)) as Item;
        }
        public async Task<int> Update_Async(Item pre, Item post)
        {
            return await UpdateAsync(await ItemToDict(post), await ItemToDict(pre));
        }
        public async Task<int> Delete_Async(Item pre)
        {
            Item post = new Item(pre);
            post.is_hidden = true;
            return await Update_Async(pre, post);
        }
        public async Task<List<Item>> GetVisibleItemsAsync()
        {
            Dictionary<string, object> where = new Dictionary<string, object>()
            {
                { "IsHidden", false }
            };
            return await SelectAllAsync(where);
        }
        //Instead of getall
    }
}
