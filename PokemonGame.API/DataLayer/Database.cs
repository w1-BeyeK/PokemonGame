using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonGame.API.DataLayer
{
    public static class Database
    {
        private static readonly string conn = "Server=studmysql01.fhict.local;Uid=dbi409368;Database=dbi409368;Pwd=Heclepra9;";
        //private static readonly string conn = "Server=localhost;Uid=root;Database=simple_login;Pwd=root;";

        public static DataTable ExecSelect(string query)
        {
            DataSet ds = new DataSet();
            MySqlConnection sqlConnection = new MySqlConnection(conn);
            ds.Clear();
            using (MySqlDataAdapter da = new MySqlDataAdapter(query, sqlConnection))
            {
                da.Fill(ds);
            }
            return ds.Tables[0];
        }

        public static bool ExecOverig(string query)
        {
            bool success = true;

            MySqlConnection sqlConnection = new MySqlConnection(conn);
            using (MySqlCommand cmd = new MySqlCommand(query, sqlConnection))
            {
                try
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                catch
                {
                    success = false;
                }
            }

            return success;
        }
    }
}
