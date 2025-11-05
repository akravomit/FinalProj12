using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class EntryDB : BaseDB<Entry>
    {
        protected override string GetPrimaryKeyName()
        {
            return "id";
        }
        protected override string GetTableName() { return "gaem.catalog"; }
        protected override async Task<Entry> CreateModelAsync(object[] row)
        {
            Entry entry = new Entry();
            entry._id = (int)row[0];
            entry._name = (string)row[1];
            entry._monsterID = (int)row[2];
            entry._dateSlain = (string)row[3];
            entry._kills = (int)row[4];
            entry._playerfirstkill = (string)row[5];
            return entry;
        }
        public async Task<Entry> Insert(Entry entry, string password)
        {
            Dictionary<string, object> data = new Dictionary<string, object>()
            {
                { "id",entry._id },
                { "monsterName",entry._name },
                { "monsterID", entry._monsterID },
                { "killdate",  entry._dateSlain },
                { "killcount", entry._kills },
                { "playerfirstkill", entry._playerfirstkill },
            };
            return await InsertGetObjAsync(data) as Entry;
        }
        public async Task<List<Entry>> GetAll()
        {
            return await SelectAllAsync();
        }
        public async Task Update(Entry Old, Entry New)
        {
            Dictionary<string, object> Parameters = new Dictionary<string, object>()
            {
                { "id",Old._id },
                { "monsterName",Old._name },
                { "monsterID", Old._monsterID },
                { "killdate",  Old._dateSlain },
                { "killcount", Old._kills },
                { "playerfirstkill", Old._playerfirstkill },
            };
            Dictionary<string, object> FildValues = new Dictionary<string, object>()
            {
                { "id", New._id },
                { "monsterName",New._name },
                { "monsterID", New._monsterID },
                { "killdate",  New._dateSlain },
                { "killcount", New._kills },
                { "playerfirstkill", New._playerfirstkill },
            };
            await UpdateAsync(Parameters, FildValues);
        }
        public async Task<int> Delete(Entry entry)
        {
            Dictionary<string, object> data = new Dictionary<string, object>()
            {
                { "id",entry._id },
                { "monsterName",entry._name },
                { "monsterID", entry._monsterID },
                { "killdate",  entry._dateSlain },
                { "killcount", entry._kills },
                { "playerfirstkill", entry._playerfirstkill },
            };
            return await DeleteAsync(data);
        }
    }
}
