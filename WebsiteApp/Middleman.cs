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
        private static HttpClient client = new HttpClient();

        //    >.>

        private record LoginData(string username, string password, bool usesemail, string email);
        public static async Task<object> Login(string user,string password, bool UsesEmail, string email)
        {
            client.BaseAddress = new Uri("https://localhost:7229/api/Userfunction/");
            LoginData logindata = new LoginData(user, password, UsesEmail, email);
            var response = await client.PostAsJsonAsync<object>("Login", logindata);
            response.EnsureSuccessStatusCode();
            return response;
        }
        public static async Task<object> Register(User user)
        { return await UDB.Register_Async(user,""); }
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
        public static async Task RegisterEntry(Player owner, Monster monster, List<Dictionary<string,object>> Entries)
        {
            Entry e = await EnDB.RegisterEntry(owner, victim:monster);
            if (e is not null)
            {
                if (e.times_killed == 1)
                {
                    EntryMonstersOfPlayerDB EnMoOPDB = new EntryMonstersOfPlayerDB();
                    Entries.Add(await EnMoOPDB.AddEntryToList(e, monster));
                }
                else
                {
                    Dictionary<string, object> result = new Dictionary<string, object>();
                    foreach (Dictionary<string, object> entry in Entries)
                    {
                        if (entry["Name"] == monster.name || Convert.ToInt32(entry["MonsterID"].ToString()) == monster.id)
                        {
                            result = entry;
                            int tmp = Convert.ToInt32(result["TimesKilled"].ToString()); tmp++;
                            entry["TimesKilled"] = tmp;
                            break;
                        }
                    }
                }
            }
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
        public static async Task<List<Element>> GetAllElements()
        {
            return await ElDB.GetAll();
        }
        public static async Task<List<Item_Type_Name>> GetAllItem_Type_Names()
        {
            return await I_T_NDB.GetAllAsync();
        }
        public static async Task<List<Dictionary<string,object>>> GetAttacksOfItem(int itm)
        {
            AttacksOfItemByItemID AtkOItmBItmID = new AttacksOfItemByItemID();
            return await AtkOItmBItmID.GetAttacksOfItemByItemID(itm);
        }
        public static async Task UseItem(Dictionary<string,object> item)
        {
            await InvDB.UseItem(item);
        }
        public static async Task<List<Dictionary<string,object>>> GetMonsterAttacks(Monster m)
        {
            AttacksOfMonsterByMonsterID AtkOMBMID = new AttacksOfMonsterByMonsterID();
            return await AtkOMBMID.GetMonsterAttacks(m.id);
        }
        public static async Task GiftItem(int ItemID, Player owner)
        {
            Item gift = await ItmDB.GetByUniqueK("id", ItemID);
            Inventory Gift = new Inventory(owner.id, ItemID, 1, false, 1);
            await InvDB.Insert_Async(Gift);
        }
    }
}
