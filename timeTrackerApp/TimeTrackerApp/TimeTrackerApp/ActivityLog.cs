using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace TimeTrackerApp
{
    class ActivityLog
    {

        public ActivityLog() { }
        public static DataTable dataTable = DatabaseConnection.queryDatabase(@"select * from activity_log");

        private int _user_ID;
        private int _dateTime;
        private int _day_name;
        private int _activity_description;
        private int _category_description;
        private int time_spent_on;
        private int calendar_date;

       


        public int User_ID { get { return _user_ID; } set { value = _user_ID; } }

        public int DateTime { get { return _dateTime; } set { _dateTime = value; } }

        public int DayName { get { return _day_name; } set { _day_name = value; } }

        public int CatDescr { get { return _category_description; } set { _category_description = value; } }

        public int ActDescr { get { return _activity_description; } set { _activity_description = value; } }

        public int TimeSpent { get { return time_spent_on; } set { time_spent_on = value; } }

        public int CalendarDate { get { return calendar_date; } set { calendar_date = value; } }


        public override string ToString()
        {
            string activityString = $@" {_dateTime} , {_day_name} , {_category_description} , {_activity_description} , {time_spent_on} , {calendar_date} ";



            return activityString;





        }
        public void AddLog(string Query)
        {
            MySqlConnection connection = DatabaseConnection._conn();
            {


                using (MySqlCommand command = new MySqlCommand(Query, connection))
                {



                    connection.Open();
                    int result = command.ExecuteNonQuery();


                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                    else { Console.WriteLine("Your activity has been entered"); }
                }

            }



        
    }
        public void ConsoleWriter()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"{User_ID} {CatDescr} {ActDescr} {TimeSpent} {DateTime} {DayName} {CalendarDate}");



        }

        public static List<ActivityLog> AllActivities(string query)
        {
            List<ActivityLog> logOfActivity = new List<ActivityLog>();
            
            DataTable logs = DatabaseConnection.queryDatabase(query);

            foreach (DataRow log in logs.Rows)
            {
                ActivityLog logger = new ActivityLog();

                int.TryParse(log["user_id"].ToString(), out logger._user_ID);
                int.TryParse(log["calendar_day"].ToString(), out logger._dateTime);
                int.TryParse(log["day_name"].ToString(), out logger._day_name);
                int.TryParse(log["category_description"].ToString(), out logger._category_description);
                int.TryParse(log["activity_description"].ToString(), out logger._activity_description);
                int.TryParse(log["time_spent_on_activity"].ToString(), out logger.time_spent_on);
                int.TryParse(log["calendar_date"].ToString(), out logger.calendar_date);

                logOfActivity.Add(logger);
            }

            return logOfActivity;



        }
    }
}



