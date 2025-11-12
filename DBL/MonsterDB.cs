using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DBL
{
    public class MonsterDB : BaseDB<Monster>
    {
        protected override async Task<Monster> CreateModelAsync (object[] row)
        {
            throw new NotImplementedException();
        }
        protected override string GetPrimaryKeyName()
        {
            return "id";
        }
        protected override string GetTableName()
        {
            return "gaem.monster";
        }
        public async Task<List<Monster>> GetAll()
        {
            return await SelectAllAsync();
        }
    }
}
