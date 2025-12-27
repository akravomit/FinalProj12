using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class Item_Attacks_DB : BaseDB<Item_Attacks>
    {
        //Dingle dongle dictionaries
        private async Task<Item_Attacks> DictToItem_Attacks(Dictionary<string, object> dict)
        {
            Item_Attacks ret = new Item_Attacks();
            ret.id = Convert.ToInt32(dict["id"]);
            ret.ItemID = Convert.ToInt32(dict["ItemID"]);
            ret.AttackID = Convert.ToInt32(dict["AttackID"]);
            ret.IsHidden = Convert.ToBoolean(dict["IsHidden"]);
            return ret;
        }
        private async Task<Dictionary<string, object>> Item_AttacksToDict(Item_Attacks itemAttacks)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>()
            {
                { "id", itemAttacks.id },
                { "ItemID", itemAttacks.ItemID },
                { "AttackID", itemAttacks.AttackID },
                { "IsHidden", itemAttacks.IsHidden }
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
            return "item_attacks";
        }
        protected override async Task<Item_Attacks> CreateModelAsync(object[] row)
        {
            Item_Attacks itemAttacks = new Item_Attacks();
            itemAttacks.id = Convert.ToInt32(row[0]);
            itemAttacks.ItemID = Convert.ToInt32(row[1]);
            itemAttacks.AttackID = Convert.ToInt32(row[2]);
            itemAttacks.IsHidden = Convert.ToBoolean(row[3]);
            return itemAttacks;
        }

        // CRUD
        public async Task<List<Item_Attacks>> GetAllAsync()
        {
            return await SelectAllAsync();
        }
        public async Task<Item_Attacks> GetByUniqueK(string keyname, object val)
        {
            List<Item_Attacks> result = await GetByKey(keyname, val);
            if (result == null || result.Count == 0) return null;
            return result[0];
        }
        public async Task<List<Item_Attacks>> GetByKey(string keyname, object obj)
        {
            Dictionary<string, object> where = new Dictionary<string, object>();
            where.Add(keyname, obj);
            List<Item_Attacks> result = await SelectAllAsync(where);
            if (result.Count == 0) return null;
            return result;
        }
        public async Task<Item_Attacks> InsertGetAttack(Item_Attacks itemAttacks)
        {
            return await InsertGetObjAsync(await Item_AttacksToDict(itemAttacks)) as Item_Attacks;
        }
        public async Task<int> Update_Async(Item_Attacks pre, Item_Attacks post)
        {
            return await UpdateAsync(await Item_AttacksToDict(post), await Item_AttacksToDict(pre));
        }
        public async Task<int> Delete_Async(Item_Attacks pre)
        {
            Item_Attacks post = new Item_Attacks(pre);
            post.IsHidden = true;
            return await Update_Async(pre, post);
        }
        public async Task<List<Item_Attacks>> GetAttacksForItemAsync(int itemId)
        {
            Dictionary<string, object> where = new Dictionary<string, object>()
            {
                { "ItemID", itemId },
                { "IsHidden", false }
            };
            return await SelectAllAsync(where);
        }
    }
}
