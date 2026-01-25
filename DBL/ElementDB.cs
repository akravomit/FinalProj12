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
            ret.name = Convert.ToString(dict["Name"]);
            ret.StrongAgainst = Convert.ToInt32(dict["StrongAgainst"]);
            ret.WeakAgainst = Convert.ToInt32(dict["WeakAgainst"]);
            ret.StrongModifier = Convert.ToDouble(dict["StrongModifier"]);
            ret.WeakModifier = Convert.ToDouble(dict["WeakModifier"]);
            ret.isHidden = Convert.ToBoolean(dict["IsHidden"]);
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
                { "WeakModifier", element.WeakModifier },
                { "IsHidden", element.isHidden },
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
            return "game.element";
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
            element.isHidden = Convert.ToBoolean(row[6]);
            return element;
        }

        //CRUD
        
        public async Task<List<Element>> GetAll() { return await SelectAllAsync(); } 
        //Read all
        public async Task<List<Element>> GetByKey(string keyname, object obj)
        {
            Dictionary<string, object> Where = new Dictionary<string, object>();
            Where.Add($"{keyname}", obj);
            List<Element> result = await SelectAllAsync(Where);
            if (result.Count == 0) return null;
            return result; //In case more are required/more exist with the same value
        } 
        //Read only objects with a specific value in a specific column.
        //Returns a list of all that fit the requirements of the query.
        public async Task<Element> GetByUniqueK(string keyname, object val) 
        {
            List<Element> result = await GetByKey(keyname, val);
            if (result is null) return null;
            return result[0]; //Only one exists because PK is unique
        } 
        //Read by PK only.
        //Returns only one object, as the PK is either the ID of the element or the Name, both are unique.
        public async Task<Element> InsertGetElement (Element element)
        {
            Element res = (await InsertGetObjAsync(await ElementToDict(element))) as Element;
            if (res.WeakAgainst is not 0)
            {
                Element weaker = await GetByUniqueK(GetPrimaryKeyName(), element.StrongAgainst); Element weaker2 = new Element(weaker); //Advantageous over this element
                weaker.WeakAgainst = res.id; //Update the element
                await UpdateElement(weaker, weaker2); //Updates in the DB
            }
            if (res.StrongAgainst is not 0)
            {
                Element stronger = await GetByUniqueK(GetPrimaryKeyName(), element.WeakAgainst); Element stronger2 = new Element(stronger); //Disadvantageous over this element
                stronger.StrongAgainst = res.id; //Updates the element for DB update
                await UpdateElement(stronger, stronger2); //Updating the affected elements
            }
            return res;
        }
        //Create an element inside the DB. Return an Element if one was created, null indicates a bug.
        public async Task<int> UpdateElement (Element After, Element Before)
        {
            return await UpdateAsync(await ElementToDict(After), await ElementToDict(Before));
        }
        //Updates the Element and returns the row it is in. 0 indicates a bug.
        public async Task<int> DeleteElement(Element element)
        {
            Element After = new Element(element);
            After.isHidden = true; //"Deleting" the element

            Element WeakAgainst = await GetByUniqueK("WeakAgainst", element.id); //The element the given one is weak against, the next neighbor in the chain of element relations.
            Element StrongAgainst = await GetByUniqueK("StrongAgainst", element.id); //The element the given one is strong against, the previous neighbor in the chain.

            Element WeakAgainstNew = new Element(WeakAgainst); //Copies to update.
            Element StrongAgainstNew = new Element(StrongAgainst); //Copies to update.
            WeakAgainstNew.WeakAgainst = element.StrongAgainst;
            StrongAgainstNew.StrongAgainst = element.WeakAgainst;

            int result = await UpdateElement(After, element); //Try to update the element, only then update its neighbors in the chain.
            if (result == element.id | result != 0)
            {
                await UpdateElement(WeakAgainstNew, WeakAgainst);
                await UpdateElement(StrongAgainstNew, StrongAgainst);
            } //Updating the neighbors in the chain if the original element update was successful (if element exists as well)

            return result;
        }
        //Delete. (unfinished)
        //NEED TO FINISH IT BY UPDATING EVERYTHING ELSE THAT HAS THAT ELEMENT
    }
}
