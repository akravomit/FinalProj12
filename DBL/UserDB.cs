using Models;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class UserDB: BaseDB<User>
    {
        //Dictionary shenanigans
        private async Task<User> DictToUser (Dictionary<string,object> dict)
        {
            User ret = new User();
            ret.username = Convert.ToString(dict["username"]);
            ret.password = Convert.ToString(dict["password"]);
            ret.email = Convert.ToString(dict["email"]);
            ret.isadmin = Convert.ToBoolean(dict["isadmin"]);
            ret.ishidden = Convert.ToBoolean(dict["ishidden"]);
            return ret;
        }
        private async Task<Dictionary<string,object>> UserToDict(User user)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>()
                {
                    { "username", user.username },
                    { "password", user.password },
                    { "email", user.email },
                    { "isadmin", user.isadmin },
                    { "ishidden", user.ishidden },
                };
            return dict;
        }

        //Overrides
        protected override string GetPrimaryKeyName()
        {
            return "id";
        }
        protected override string GetTableName()
        {
            return "users";
        }
        protected async override Task<User> CreateModelAsync(object[] row)
        {
            User user = new User();
            user.id = Convert.ToInt32(row[0]);
            user.username = Convert.ToString(row[1]);
            user.password = Convert.ToString(row[2]);
            user.email = Convert.ToString(row[3]);
            user.isadmin = Convert.ToBoolean(row[4]);
            user.ishidden = Convert.ToBoolean(row[5]);
            return user;
        }

        //CRUD
        public async Task<List<User>> GetAllAsync()
        {
            return await SelectAllAsync();
        }
        public async Task<List<User>> GetByPK_Async(int id)
        {
            Dictionary<string, object> Where = new Dictionary<string, object>();
            Where.Add("id",id);
            List<User> result = await SelectAllAsync(Where);
            return result;
        }
        public async Task<User> GetByKey_Async(string keyname, object obj)
        {
            Dictionary<string, object> Where = new Dictionary<string, object>();
            Where.Add($"{keyname}", obj);
            List<User> result = await SelectAllAsync(Where);
            if (result.Count == 0) return null;
            return result[0]; //Because each user is unique, therefore the first object will always be the only one
        }
        public async Task<int> Insert_Async(User user, string password)
        {
            return await InsertAsync(await UserToDict(user));
        }
        public async Task<int> Update_Async(User pre, User post)
        {
            return await UpdateAsync(await UserToDict(post),await UserToDict(pre));
        }
        public async Task<int> Delete_Async(User pre, string password)
        {
            User post = new User(pre);
            post.ishidden = true;
            return await Update_Async(pre,post);
        }

        //Derivatives
        public async Task<string> Register_Async(User user,string password)
        {
            string message = string.Empty;
            bool ValidInsert = true;
            User Users = await GetByKey_Async("username",user.username);
            if (Users.username == user.username && !Users.ishidden)
            {
                message += "\nUsername already exists";
                ValidInsert = false;
            }
            Users = await GetByKey_Async("email",user.email);
            if (Users.email == user.email && !Users.ishidden)
            {
                message += "\nEmail already in use";
                ValidInsert = false;
            }

            if (ValidInsert)
            {
                await Insert_Async(user, password);
                message = "User inserted succesfully! Enjoy!";
            }
            return message;
        }
        public async Task<object> Login_Async(string username, string password)
        {
            Dictionary<string, object> ret = new Dictionary<string, object>();
            User user = await GetByKey_Async("username", username);

            //Failiure scenarios
            if (user == null)
            {
                ret.Add("Error: User not found!",404);
            }
            else if (user.password != username)
            {
                ret.Add("Error: Passwords do not match!",403);
            }
            else
            {
                ret.Add("Login successful! Enjoy!", await UserToDict(user));
            }

            //return
            return ret;
        }
    }
}
