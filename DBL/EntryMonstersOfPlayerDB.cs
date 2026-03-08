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
        public async Task<Dictionary<string,object>> AddEntryToList(Entry e, Monster m)
        {
            object[] row = new object[16];
            row[0] = e.id;
            row[1] = e.monster_id;
            row[2] = e.player_id;
            row[3] = e.date_slain;
            row[4] = e.times_killed;
            row[5] = m.id;
            row[6] = m.name;
            row[7] = m.filepath;
            row[8] = m.hp;
            row[9] = m.defense;
            row[10] = m.description;
            row[11] = m.size;
            row[12] = m.rarity;
            row[13] = m.isboss;
            row[14] = m.monsterElement;
            row[15] = m.ishidden;
            return await CreateModelAsync(row);
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
    public class AttacksOfItemByItemID : BaseDB<Dictionary<string, object>>
    {
        protected override async Task<Dictionary<string, object>> CreateModelAsync(object[] row)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            model.Add("Id", row[0]);
            model.Add("ItemID", row[1]);
            model.Add("AttackID", row[2]);
            model.Add("AttackIncrement", row[3]);
            //model.Add("IsHidden", row[4]);
            //model.Add("AttackID", row[5]);
            model.Add("FilePath", row[6]);
            model.Add("Name", row[7]);
            model.Add("Damage", row[8]);
            model.Add("Decay", row[9]);
            model.Add("DecayFactor", row[10]);
            model.Add("Duration", row[11]);
            model.Add("ElementID", row[12]);
            model.Add("IsHidden", row[13]);
            return model;
        }
        protected override string GetPrimaryKeyName()
        {
            return "id";
        }
        protected override string GetTableName()
        {
            return "item_attacks";
        }
        public async Task<List<Dictionary<string, object>>> GetAttacksOfItemByItemID(int itmid) 
        {
            return await SelectAllAsync("SELECT * FROM item_attacks iatk JOIN game.attack atk ON atk.id = iatk.AttackID", new Dictionary<string, object> {{ "iatk.ItemID", itmid }});
        }
    }
}
