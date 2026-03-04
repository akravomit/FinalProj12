using Models;
using DBL;
using System.Net.NetworkInformation;
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
        { return await UDB.GetAllAsync();  } //Used exclusively by admins
        public static async Task<List<User>> GetAllUsers(bool GetInvis)
        { return await UDB.GetByKey("ishidden", GetInvis); }
        public static async Task<int> DeleteUser(User target)
        { return await UDB.Delete_Async(target, ""); }
        public static async Task<int> UnDeleteUser(User target) 
        {
            User Undeleted = new User(target);
            Undeleted.ishidden = false;
            return await UDB.Update_Async(target, Undeleted); 
        }
        public static async Task<int> UpdateUser(User target, User replacement)
        { return await UDB.Update_Async(target, replacement); }
        public static async Task<bool> DoesUserExist_ByKey_Async(string key, object value)
        { if (await UDB.GetByKey(key, value) == null) { return false; } return true; }
        public static async Task<List<Player>> GetPlayers(int userID) 
        { return await PDB.GetByKeys(new Dictionary<string, object>() { { "OwnerID", userID }, { "IsHidden", false } }); }
        public static async Task<Player> InsertGetPlayer(string username, int ownerid) 
        { return await PDB.InsertGetPlayer(new Player(username,ownerid)); }
        public static async Task<List<Monster>> GetMonsters(bool IncludeInvis) //IncludeInvis controls if to search for hidden monsters as well
        {  if (IncludeInvis) { return await MDB.GetAllAsync(); }
           return await MDB.GetByKeys(new Dictionary<string, object>() { {"IsHidden", false } }); 
        }
        public static async Task RegisterEntry(Player owner, Monster monster)
        {
            await EnDB.RegisterEntry(owner, victim:monster);
        }
        public static async Task<Dictionary<string,object>> DescribeMonster(Monster m)
        {
            return await MDB.MonsterToDict(m);
        }
        public static async Task<Player> AwardPlayerForKill(Monster m, Player p)
        {
            Random Jerry = new Random();
            double DiffMultiplier = ((double)((m.rarity * 100 + m.defense * 10) / 10)) / 100 + 1;
            int BossMultiplier = 10 * m.isboss;
            int RawCoin = Jerry.Next(1 + BossMultiplier, (int)(Math.Pow(10 + BossMultiplier, 2)) + 1);
            double TotalCoin = RawCoin * DiffMultiplier;
            Player UpdatedPlr = new Player(p); UpdatedPlr.coins += (int)TotalCoin;
            await UpdatePlayer(p, UpdatedPlr);
            return UpdatedPlr;
        }
        public static async Task<int> UpdatePlayer(Player Old, Player New) { return await PDB.Update_Async(Old, New); }
        public static async Task<List<Entry>> GetEntriesOfPlayer(Player p)
        {
            return await EnDB.GetByPlayer(p);
        }
        public static async Task<string> GetMonsterNameByID(int MonsterID)
        {
            return await MDB.FetchMonsterName(MonsterID);
        }
        public static async Task<List<Inventory>> GetInvOfPlayer(Player p)
        {
            return await InvDB.GetByPlayerAsync(p.id);
        }
        public static async Task<string> GetItemNameByID(int ItemID)
        {
            return await ItmDB.GetItemName(ItemID);
        }
        public static async Task<List<Dictionary<string,object>>> NewGetInvOfPlayer(Player p)
        {
            InventoryItemsOfPlayerDB InvItmOPDB = new InventoryItemsOfPlayerDB();
            return await InvItmOPDB.GetInvOfPlayer(p);
        }
        public static async Task<List<Dictionary<string,object>>> NewGetEntriesOfPlayer(Player p)
        {
            EntryMonstersOfPlayerDB EtrMOPDB = new EntryMonstersOfPlayerDB();
            return await EtrMOPDB.GetEntriesOfPlayer(p);
        }
    }
}
