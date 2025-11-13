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
            User Jungelist = new User("Jungelist", "The stars bleed", "aaaaaaaaaa@gmail.com", true, true);
            User HMan = new User("h", "h", "h");

            string username = string.Empty; string email = string.Empty; string password = string.Empty;
            //Console.Write("Enter username:  "); username = Console.ReadLine();
            //Console.Write("Enter email:  "); email = Console.ReadLine();
            //Console.Write("Enter password:  "); password = Console.ReadLine();

            //object response = await UDB.Login_Async(Jungelist);
            //if (response is User) { Console.WriteLine(await (response as User).ToString_Async()); }
            //else if (response is string) { Console.WriteLine(response); }
            //else { Console.WriteLine("User not found"); }

            Console.WriteLine(await UDB.Delete_Async(HMan,""));
        }
        public static async Task MonsterTesting()
        {

        }
    }
}