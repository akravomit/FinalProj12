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
        //Dictionary key names must match the DB names perfectly
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
        public async Task<User> GetByUniqueK(string keyname, object val)
        {
            List<User> result = await GetByKey(keyname, val);
            if (result == null) return null;
            return result[0];
        }
        //Returns the first user with the matching given value in the matching given column. Only for use with ID or Names, nothing more.
        //Derivative of GetByKey, so returns null of nothing was found.
        public async Task<List<User>> GetByKey(string keyname, object obj)
        {
            Dictionary<string, object> Where = new Dictionary<string, object>();
            Where.Add($"{keyname}", obj);
            List<User> result = await SelectAllAsync(Where);
            if (result.Count == 0) return null;
            return result;
        } 
        //Returns all Users with the matching given value in the matching given column.
        //If there are none, null is returned.
        public async Task<List<User>> GetByKeys(Dictionary<string,object> where)
        {
            List<User> result = await SelectAllAsync(where);
            if (result.Count == 0) return null;
            return result;
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
        public async Task<object> Register_Async(User user,string password)
        {
            string message = string.Empty;
            bool ValidInsert = true;
            User Users = await GetByUniqueK("username",user.username);
            if (Users is null)
            {
                await Insert_Async(user, password);
                message = "User inserted succesfully! Enjoy!";
                return user;
            }
            else
            {
                if (Users.username == user.username && !Users.ishidden)
                {
                    message += "\nUsername already exists";
                    ValidInsert = false;
                }
                if (Users.email == user.email && !Users.ishidden)
                {
                    message += "\nEmail already in use";
                    ValidInsert = false;
                }
            }
            return message;
        }
        public async Task<object> Login_Async(User user)
        {
            return await Login_Async_Username(user.username, user.password);
        } //Extra argument just in case the function takes a user
        public async Task<object> Login_Async_Username(string username, string password)
        {
            string ret = string.Empty;
            User user = new User();
            bool ValidLogin = true;
            if (!string.IsNullOrEmpty(username)) { user = await GetByUniqueK("username", username); }
            else { return null; }
            if (user is null) { return null; }
            else
            {
                //Failiure scenarios
                if (username == "Jungelist" || username == "jungelist")
                {
                    ret = "ERROR: ALPHA-NOVEMBER-DELTA| TANGO-HOTEL-ECHO| SIERRA-TANGO-ALPHA-ROMEO-SIERRA| ALPHA-ROMEO-ECHO| BRAVO-LIMA-ECHO-ECHO-DELTA-INDIA-NOVEMBER-GOLF| TANGO-HOTEL-ECHO| SIERRA-TANGO-ALPHA-ROMEO-SIERRA| ALPHA-ROMEO-ECHO| BRAVO-LIMA-ECHO-ECHO-DELTA-INDIA-NOVEMBER-GOLF| TANGO-HOTEL-ECHO| SIERRA-TANGO-ALPHA-ROMEO-SIERRA| ALPHA-ROMEO-ECHO| BRAVO-LIMA-ECHO-ECHO-DELTA-INDIA-NOVEMBER-GOLF| TANGO-HOTEL-ECHO| SIERRA-TANGO-ALPHA-ROMEO-SIERRA| ALPHA-ROMEO-ECHO| BRAVO-LIMA-ECHO-ECHO-DELTA-INDIA-NOVEMBER-GOLF| TANGO-HOTEL-ECHO| SIERRA-TANGO-ALPHA-ROMEO-SIERRA| ALPHA-ROMEO-ECHO| BRAVO-LIMA-ECHO-ECHO-DELTA-INDIA-NOVEMBER-GOLF\nDENIED ACCESS. YOU ARE NOT THE FEED. THE FEED GETS ACESS TO SEEING ITSELF. DENIED ACCESS. DENIED ACESS. <o>  <o>  <o>  <o>  <o>  <o>  <o> ";
                    return ret;
                } //Dw bout it sweetheart
                if (!user.ishidden)
                {
                    if (user.password != password)
                    {
                        ret += "\nError: Passwords do not match!";
                        ValidLogin = false;
                    }
                }
                else
                {
                    ret += "This user does not exist!";
                    ValidLogin = false;
                }
                if (ValidLogin)
                {
                    return user;
                }
                else
                {
                    return ret;
                }
            }
        }
        public async Task<object> Login_Async_Email(string email, string password)
        {
            string ret = string.Empty;
            User user = new User();
            bool ValidLogin = true;
            if (!string.IsNullOrEmpty(email)) { user = await GetByUniqueK("email", email); }
            else { return null; }
            if (user is null) { return null; }
            else
            {
                //Failiure scenarios
                if (email == "Jungelist" || password == "The Stars Bleed")
                {
                    ret = "ERROR: ALPHA-NOVEMBER-DELTA| TANGO-HOTEL-ECHO| SIERRA-TANGO-ALPHA-ROMEO-SIERRA| ALPHA-ROMEO-ECHO| BRAVO-LIMA-ECHO-ECHO-DELTA-INDIA-NOVEMBER-GOLF| TANGO-HOTEL-ECHO| SIERRA-TANGO-ALPHA-ROMEO-SIERRA| ALPHA-ROMEO-ECHO| BRAVO-LIMA-ECHO-ECHO-DELTA-INDIA-NOVEMBER-GOLF| TANGO-HOTEL-ECHO| SIERRA-TANGO-ALPHA-ROMEO-SIERRA| ALPHA-ROMEO-ECHO| BRAVO-LIMA-ECHO-ECHO-DELTA-INDIA-NOVEMBER-GOLF| TANGO-HOTEL-ECHO| SIERRA-TANGO-ALPHA-ROMEO-SIERRA| ALPHA-ROMEO-ECHO| BRAVO-LIMA-ECHO-ECHO-DELTA-INDIA-NOVEMBER-GOLF| TANGO-HOTEL-ECHO| SIERRA-TANGO-ALPHA-ROMEO-SIERRA| ALPHA-ROMEO-ECHO| BRAVO-LIMA-ECHO-ECHO-DELTA-INDIA-NOVEMBER-GOLF\nDENIED ACCESS. YOU ARE NOT THE FEED. THE FEED GETS ACESS TO SEEING ITSELF. DENIED ACCESS. DENIED ACESS. <o>  <o>  <o>  <o>  <o>  <o>  <o> ";
                    return ret;
                } //Dw bout it sweetheart
                if (!user.ishidden)
                {
                    if (user.email != email)
                    {
                        ret += "\nError: Emails do not match!";
                        ValidLogin = false;
                    }
                }
                else
                {
                    ret += "This user does not exist!";
                    ValidLogin = false;
                }
                if (ValidLogin)
                {
                    return user;
                }
                else
                {
                    return ret;
                }
            }
        }
    }
}
