using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class Item_Type_Name_DB : BaseDB<Item_Type_Name>
    {
        //Dictionaries
        private async Task<Item_Type_Name> DictToItem_Type_Name(Dictionary<string, object> dict)
        {
            Item_Type_Name ret = new Item_Type_Name();
            ret.id = Convert.ToInt32(dict["id"]);
            ret.type = Convert.ToInt32(dict["Type"]);
            ret.name = Convert.ToString(dict["Type_Name"]);
            ret.isHidden = Convert.ToBoolean(dict["IsHidden"]);
            return ret;
        }
        private async Task<Dictionary<string, object>> Item_Type_NameToDict(Item_Type_Name itemTypeName)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>()
            {
                { "id", itemTypeName.id },
                { "Type", itemTypeName.type },
                { "Type_Name", itemTypeName.name },
                { "IsHidden", itemTypeName.isHidden }
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
            return "game.item_type_name";
        }
        protected override async Task<Item_Type_Name> CreateModelAsync(object[] row)
        {
            Item_Type_Name itemTypeName = new Item_Type_Name();
            itemTypeName.id = Convert.ToInt32(row[0]);
            itemTypeName.type = Convert.ToInt32(row[1]);
            itemTypeName.name = Convert.ToString(row[2]);
            itemTypeName.isHidden = Convert.ToBoolean(row[3]);
            return itemTypeName;
        }

        // CRUD
        public async Task<List<Item_Type_Name>> GetAllAsync()
        {
            return await SelectAllAsync();
        }
        public async Task<Item_Type_Name> GetByUniqueK(string keyname, object val)
        {
            List<Item_Type_Name> result = await GetByKey(keyname, val);
            if (result == null || result.Count == 0) return null;
            return result[0];
        }
        public async Task<List<Item_Type_Name>> GetByKey(string keyname, object obj)
        {
            Dictionary<string, object> where = new Dictionary<string, object>();
            where.Add(keyname, obj);
            List<Item_Type_Name> result = await SelectAllAsync(where);
            if (result.Count == 0) return null;
            return result;
        }
        public async Task<Item_Type_Name> InsertGetItem_Type_Name(Item_Type_Name itemTypeName)
        {
            return await InsertGetObjAsync(await Item_Type_NameToDict(itemTypeName)) as Item_Type_Name;
        }
        public async Task<int> Update_Async(Item_Type_Name pre, Item_Type_Name post)
        {
            return await UpdateAsync(await Item_Type_NameToDict(post), await Item_Type_NameToDict(pre));
        }
        public async Task<int> Delete_Async(Item_Type_Name pre)
        {
            Item_Type_Name post = new Item_Type_Name(pre);
            post.isHidden = true;
            return await Update_Async(pre, post);
        }
    }
}
