using Models;
using DBL;
namespace WebApp
{
    public class Middleman
    {
        private protected UserDB UDB;
        public async Task<string> Login(User user)
        {
            return await UDB.Register_Async(user, "");
        }
    }
}
