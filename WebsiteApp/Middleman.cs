using Models;
using DBL;
namespace WebsiteApp
{
    public class Middleman
    {
        private static protected UserDB UDB = new UserDB();
        public static async Task<object> Login(string user,string password)
        {
            return await UDB.Login_Async(user, password);
        }
        public static async Task<object> Register(User user, string password)
        {
            return await UDB.Register_Async(user, password);
        }
        public static async Task<List<User>> GetAllUsers()
        {
            return await UDB.GetAllAsync();
        } //Just in case I'll need it? Idk
        public static async Task<int> Delete(User target)
        {
            return await UDB.Delete_Async(target, "");
        }
        public static async Task<int> Update(User target, User replacement)
        {
            return await UDB.Update_Async(replacement, target);
        }
        public static async Task<bool> DoesUserExist_ByKey_Async(string key, object value)
        {
            if (await UDB.GetByKey_Async(key, value) == null) { return false; }
            return true;
        }
    }
}
