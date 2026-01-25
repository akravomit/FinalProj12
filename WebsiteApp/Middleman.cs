using Models;
using DBL;
namespace WebsiteApp
{
    public class Middleman
    {
        private static AttackDB ADB = new AttackDB();
        private static ElementDB ElDB = new ElementDB();
        private static EntryDB EnDB = new EntryDB();
        private static InventoryDB InvDB = new InventoryDB();
        private static Item_Type_Name_DB I_T_NDB = new Item_Type_Name_DB();
        private static ItemDB ItmDB = new ItemDB();
        private static Monster_Attacks_DB M_ADB = new Monster_Attacks_DB();
        private static MonsterDB MDB = new MonsterDB();
        private static PlayerDB PDB = new PlayerDB();
        private static UserDB UDB = new UserDB();


        //    >.>


        public static async Task<object> Login(string user,string password)
        { return await UDB.Login_Async(user, password); }
        public static async Task<object> Register(User user, string password)
        { return await UDB.Register_Async(user, password); }
        public static async Task<List<User>> GetAllUsers()
        { return await UDB.GetAllAsync(); } //Just in case I'll need it? Idk
        public static async Task<int> Delete(User target)
        { return await UDB.Delete_Async(target, ""); }
        public static async Task<int> Update(User target, User replacement)
        { return await UDB.Update_Async(target, replacement); }
        public static async Task<bool> DoesUserExist_ByKey_Async(string key, object value)
        { if (await UDB.GetByKey(key, value) == null) { return false; } return true; }
        public static async Task<bool> DoesExistByKeyWithType(Type T, string key, object value)
        {
            bool ret = false;
            if (T is User) { return await UDB.GetByKey(key, value) is not null; }
            if (T is Monster) { return await MDB.GetByKey(key, value) is not null; }

            return ret;
        }
        public static async Task<List<Player>> GetPlayers(int userID) 
        { return await PDB.GetByKeys(new Dictionary<string, object>() { { "OwnerID", userID }, { "IsHidden", false } }); }
        public static async Task<Player> InsertGetPlayer(string username, int ownerid) 
        { return await PDB.InsertGetPlayer(new Player(username,ownerid)); }
        public static async Task<List<Monster>> GetMonsters(bool IncludeInvis) //IncludeInvis controls if to search for hidden monsters as well
        {  if (IncludeInvis) { return await MDB.GetAllAsync(); }
           return await MDB.GetByKeys(new Dictionary<string, object>() { {"IsHidden", false } }); 
        }
        public static async Task<List<Dictionary<List<int[,,]>, Dictionary<string[,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,], List<List<List<Dictionary<int, Dictionary<Dictionary<int,int>,object>>>>>>>>> Cascade(List<Dictionary<List<int[,,]>, Dictionary<string[,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,], List<List<List<Dictionary<int, Dictionary<Dictionary<int, int>, object>>>>>>>> fart) { throw new NotImplementedException(); }
        //Yes, this is not used
        public static async Task RegisterEntry(Player owner, Monster monster)
        {
            await EnDB.RegisterEntry(owner, victim:monster);
        }
    }
}
