using DBL;
using Models;
using System;

namespace UniTesting
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            //await UserTesting();
            //await MonsterTesting();
            await PlayerTesting();
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

            object response = await UDB.Register_Async(HMan, "");
            Console.WriteLine(response);

            //Console.WriteLine(await UDB.Delete_Async(HMan,""));
        }
        public static async Task PlayerTesting()
        {
            PlayerDB PDB = new PlayerDB();
            UserDB UDB = new UserDB();
            User Login = new User();
            Player Plr = new Player();
            string name = string.Empty;
            string password = string.Empty;
            //string email = string.Empty;
            Console.WriteLine("---Log in---");
            Console.Write("Enter your username:     "); name = Console.ReadLine();
            Console.Write("Enter your password:     "); password = Console.ReadLine();
            var Result = await UDB.Login_Async(name, password);
            if (Result is string) { Console.WriteLine(Result); return; }
            else { Login = Result as User; }
            Console.WriteLine("---Create new player---");
            Console.Write("Enter player name:   ");
            string playername = Console.ReadLine();
            if (playername.Length > 20) 
            { 
                playername.Substring(0,20); 
                Console.WriteLine("Notice: your name exceeds the max limit of 20 characters. The name has been changed"); 
            }
            Plr = new Player(playername, Login.id);
            Console.WriteLine(@$"---Name:{Plr.name}---
HP:{Plr.hp} | Mana:{Plr.mana} | Coins:{Plr.coins}
Owner:{(await UDB.GetByUniqueK("username",name)).username}");
            PDB = new PlayerDB();
            Plr = await PDB.InsertGetPlayer(Plr);
            Console.WriteLine($"{Plr.name} has been inserted to the DB!");
        }
        public static async Task MonsterTesting()
        {
            
        }
    }
}