using DBL;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc.Routing;
using System.ComponentModel;

namespace APIOrWhatev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserfunctionController : ControllerBase
    {
        [HttpPost("Login")]
        public static async Task<object> Login(string user, string password, bool UsesEmail, string email) 
        {
            UserDB UDB = new UserDB();
            if (UsesEmail) { return await UDB.Login_Async_Email(email, password); } //If it uses email it will use a similar func
            return await UDB.Login_Async_Username(user, password);
        }
    }
}
