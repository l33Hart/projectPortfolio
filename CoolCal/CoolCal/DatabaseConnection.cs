using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace CoolCal
{
    class DatabaseConnection
    {

        static string Cs()
        {
            string cs = $@"server=192.168.225.1;" +
        "userid=dbsAdmin;" +
                "password=password;" +
        "database=CoolCal;" +
        "port=8889;";

            return cs;
        }
        static public MySqlConnection _conn()
        {
            string cs = Cs();
            MySqlConnection conn = null;
            try
            {

                conn = new MySqlConnection(cs);
                conn.Open();

            }
            catch (MySqlException e)
            {
                string msg = "";
                switch (e.Number)
                {
                    case 0:
                        {
                            msg = e.ToString();
                            break;


                        }
                    case 1042:
                        {
                            msg = "Can't Resolve host address \r\n" + conn.ConnectionString;
                            break;
                        }
                    case 1045:
                        {
                            msg = "Invalid username or password";
                            break;
                        }
                    default:
                        {
                            msg = e.ToString();

                        }
                        break;


                }
                Console.WriteLine(msg);
                Utility.Pause();

            }
            return conn;
        }
        public static void queryDataInsert(string query)
        {
            

           
           
            {
                MySqlConnection connection = _conn();
               
               
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = query;
                
                cmd.ExecuteNonQuery();
            }
         

        }
        public static DataTable queryDatabase(string query)
        {

            {
                try
                {
                    MySqlConnection connection = _conn();
                    DataTable data = new DataTable();
                    MySqlDataAdapter adapt = new MySqlDataAdapter(query, connection);
                    adapt.SelectCommand.CommandType = CommandType.Text;
                    adapt.Fill(data);
                    return data;
                }
                catch { return null; }
               

                
            }

        }

        public static Dictionary<int, string> DataList(DataTable table, string key, string value)
        {
            Dictionary<int, string> keyValues = new Dictionary<int, string>();
            foreach (DataRow row in table.Rows)
            {
                string keyString = row[key].ToString();
                int keyint;
                int.TryParse(keyString, out keyint);
                string valueString = row[value].ToString();
                keyValues.Add(keyint, valueString);
            }
            return keyValues;

        }
        public static void PrintDictionary(Dictionary<int, string> keyValues)
        {
            foreach (KeyValuePair<int, string> keyPair in keyValues)
            {
                Console.WriteLine($"Enter {keyPair.Key} For  {keyPair.Value}");


            }
            Utility.Pause();
        }
        public static bool login(string username)
        {
            string query = $@"Select Password from Profile where UserName = '{username}'; ";
            bool login = false;
            string password = null;
            string userentry = Validations.Words("Please enter password ", 1, 1, true);
            DataTable table = queryDatabase(query);
           foreach(DataRow row in table.Rows)
            {
                password = row["Password"].ToString();



            }
            if (password == userentry) { login = true; Console.WriteLine("You have Logged In !!!"); Utility.Pause(); }
            return login;

        }
}
}
