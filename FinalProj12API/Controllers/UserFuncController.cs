using Microsoft.AspNetCore.Mvc;
using DBL;
using Models;

namespace FinalProj12API.Controllers
{
    //https://localhost:7229/api/Userfunction/ server Uri
    [Route("api/[controller]")]
    [ApiController]
    public class UserfunctionController : ControllerBase
    {
        static UserDB UDB = new UserDB();
        [HttpPost("Login")]
        public async Task<object> Login([FromBody]LoginData Userinfo)
        {
            if (Userinfo.usesemail) { return await UDB.Login_Async_Email(Userinfo.email, Userinfo.password); } //If it uses email it will use a similar func
            return await UDB.Login_Async_Username(Userinfo.username, Userinfo.password);
        }
        [HttpPost("Register")]
        public async Task<object> Register([FromBody]User user)
        {
            return await UDB.Register_Async(user, user.password);
        }
        [HttpPost("GetAllUsers")]
        public async Task<List<User>> GetAllUsers()
        {
            return await UDB.GetAllAsync();
        }
        [HttpPost("DeleteUser")]
        public static async Task<int> DeleteUser([FromBody] User target)
        {
            return await UDB.Delete_Async(target, target.password);
        }
        [HttpPost("RestoreUser")]
        public static async Task<int> RestoreUser([FromBody] User target)
        {
            User Undeleted = new User(target);
            Undeleted.ishidden = false;
            return await UDB.Update_Async(target, Undeleted);
        }
        public record LoginData(string username, string password, bool usesemail, string email);
    }
}
