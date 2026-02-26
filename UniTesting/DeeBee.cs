using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniTesting
{
    public class DeeBee
    {
        private List<string> passwords = ["12345", "josh17rog"];
        private const string MySqlConnSTR = $"server=localhost; user id=root; password=josh17rog;persistsecurityinfo=True;database=game";

        public DbConnection conn;
        public DbCommand cmd;
        public DbCommand cmd2;
        public DbDataReader reader;

        public DeeBee()
        {
            if (conn == null)
            {
                if (Environment.MachineName == "STATION") { conn = new MySqlConnection(MySqlConnSTR.Replace(passwords[1], passwords[0])); }
                else { conn = new MySqlConnection(MySqlConnSTR); }
                //If the machine is mine it will use a different password, because I set my password here stupidly
            }
            cmd = new MySqlCommand();
            cmd.Connection = conn;
            reader = null;
        }
    }
}
