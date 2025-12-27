using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class AttackDB : BaseDB<Attack>
    {
        //Dictionaries
        //Dictionary key names must match the DB names perfectly
        private async Task<Attack> DictToAttack(Dictionary<string,object> dict)
        {
            Attack attack = new Attack();
            attack.id = Convert.ToInt32(dict["id"]);
            attack.filepath = Convert.ToString(dict["FilePath"]);
            attack.name = Convert.ToString(dict["Name"]);
            attack.damage = Convert.ToInt32(dict["Damage"]);
            attack.decay = Convert.ToInt32(dict["Decay"]);
            attack.decay_factor = Convert.ToDouble(dict["DecayFactor"]);
            attack.ElementID = Convert.ToInt32(dict["ElementID"]);
            attack.IsHidden = Convert.ToBoolean(dict["IsHidden"]);
            return attack;
        }
        private async Task<Dictionary<string,object>> AttackToDict(Attack attack)
        {
            Dictionary<string,object> dict = new Dictionary<string, object>() 
            {
                { "id", attack.id },
                { "FilePath", attack.filepath },
                { "Name", attack.name },
                { "Damage", attack.damage },
                { "Decay", attack.decay },
                { "DecayFactor", attack.decay_factor },
                { "Duration", attack.duration },
                { "ElementID", attack.ElementID },
                { "IsHidden", attack.IsHidden },
            };
            return dict;
        }

        //Overrides
        protected override async Task<Attack> CreateModelAsync(object[] row)
        {
            Attack attack = new Attack();
            attack.id = Convert.ToInt32(row[0]);
            attack.filepath = Convert.ToString(row[1]);
            attack.name = Convert.ToString(row[2]);
            attack.damage = Convert.ToInt32(row[3]);
            attack.decay = Convert.ToInt32(row[4]);
            attack.decay_factor = Convert.ToInt32(row[5]);
            attack.duration = Convert.ToInt32(row[6]);
            attack.ElementID = Convert.ToInt32(row[7]);
            attack.IsHidden = Convert.ToBoolean(row[8]);
            return attack;
        }
        protected override string GetPrimaryKeyName()
        { return "id"; }
        protected override string GetTableName()
        { return "game.attack"; }

        //CRUD
        public async Task<List<Attack>> GetAll ()
        { return await SelectAllAsync(); }
        //NEVER USE IN NORMAL CIRCUMSTANCES, INEFFICIENT.
        //THIS IS JUST IN CASE OF SPECIAL OCCASIONS
        public async Task<List<Attack>> GetByKey(string keyname, object val)
        {
            Dictionary<string,object> Where = new Dictionary<string,object>();
            Where.Add(keyname, val);
            List<Attack> result = await SelectAllAsync(Where);
            if (result is null) return null;
            return result;
        }
        //This is the preferred reading action, when there could be thousands of possible attacks
        public async Task<Attack> GetByUniqueKey(string keyname, object val)
        {
            List<Attack> result = await GetByKey(keyname, val);
            if (result is null || result.Count == 0) return null;
            return result[0];
        }
        //Returns the first result, if exists. Otherwise null.
        public async Task<Attack> InsertGetAttack (Attack attack)
        {
            return (await InsertGetObjAsync(await AttackToDict(attack))) as Attack;
        }
        //Inserts an attack to the DB, returns the object if successful
        public async Task<int> UpdateAttack(Attack post, Attack pre)
        {
            return await UpdateAsync(await AttackToDict(pre), await AttackToDict(post));
        }
        //Updates the attack in the DB
        public async Task<int> Delete(Attack attack)
        {
            Attack post = new Attack(attack);
            post.IsHidden = true;
            return await UpdateAttack(post, attack);
        }
        //"Deletes" an attack from the DB by setting it to be hidden
    }
}
