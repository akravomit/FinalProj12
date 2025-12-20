using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DBL
{
    public class ElementDB : BaseDB<Element>
    {
        //Dictionary shenanigans
        private async Task<Element> DictToElement(Dictionary<string, object> dict)
        {
            Element ret = new Element();
            ret.id = Convert.ToInt32(dict["id"]);
            ret.name = Convert.ToString(dict["name"]);
            ret.StrongAgainst = Convert.ToInt32(dict["StrongAgainst"]);
            ret.WeakAgainst = Convert.ToInt32(dict["WeakAgainst"]);
            ret.StrongModifier = Convert.ToDouble(dict["StrongModifier"]);
            ret.WeakModifier = Convert.ToDouble(dict["WeakModifier"]);
            return ret;
        }
        private async Task<Dictionary<string, object>> ElementToDict(Element element)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>()
            {
                { "id", element.id },
                { "name", element.name },
                { "StrongAgainst", element.StrongAgainst },
                { "WeakAgainst", element.WeakAgainst },
                { "StrongModifier", element.StrongModifier },
                { "WeakModifier", element.WeakModifier }
            };
            return dict;
        }

        //overrides
        protected override async Task<List<Element>> CreateListModelAsync(List<object[]> rows)
        {
            List<Element> ret = new List<Element>();
            foreach (object[] row in rows) { ret.Add(await CreateModelAsync(row)); }
            return ret;
        }
        protected override string GetPrimaryKeyName()
        {
            return "id";
        }
        protected override string GetTableName()
        {
            return "users";
        }
        protected async override Task<Element> CreateModelAsync(object[] row)
        {
            Element element = new Element();
            element.id = Convert.ToInt32(row[0]);
            element.name = Convert.ToString(row[1]);
            element.StrongAgainst = Convert.ToInt32(row[2]);
            element.WeakAgainst = Convert.ToInt32(row[3]);
            element.StrongModifier = Convert.ToDouble(row[4]);
            element.WeakModifier = Convert.ToDouble(row[5]);
            return element;
        }

        //CRUD
        public async Task<List<Element>> GetAll() { return await SelectAllAsync(); } //Read all
        public async Task<List<Element>> GetByKey_Async(string keyname, object obj)
        {
            Dictionary<string, object> Where = new Dictionary<string, object>();
            Where.Add($"{keyname}", obj);
            List<Element> result = await SelectAllAsync(Where);
            if (result.Count == 0) return null;
            return result; //In case more are required/more exist with the same value
        } //Read only objects with a specific value in a specific column
        public async Task<Element> GetByPK(object val) 
        {
            List<Element> result = await GetByKey_Async(GetPrimaryKeyName(), val);
            if (result is null) return null;
            return result[0]; //Only one exists because PK is unique
        }
    }
}
