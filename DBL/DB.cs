using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Linq.Expressions;

namespace DBL
{
    public abstract class DB
    {
        private List<string> passwords = [ "12345", "josh17rog" ];
        private const string MySqlConnSTR = $"server=localhost; user id=root; password=josh17rog;persistsecurityinfo=True;database=game";

        protected DbConnection conntmp;
        protected DbConnection conn;
        protected DbCommand cmd;
        protected DbCommand cmd2;
        protected DbDataReader reader;

        protected DB()
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
