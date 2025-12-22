using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public bool isadmin { get; set; }
        public bool ishidden { get; set; }
        public User() {}
        public User(string username, string password, string email, bool isadmin, bool ishidden)
        {
            this.username = username;
            this.password = password;
            this.email = email;
            this.isadmin = isadmin;
            this.ishidden = ishidden;
        }
        public User(int id, string username, string password, string email, bool isadmin, bool ishidden) : this (username, password, email, isadmin, ishidden) { this.id = id; }
        public User(string username, string password, string email) : this (username, password, email, false, false) { } //Deafault constructor
        public User(User user) : this (user.id, user.username, user.password, user.email, user.ishidden, user.ishidden) { }
        
        
        //For console unitesting
        public async Task<string> ToString_Async()
        {
            string ret = string.Empty;
            ret += $"Username: {username}| Is a dev: {isadmin}";
            return ret;
        }
    }
}
