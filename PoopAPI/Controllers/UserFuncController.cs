using Microsoft.AspNetCore.Mvc;
using DBL;
using Models;

namespace PoopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserfunctionController : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<object> Login(string user, string password, bool UsesEmail, string email)
        {
            UserDB UDB = new UserDB();
            if (string.IsNullOrEmpty(user) && UsesEmail) user = "";
            if (string.IsNullOrEmpty(email) && !UsesEmail) email = "";
            if (UsesEmail) { return await UDB.Login_Async_Email(email, password); } //If it uses email it will use a similar func
            return await UDB.Login_Async_Username(user, password);
        }
    }
}
