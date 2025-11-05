using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Linq.Expressions;

namespace DBL
{
    public abstract class DB
    {
        //private const string password = "12345";
        private List<string> passwords = [ "12345", "josh17rog" ];
        //private const string MySqlConnSTR = $"server=localhost; user id=root; password={password};persistsecurityinfo=True;database=gaem";

        protected DbConnection conntmp;
        protected DbConnection conn;
        protected DbCommand cmd;
        protected DbCommand cmd2;
        protected DbDataReader reader;

        protected DB()
        {
            if (conn == null)
            {
                //conn = new MySqlConnection(MySqlConnSTR);
                foreach(string pass in passwords)
                {
                    conn = new MySqlConnection($"server=localhost; user id=root; password={pass};persistsecurityinfo=True;database=meag");
                    conntmp = new MySqlConnection($"server=localhost; user id=root; password={pass};persistsecurityinfo=True;database=meag");
                    try
                    {
                        conntmp = new MySqlConnection("SELECT * FROM meag.users;");
                        conntmp.OpenAsync();
                        cmd = new MySqlCommand();
                        cmd.Connection = conntmp;
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            cmd = new MySqlCommand();
            cmd.Connection = conn;
            reader = null;
        }
    }
}
