using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using MySql;
using MySql.Data.MySqlClient;

namespace leeHart_ConvertedData
{
    class restaurantReviewsData
    {

        static restaurantReviewsData() {; }
        public void runRestaurantReveiws() {
            //Database Location
            //string cs = @"server= 127.0.0.1;userid=root;password=root;database=SampleRestaurantDatabase;port=8889";
            //Output Location
            //string _directory = @"../../output/";

            bool running = true;
            string RestaurantProfiles = @"Select * from `RestaurantProfiles`;";
            string RestaurantReviewers = @"Select * from RestaurantReviewers;";
            string RestaurantReviews = @"Select * from RestaurantReviews;";
            string collection = "Reataurant Profiles";
            MySqlConnection conn = _conn();
            string capture;

            string message = $"Welcome to the restaurant reviews \r\nPlease select which file you want to convert \r\n \r\n" +
                $"Enter 1.     Restaurant Profiles\r\n" +
                $"Enter 2.     Restaurant Reviewers\r\n" +
                $"Enter 3.     Restaurant Reviews \r\n" +
                $"Enter 4.     Exit Program\r\n" +
                $"Your Entry  :";

            do
            {
                Console.Clear();


                string selection = Validations.Words(message, 3, 1, false);
                switch (selection.ToLower())
                {

                    case "1":
                    case "restaurant profiles":
                        {
                            capture = GetRestaurantInfo(conn, RestaurantProfiles, collection);

                            Writer(capture, "restaurantProfiles.json");
                            Console.WriteLine("Restaurant Profiles has been converted to Json");
                            Utility.Pause();

                        }; break;
                    case "2":
                    case "restaurant reviewers":
                        {
                            capture = GetRestaurantInfo(conn, RestaurantReviewers, "Restaurant Reviewers");

                            Writer(capture, "restaurantReviewers.json");
                            Console.WriteLine("Restaurant Reviewers has been converted to Json");
                            Utility.Pause();


                        }; break;
                    case "3":
                    case "restaurant reviews":
                        {
                            capture = GetRestaurantInfo(conn, RestaurantReviews, "Restaurant Reviews");

                            Writer(capture, "restaurantReviews.json");
                            Console.WriteLine("Restaurant Reviews has been converted to Json");
                            Utility.Pause();


                        }; break;
                    case "4":
                    case "exit program":
                        {
                            running = false;
                        } break;
                    default:
                        {

                            Console.WriteLine("Invalid Entry ");
                            Utility.Pause();
                        } break;


                }

            } while (running);


        }
        static string Cs()
        {
            string cs = $@"server=192.168.225.1;" +
        "userid=dbsAdmin;" +
                "password=password;" +
        "database=Restaurant;" +
        "port=8889;";
            ////string cs = @"server= 127.0.0.1;userid=root;password=root;database=SampleRestaurantDatabase;port=8889";
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

        static public DataTable RestaurauntData(string query)
        {
            MySqlConnection connection = _conn();
            DataTable data = new DataTable();
            MySqlDataAdapter adapt = new MySqlDataAdapter(query, connection);
            adapt.SelectCommand.CommandType = CommandType.Text;
            adapt.Fill(data);

            return data;

        }
        static public string GetRestaurantInfo(MySqlConnection connection, string query, string coll)
        {




            DataTable data = new DataTable();
            MySqlDataAdapter adapt = new MySqlDataAdapter(query, connection);
            adapt.SelectCommand.CommandType = CommandType.Text;
            adapt.Fill(data);

            DataRowCollection rows = data.Rows;
            string addedValue = "{" + '"' + coll + '"' + ": [ ";
            int y = 1;
            foreach (DataRow row in rows)
            {

                DataTable dataTable = row.Table;
                addedValue += "{";
                int x = 1;
                foreach (DataColumn col in dataTable.Columns)

                {
                    if (x == col.Table.Columns.Count)
                    {
                        if (y == row.Table.Rows.Count)
                        {
                            addedValue += '"' + col.ToString() + '"' + " : " + '"' + row[col].ToString() + '"' + "}";
                        }
                        else
                        {
                            addedValue += '"' + col.ToString() + '"' + " : " + '"' + row[col].ToString() + '"' + "}" + ", ";

                        }
                    }
                    else
                    {
                        addedValue += '"' + col.ToString() + '"' + " : " + '"' + row[col].ToString() + '"' + ",";
                        x++;
                    }

                }

                y++;
            }
            addedValue += " ] }";


            return addedValue;
        }
        public static void Writer(string jSON, string outPut, string outputFolder = @"..\..\JsonFiles\")

        {
            // outputFolder = @"../../output/";

            using (StreamWriter streamWriter = new StreamWriter(outputFolder + $@"{outPut}"))
            {

                streamWriter.Write(jSON);


            }
        }

        public static RestaurantReviewGraphs[] ReviewGraphs()
        {
            List<RestaurantReviewGraphs> restaurants = new List<RestaurantReviewGraphs>();
            for (int i = 1; i <= 100; i++)
            {
                string info = "";
                string restID;

                DataTable dataTable = restaurantReviewsData.RestaurauntData($@"select * from RestaurantProfiles where id = { i };");
                foreach (DataRow rrow in dataTable.Rows)
                {

                    decimal IY = 0;
                    info = "";
                    info += $"{rrow["RestaurantName"].ToString()}\r\n" +
                        $"{rrow["Address"].ToString()}\r\n" +
                            $"{rrow["Phone"].ToString()}\r\n" +
                            $"{rrow["Price"].ToString()}\r\n";
                    string query = $@"select Avg(`ReviewScore`) from RestaurantReviews where `RestaurantId`  = {i};";
                    DataTable Reviews = restaurantReviewsData.RestaurauntData(query);
                    foreach (DataRow row in Reviews.Rows)
                    {

                        restID = rrow["id"].ToString();

                        decimal.TryParse(row["Avg(`ReviewScore`)"].ToString(), out IY);


                    }


                    string name = rrow["id"].ToString();

                    RestaurantReviewGraphs Add = new RestaurantReviewGraphs(name, info, IY);
                    restaurants.Add(Add);
                    i++;

                }
            }



            RestaurantReviewGraphs[] graphs = restaurants.ToArray();

            return graphs;





        }
        public static Dictionary<int, RestaurantReviewGraphs[]> AllReviews()
        {
            Dictionary<int, RestaurantReviewGraphs[]> reviews = new Dictionary<int, RestaurantReviewGraphs[]>();

            for (int i = 1; i <= 100; i++)
            {
                List<RestaurantReviewGraphs> restaurants = new List<RestaurantReviewGraphs>();
                string info = "";
                string restID;

                DataTable dataTable = restaurantReviewsData.RestaurauntData($@"select * from RestaurantProfiles where id = { i };");
                foreach (DataRow rrow in dataTable.Rows)
                {

                    decimal IY = 0;
                    info = "";
                    info += $"{rrow["RestaurantName"].ToString()}\r\n" +
                        $"{rrow["Address"].ToString()}\r\n" +
                            $"{rrow["Phone"].ToString()}\r\n" +
                            $"{rrow["Price"].ToString()}\r\n";
                    string query = $@"select ReviewScore from RestaurantReviews where `RestaurantId`  = {i};";
                    DataTable Reviews = restaurantReviewsData.RestaurauntData(query);
                    string name = rrow["id"].ToString();
                    foreach (DataRow row in Reviews.Rows)
                    {

                        restID = rrow["id"].ToString();

                        decimal.TryParse(row["ReviewScore"].ToString(), out IY);
                        RestaurantReviewGraphs Add = new RestaurantReviewGraphs(name, info, IY);
                        restaurants.Add(Add);
                    }


                }

                RestaurantReviewGraphs[] graphs = restaurants.ToArray();
                reviews.Add(i, graphs);

                i++;


            }

            return reviews;


        }
    public static List<RestaurantReviewGraphs> ReviewedGraphs()
        {
            List<RestaurantReviewGraphs> restaurants = new List<RestaurantReviewGraphs>();
            string name = "";
            string info = "";
            decimal IY;
            int restID;
                    string query = $"select * from RestaurantReviews order by RAND() limit 10;";
        DataTable Reviews = restaurantReviewsData.RestaurauntData(query);
            
            foreach (DataRow row in Reviews.Rows)
            {
                int.TryParse(row["RestaurantId"].ToString(), out restID);
                decimal.TryParse(row["ReviewScore"].ToString(), out IY);

                DataTable dataTable = restaurantReviewsData.RestaurauntData($@"select * from RestaurantProfiles where id = {restID};");
                foreach (DataRow rrow in dataTable.Rows)
                {
                    name = rrow["id"].ToString();
                    info = "";
                    info += $"{rrow["RestaurantName"].ToString()}\r\n" +
                        $"{rrow["Address"].ToString()}\r\n" +
                            $"{rrow["Phone"].ToString()}\r\n" +
                            $"{rrow["Price"].ToString()}\r\n";


                   
                }
                RestaurantReviewGraphs Add = new RestaurantReviewGraphs(name, info, IY);
                restaurants.Add(Add);
            }


            return restaurants;
                    }
        public static List<RestaurantReviewGraphs> ReviewedGraphsTopTen()
        {
            List<RestaurantReviewGraphs> restaurants = new List<RestaurantReviewGraphs>();
            string name;
            string info;
            decimal IY;
            int restID;
            string query = $"select Avg(`ReviewScore`) from RestaurantReviews order by  AVG('ReviewScore') ACS limit 10;";
            DataTable Reviews = restaurantReviewsData.RestaurauntData(query);

            foreach (DataRow row in Reviews.Rows)
            {
                int.TryParse(row["RestaurantId"].ToString(), out restID);
                decimal.TryParse(row["ReviewScore"].ToString(), out IY);

                DataTable dataTable = restaurantReviewsData.RestaurauntData($@"select * from RestaurantProfiles where id = {restID};");
                foreach (DataRow rrow in dataTable.Rows)
                {
                    name = rrow["id"].ToString();
                    info = "";
                    info += $"{rrow["RestaurantName"].ToString()}\r\n" +
                        $"{rrow["Address"].ToString()}\r\n" +
                            $"{rrow["Phone"].ToString()}\r\n" +
                            $"{rrow["Price"].ToString()}\r\n";

                    RestaurantReviewGraphs Add = new RestaurantReviewGraphs(name, info, IY);
                    restaurants.Add(Add);
                }
                
               
            }


            return restaurants;
        }


    }
    }



