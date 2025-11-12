using Models;
using DBL;
namespace WebsiteApp
{
    public class Middleman
    {
        private static protected UserDB UDB = new UserDB();
        public static async Task<object> Login(string user,string password, string email)
        {
            return await UDB.Login_Async(user, password, email);
        }
        public static async Task<object> Register(User user, string password)
        {
            return await UDB.Register_Async(user, password);
        }
        public static async Task<List<User>> GetAllUsers()
        {
            return await UDB.GetAllAsync();
        }
    }
}
