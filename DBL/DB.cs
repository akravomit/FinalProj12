using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Linq.Expressions;

namespace DBL
{
    public abstract class DB
    {
        //private const string password = "12345";
        private List<string> passwords = [ "12345", "josh17rog" ];
        private const string MySqlConnSTR = $"server=localhost; user id=root; password=12345;persistsecurityinfo=True;database=meag";

        protected DbConnection conntmp;
        protected DbConnection conn;
        protected DbCommand cmd;
        protected DbCommand cmd2;
        protected DbDataReader reader;

        protected DB()
        {
            if (conn == null)
            {
                conn = new MySqlConnection(MySqlConnSTR);
                //foreach(string pass in passwords)
                //{
                //    conn = new MySqlConnection($"server=localhost; user id=root; password={pass};persistsecurityinfo=True;database=meag");
                //    conntmp = new MySqlConnection($"server=localhost; user id=root; password={pass};persistsecurityinfo=True;database=meag");
                //    try
                //    {
                //        cmd2 = new MySqlCommand();
                //        cmd2.Connection = conntmp;
                //        cmd2.CommandText = "SELECT * FROM meag.users;";
                //        cmd2.ExecuteScalarAsync();
                //        cmd = new MySqlCommand();
                //        cmd.Connection = conntmp;
                //        break;
                //    }
                //    catch (Exception ex)
                //    {

                //    }
                //}
            }
            cmd = new MySqlCommand();
            cmd.Connection = conn;
            reader = null;
        }
    }
}
