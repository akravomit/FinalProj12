using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class EntryMonstersOfPlayerDB : BaseDB<Dictionary<string,object>>
    {
        protected override async Task<Dictionary<string, object>> CreateModelAsync(object[] row)
        {
            Dictionary<string,object> model = new Dictionary<string,object>();
            model.Add("EntryID", Convert.ToInt32(row[0]));
            model.Add("MonsterID", Convert.ToInt32(row[1]));
            model.Add("PlayerID", Convert.ToInt32(row[2]));
            model.Add("DateSlain", Convert.ToDateTime(row[3]));
            model.Add("TimesKilled", Convert.ToInt32(row[4]));
            //model.Add("MonsterID", Convert.ToInt32(row[5]));
            model.Add("Name", Convert.ToString(row[6]));
            model.Add("FilePath", Convert.ToString(row[7]));
            model.Add("HP", Convert.ToInt32(row[8]));
            model.Add("Defense", Convert.ToInt32(row[9]));
            model.Add("Description", Convert.ToString(row[10]));
            model.Add("Size", Convert.ToDouble(row[11]));
            model.Add("Rarity", Convert.ToInt32(row[12]));
            model.Add("IsBoss", Convert.ToInt32(row[13]));
            model.Add("MonsterElement", Convert.ToInt32(row[14]));
            model.Add("IsHidden", Convert.ToBoolean(row[15]));
            return model;
        }
        protected override string GetPrimaryKeyName()
        {
            return "id";
        }
        protected override string GetTableName()
        {
            return "game.entry";
        }
        public async Task<List<Dictionary<string,object>>> GetEntriesOfPlayer(Player p)
        {
            return await SelectAllAsync("SELECT * FROM game.entry etr JOIN monster m ON etr.MonsterID = m.id", new Dictionary<string, object> { { "PlayerID", p.id } });
        }
    }
    public class InventoryItemsOfPlayerDB : BaseDB<Dictionary<string, object>>
    {
        protected override async Task<Dictionary<string, object>> CreateModelAsync(object[] row)
        {
            Dictionary<string,object> model = new Dictionary<string,object>();
            model.Add("InventoryID", Convert.ToInt32(row[0]));
            model.Add("PlayerID", Convert.ToInt32(row[1]));
            model.Add("ItemID", Convert.ToInt32(row[2]));
            model.Add("Item_Level", Convert.ToInt32(row[3]));
            model.Add("Inv_IsHidden", Convert.ToBoolean(row[4]));
            model.Add("Amount", Convert.ToInt32(row[5]));
            //We skip row[6] because it is a duplicate of the ItemID
            model.Add("FilePath", Convert.ToString(row[7]));
            model.Add("Name", Convert.ToString(row[8]));
            model.Add("Description", Convert.ToString(row[9]));
            model.Add("Rarity", Convert.ToInt32(row[10]));
            model.Add("Value", Convert.ToInt32(row[11]));
            model.Add("ItemType", Convert.ToInt32(row[12]));
            model.Add("ItemIncrement", Convert.ToInt32(row[13]));
            model.Add("ItemElement", Convert.ToInt32(row[14]));
            model.Add("Itm_IsHidden", Convert.ToBoolean(row[15]));
            model.Add("MaxStack", Convert.ToInt32(row[16]));
            return model;
        }
        protected override string GetPrimaryKeyName()
        {
            return "id";
        }
        protected override string GetTableName()
        {
            return "game.inventory";
        }
        public async Task<List<Dictionary<string,object>>> GetInvOfPlayer(Player p)
        {
            return await SelectAllAsync("SELECT * FROM game.inventory inv RIGHT JOIN item i ON i.id = inv.ItemID", new Dictionary<string, object> { { "PlayerID", p.id } });
        }
    }
}
