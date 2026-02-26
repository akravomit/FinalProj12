using DBL;
using Models;
using MySql.Data.MySqlClient;
using System;
using System.Xml.Linq;

namespace UniTesting
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            //await UserTesting(); //--DONE
            //await MonsterTesting();
            //await PlayerTesting(); //--DONE
            //await ElementTesting(); //--DONE

            //EntryDB entryDB = new EntryDB();
            //List<Entry> Entries = await entryDB.GetAllAsync();
            //await Console.Out.WriteLineAsync(Environment.MachineName);
            //Console.WriteLine(DateTime.Today - Entries[0].date_slain.Date);
            //Console.WriteLine(DateTime.Today.Subtract(Entries[0].date_slain).Days+" days ago");

            DeeBee a = new DeeBee();
            a.conn.Open(); a.cmd.Connection = a.conn; a.cmd.CommandText = $"SELECT Name FROM game.item WHERE ID >= {5} LIMIT 5";
            a.reader = a.cmd.ExecuteReader();
            while(a.reader.Read())
            {
                Console.WriteLine(a.reader.GetString(0));
            }
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
                playername = playername.Substring(0,20); 
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
        public static async Task ElementTesting()
        {
            ElementDB EDB = new ElementDB();
            UserDB UDB = new UserDB();
            User Login = new User();
            string username = string.Empty; string password = new string("");
            Console.WriteLine("---Log in---");
            Console.Write("Enter your username:     "); username = Console.ReadLine();
            Console.Write("Enter your password:     "); password = Console.ReadLine();
            var Result = await UDB.Login_Async(username, password);
            if (Result is string) { Console.WriteLine(Result); return; }
            else { Login = Result as User; }
            Element element = new Element();
            Console.Write("Write element name:      ");
            string name = Console.ReadLine();
            bool doesExist = false;
            Element result = await EDB.GetByUniqueK("Name", name);
            if (result is not null) { doesExist = true; element = new Element(result); }
            //If the element exists, it will update it
            string input;
            Console.Write("What element is it strong against? Leave blank for none:     "); input = Console.ReadLine(); int strong;
            if (string.IsNullOrEmpty(input) || int.Parse(input) == 0) strong = 0;
            else { strong = (await EDB.GetByUniqueK("id", int.Parse(input)) as Element).id; }
            Console.Write("What element is it weak against? Leave blank for none:     "); input = Console.ReadLine(); int weak;
            if (string.IsNullOrEmpty(input) || int.Parse(input) == 0) weak = 0;
            else { weak = (await EDB.GetByUniqueK("id",int.Parse(input)) as Element).id; }
            if (doesExist is false) 
            { 
                element = new Element(name, strong, weak, 0.8, 1.2, false); 
                element = await EDB.InsertGetElement(element);
                Console.WriteLine($@"Element {element.name} with the ID of {element.id} has been inserted to the database!");
            } //Enter the element
            else 
            { 
                element = new Element(result.id, name, strong, weak, 0.8, 1.2, false);
                element.id = await EDB.UpdateElement(element, result);
                Console.WriteLine($@"Element {element.name} with the ID of {element.id} has been updated in the database!");
            } 
        }
    }
}