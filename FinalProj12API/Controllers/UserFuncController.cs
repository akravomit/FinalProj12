using DBL;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using Models;
using Org.BouncyCastle.Asn1.X509;
using System.Security.Cryptography;

namespace FinalProj12API.Controllers
{
    //https://localhost:7229/api/Userfunction/ server Uri
    [Route("api/[controller]/")]
    [ApiController]
    public class UserfunctionController : ControllerBase
    {
        private static UserDB UDB = new UserDB();
        private static PlayerDB PDB = new PlayerDB();
        private static MonsterDB MDB = new MonsterDB();

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
        [HttpPost("GetThisUser/Data")]
        public async Task<User> GetThisUser([FromQuery]int UserID)
        {
            //https://localhost:7229/api/Userfunction/GetThisUser/Data?UserID=1
            return await UDB.GetByUniqueK("id", UserID);
        }
        [HttpDelete("DeleteUser")]
        public async Task<int> DeleteUser([FromBody] User target)
        {
            return await UDB.Delete_Async(target, target.password);
        }
        [HttpPost("RestoreUser")]
        public async Task<int> RestoreUser([FromBody] User target)
        {
            User Undeleted = new User(target);
            Undeleted.ishidden = false;
            return await UDB.Update_Async(target, Undeleted);
        }
        [HttpPost("UpdateUser")]
        public async Task<int> UpdateUser([FromBody]TwoUsers UserAndTarget)
        {
            return await UDB.Update_Async(UserAndTarget.one, UserAndTarget.two);
        }
        [HttpPost("DoesUserExist_ByKey_Josh_Async")]
        public async Task<bool> DoesUserExist_ByKey_Josh_Async([FromQuery]string key, [FromQuery]object value)
        {
            if (await UDB.GetByKey(key, value) == null) { return false; }
            return true;
        }
        [HttpPost("GetPlayers")]
        public async Task<List<Player>> GetPlayersOfUser([FromQuery] int UserID)
        {
            return await PDB.GetByKeys(new Dictionary<string, object>() { { "OwnerID", UserID }, { "IsHidden", false } });
        }
        [HttpPost("InsertGetPlayer")]
        public async Task<Player> InsertGetPlayer([FromBody] KeyValuePair<string, int> player)
        {
            return await PDB.InsertGetPlayer(new Player(player.Key, player.Value));
        }
        [HttpPost("GetMonsters")]
        public async Task<List<Monster>> GetMonsters([FromQuery] bool IncludeInvis)
        {
            if (IncludeInvis) { return await MDB.GetAllAsync(); }
            return await MDB.GetByKeys(new Dictionary<string, object>() { { "IsHidden", false } });
        }
        [HttpPost("UpdatePlayer")]
        public static async Task<int> UpdatePlayer(TwoPlayers PlayerAndReplacement) 
        { 
            return await PDB.Update_Async(PlayerAndReplacement.one, PlayerAndReplacement.two); 
        }
        [HttpPost("GetInvOfPlayer")]
        public static async Task<List<Dictionary<string, object>>> GetInvOfPlayer([FromBody]Player p)
        {
            InventoryItemsOfPlayerDB InvItmOPDB = new InventoryItemsOfPlayerDB();
            return await InvItmOPDB.GetInvOfPlayer(p);
        }
        [HttpPost("GetEntriesOfPlayer")]
        public static async Task<List<Dictionary<string, object>>> GetEntriesOfPlayer([FromBody]Player p)
        {
            EntryMonstersOfPlayerDB EtrMOPDB = new EntryMonstersOfPlayerDB();
            return await EtrMOPDB.GetEntriesOfPlayer(p);
        }
        [HttpPost("GetAllElements")]
        public static async Task<List<Element>> GetAllElements()
        {
            ElementDB ElDB = new ElementDB();
            return await ElDB.GetAll();
        }
        [HttpPost("GetAllItemTypeNames")]
        public static async Task<List<Item_Type_Name>> GetAllItem_Type_Names()
        {
            Item_Type_Name_DB ITNDB = new Item_Type_Name_DB();
            return await ITNDB.GetAllAsync();
        }
        [HttpPost("GetAttacksOfItems")]
        public static async Task<List<Dictionary<string, object>>> GetAttacksOfItem([FromQuery]int ItemID)
        {
            AttacksOfItemByItemID AtkOItmBItmID = new AttacksOfItemByItemID();
            return await AtkOItmBItmID.GetAttacksOfItemByItemID(ItemID);
        }
        [HttpPost("ConsumeItem")]
        public static async Task ConsumeItem([FromBody]Dictionary<string, object> item)
        {
            InventoryDB InvDB = new InventoryDB();
            await InvDB.UseItem(item);
        }
        [HttpPost("GetAttacksOfMonster")]
        public static async Task<List<Dictionary<string, object>>> GetMonsterAttacks([FromBody]Monster m)
        {
            AttacksOfMonsterByMonsterID AtkOMBMID = new AttacksOfMonsterByMonsterID();
            return await AtkOMBMID.GetMonsterAttacks(m.id);
        }
        [HttpPost("RegisterEntry")]
        public static async Task<List<Dictionary<string,object>>> RegisterEntry([FromBody]IHateThisDataStruct_ForTheRegisterEntryFunction HateDisShit)
        {
            EntryDB EnDB = new EntryDB();
            Entry e = await EnDB.RegisterEntry(HateDisShit.owner, HateDisShit.monster);
            if (e is not null)
            {
                if (e.times_killed == 1)
                {
                    EntryMonstersOfPlayerDB EnMoOPDB = new EntryMonstersOfPlayerDB();
                    HateDisShit.Entries.Add(await EnMoOPDB.AddEntryToList(e, HateDisShit.monster));
                }
                else
                {
                    Dictionary<string, object> result = new Dictionary<string, object>();
                    foreach (Dictionary<string, object> entry in HateDisShit.Entries)
                    {
                        if (entry["Name"] == HateDisShit.monster.name || Convert.ToInt32(entry["MonsterID"].ToString()) == HateDisShit.monster.id)
                        {
                            result = entry;
                            int tmp = Convert.ToInt32(result["TimesKilled"].ToString()); tmp++;
                            entry["TimesKilled"] = tmp;
                            break;
                        }
                    }
                }
            }
            return HateDisShit.Entries;
        }
        public record IHateThisDataStruct_ForTheRegisterEntryFunction(Player owner, Monster monster, List<Dictionary<string,object>> Entries);
        public record TwoUsers(User one, User two);
        public record TwoPlayers(Player one , Player two);
        public record LoginData(string username, string password, bool usesemail, string email);
    }
}
