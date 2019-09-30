using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TimeTrackerApp
{
    class Activities : ActivityLog
    {
        int _id;
        int user_id;
        int calendar_day;
        int day_name;
        int category_description;
        int activity_description;
        int time_spent_on_activity;
        int calendar_date;
        string _userName;
        string _calendar_day;
        string _day_of_week;
        string _time_spent_on_activity;
        string _calendar_date;
        string _activity_description;
        string _activity_category;
        public Activities(int id) :base()
        {

            _id = id;

            string query = $@"Select * from activity_log where id = {id};";
            DataTable logs = DatabaseConnection.queryDatabase(query);

            foreach (DataRow log in logs.Rows)
            {
                ActivityLog logger = new ActivityLog();

                int.TryParse(log["user_id"].ToString(), out user_id);
                int.TryParse(log["calendar_day"].ToString(), out calendar_day);
                int.TryParse(log["day_name"].ToString(), out day_name);
                int.TryParse(log["category_description"].ToString(), out category_description);
                int.TryParse(log["activity_description"].ToString(), out activity_description);
                int.TryParse(log["time_spent_on_activity"].ToString(), out time_spent_on_activity);
                int.TryParse(log["calendar_date"].ToString(), out calendar_date);

                
            }
            query = $@"Select * from time_tracker_users where user_id = {user_id};";
            logs = DatabaseConnection.queryDatabase(query);
            foreach (DataRow row in logs.Rows)
            {
                _userName = $"{row["user_firstname"].ToString().Trim()} {row["user_lastname"].ToString().Trim()}";

            }
            query = $@"Select * from tracked_calendar_days where calendar_day_id = {calendar_day};";
            logs = DatabaseConnection.queryDatabase(query);
            foreach (DataRow row in logs.Rows)
            {
                _calendar_day = $"School Day : {row["calendar_numerical_day"].ToString().Trim()}";

            }
            query = $@"Select * from tracked_calendar_dates where calendar_date_id = {calendar_date};";
            logs = DatabaseConnection.queryDatabase(query);
            foreach (DataRow row in logs.Rows)
            {
                _calendar_date = $"{row["calendar_date"].ToString().Trim()}";

            }
            query = $@"Select * from days_of_week where day_id = {day_name};";
            logs = DatabaseConnection.queryDatabase(query);
            foreach (DataRow row in logs.Rows)
            {
                _day_of_week = $"{row["day_name"].ToString().Trim()}";

            }
            query = $@"Select * from activity_times where activity_time_id = {time_spent_on_activity};";
            logs = DatabaseConnection.queryDatabase(query);
            foreach (DataRow row in logs.Rows)
            {
                _time_spent_on_activity = $"{row["time_spent_on_activity"].ToString().Trim()}";

            }
            query = $@"Select * from activity_categories where activity_category_id = {category_description};";
            logs = DatabaseConnection.queryDatabase(query);
            foreach (DataRow row in logs.Rows)
            {
                _activity_category = $"{row["category_description"].ToString().Trim()}";

            }
            query = $@"Select * from activity_descriptions where activity_description_id = {activity_description};";
            logs = DatabaseConnection.queryDatabase(query);
            foreach (DataRow row in logs.Rows)
            {
                _activity_description = $"{row["activity_description"].ToString().Trim()}";

            }
        }

        public void SetActivities()
        {
        

   




        }

        public override string ToString()
        {
            string returned;
            returned = $"{_userName}\r\n{_calendar_day}\r\n{_day_of_week}\r\n{_time_spent_on_activity}\r\n{_calendar_date}\r\n{_activity_description}\r\n{_activity_category}\r\n";


            return returned;
        }
    }
}
