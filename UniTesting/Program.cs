using DBL;
using Models;
using System;

namespace UniTesting
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            await UserTesting();
        }
        public static async Task UserTesting()
        {
            UserDB UDB = new UserDB();
            //User user = new User(0, "Tinman", "ISentLiorToHell", "TruthNukeTinman@gmail.com", true, false);
            //User user = new User(0, "_Project__X", "ClankerDeporter9000", "imstupidlalalala@gmail.com", false, false);
            //User New = new User(user);
            //New.password = "Ceritified_Clanker_Deporter_9000_tm";
            //int result = await UDB.Update_Async(user, New);
            //Console.WriteLine(result);

            //List<User> Users = await UDB.GetAllAsync();
            //foreach (User u in Users)
            //{
            //    Console.WriteLine(await u.ToString_Async());
            //}

            //Console.Write("Enter username:  ");
            //string input = Console.ReadLine();
            //Console.WriteLine(await UDB.GetByKey_Async("username", input));
        }
        public static async Task MonsterTesting()
        {

        }
    }
}