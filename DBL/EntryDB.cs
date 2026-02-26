using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class EntryDB : BaseDB<Entry>
    {
        // Dictionary conversions
        private async Task<Entry> DictToEntry(Dictionary<string, object> dict)
        {
            Entry ret = new Entry();
            ret.id = Convert.ToInt32(dict["id"]);
            ret.monster_id = Convert.ToInt32(dict["MonsterID"]);
            ret.player_id = Convert.ToInt32(dict["PlayerID"]);
            ret.date_slain = Convert.ToDateTime(dict["DateSlain"]);
            ret.times_killed = Convert.ToInt32(dict["TimesKilled"]);
            return ret;
        }
        private async Task<Dictionary<string, object>> EntryToDict(Entry entry)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>()
            {
                { "id", entry.id },
                { "MonsterID", entry.monster_id },
                { "PlayerID", entry.player_id },
                { "DateSlain", entry.date_slain },
                { "TimesKilled", entry.times_killed }
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
            return "game.entry";
        }
        protected override async Task<Entry> CreateModelAsync(object[] row)
        {
            Entry entry = new Entry();
            entry.id = Convert.ToInt32(row[0]);
            entry.monster_id = Convert.ToInt32(row[1]);
            entry.player_id = Convert.ToInt32(row[2]);
            entry.date_slain = Convert.ToDateTime(row[3]);
            entry.times_killed = Convert.ToInt32(row[4]);
            return entry;
        }

        // CRUD
        public async Task<List<Entry>> GetAllAsync()
        {
            return await SelectAllAsync();
        }
        public async Task<List<Entry>> GetByKeys(Dictionary<string,object> Where)
        {
            List<Entry> result = await SelectAllAsync(Where);
            if (result.Count == 0) return null;
            return result;
        }
        public async Task<Entry> InsertGetEntry(Entry entry)
        {
            entry.date_slain = DateTime.UtcNow; //It happened with extremely low delay between the user and server, so now is used
            entry.times_killed = 1; //First entry, so killed is always one
            return await InsertGetObjAsync(await EntryToDict(entry)) as Entry;
        }
        public async Task<int> Update_Async(Entry pre, Entry post)
        {
            return await UpdateAsync(await EntryToDict(post), await EntryToDict(pre));
        }
        public async Task<Entry> IncrementEntry(Entry pre)
        {
            Entry post = new Entry(pre);
            post.times_killed++;
            await Update_Async(pre, post);
            return post;
        } //Auto-updates the killcount, adding 1 to times killed as another mosnter of that type was slain
        public async Task<Entry> RegisterEntry(Player owner, Monster victim)
        {
            List<Entry> result = await GetByKeys(new Dictionary<string, object>() { { "MonsterID", victim.id }, { "PlayerID", owner.id } });
            if (result is null) { return await InsertGetEntry(new Entry(victim.id, owner.id)); }
            else { return await IncrementEntry(result[0]); }
        }
        public async Task<List<Entry>> GetByPlayer(Player p)
        {
            return await GetByKeys(new Dictionary<string, object> { { "PlayerID" , p.id } });
        }
    }
}
