using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TimeTrackerApp
{
    class Menu
    {


        public static void MenuStart(int userName)

           
        {
            int UsersID = userName;
            string query;
            bool running = true;
            do
            {
                bool run = true;
                int selection = Validations.GetInt("1. Enter an Activity \r\n2. View Tracked Data\r\n3. Run Calculations");
                int subSelection;
                string value;
                ActivityLog Activity = new ActivityLog() ;
                Console.WriteLine(UsersID);
                switch (selection)


                   
                {
                    case 1:


                        {

                            do
                            {
                                
                                Activity.User_ID = UsersID;
                                
                                query = @"select * from activity_categories ;";
                                DataTable table = DatabaseConnection.queryDatabase(query);
                                Dictionary<int, string> keyValues = DatabaseConnection.DataList(table, "activity_category_id", "category_description");
                                DatabaseConnection.PrintDictionary(keyValues);
                                subSelection = Validations.GetInt();
                                if (keyValues.TryGetValue(subSelection, out value))
                                {
                                    Activity.CatDescr = subSelection;
                                }
                                query = @"select * from activity_descriptions ;";
                                table = DatabaseConnection.queryDatabase(query);
                                keyValues = DatabaseConnection.DataList(table, "activity_description_id", "activity_description");
                                DatabaseConnection.PrintDictionary(keyValues);
                                subSelection = Validations.GetInt();
                                if (keyValues.TryGetValue(subSelection, out value))
                                {
                                    Activity.ActDescr = subSelection;
                                }

                                query = @"select * from days_of_week ;";
                                table = DatabaseConnection.queryDatabase(query);
                                keyValues = DatabaseConnection.DataList(table, "day_id", "day_name");
                                DatabaseConnection.PrintDictionary(keyValues);
                                subSelection = Validations.GetInt();
                                if (keyValues.TryGetValue(subSelection, out value))
                                {
                                    Activity.DayName = subSelection;
                                }
                                query = @"select * from tracked_calendar_days ;";
                                table = DatabaseConnection.queryDatabase(query);
                                keyValues = DatabaseConnection.DataList(table, "calendar_day_id", "calendar_numerical_day");
                                DatabaseConnection.PrintDictionary(keyValues);
                                subSelection = Validations.GetInt();
                                if (keyValues.TryGetValue(subSelection, out value))
                                {
                                    Activity.DateTime = subSelection;
                                }
                                query = @"select * from activity_times ;";
                                table = DatabaseConnection.queryDatabase(query);
                                keyValues = DatabaseConnection.DataList(table, "activity_time_id", "time_spent_on_activity");
                                DatabaseConnection.PrintDictionary(keyValues);
                                subSelection = Validations.GetInt();
                                if (keyValues.TryGetValue(subSelection, out value))
                                {
                                    Activity.TimeSpent = subSelection;
                                }
                                query = @"select * from tracked_calendar_dates ;";
                                table = DatabaseConnection.queryDatabase(query);
                                keyValues = DatabaseConnection.DataList(table, "calendar_date_id", "calendar_date");
                                DatabaseConnection.PrintDictionary(keyValues);
                                subSelection = Validations.GetInt();
                                if (keyValues.TryGetValue(subSelection, out value))
                                {
                                    Activity.CalendarDate = subSelection;
                                }
                                string queryadd = UsersID +" ,"+ Activity.ToString();
                                
                                query = $@"INSERT INTO activity_log (user_id,calendar_day,day_name,category_description,activity_description,time_spent_on_activity,calendar_date) VALUES ({queryadd});";
                                Console.Write(query);
                                DatabaseConnection.queryDataInsert(query);

                                Utility.Pause();
                                run = Validations.GetBool("Do you want to add another activity? : ");


                            } while (run);

                        }
                        break;

                    case 2:

                        {
                            List<ActivityLog> activities = null;
                           
                            Activity.User_ID = UsersID;
                            query = @"select * from activity_categories ;";
                            DataTable table = DatabaseConnection.queryDatabase(query);
                            Dictionary<int, string> keyValues = DatabaseConnection.DataList(table, "activity_category_id", "category_description");
                            DatabaseConnection.PrintDictionary(keyValues);
                            subSelection = Validations.GetInt();
                            if (keyValues.TryGetValue(subSelection, out value))

                            {
                                Activity.DateTime = subSelection;
                                string category = "category_description";
                                query = $@"Select * from activity_log where user_id = {userName} and {category} = {subSelection};";
                                activities = ActivityLog.AllActivities(query);
                            }
                            else { Console.WriteLine("Invalid Entry"); }
                            
                           foreach(ActivityLog log in activities) { log.ConsoleWriter(); }
                            Utility.Pause();

                        } break;

                    case 3: { } break;
                    case 4: { running = false; } break;
                    default: { } break;
                }
            } while (running);
        }
/*

■ 1. Back
● Sub Menu
● Provides user feedback such as “activity
entered.” (Activity saved to database)
○ Sub Menu
○ 1. Enter Another Activity
○ 2. Back To Main Menu
3
● 2. View Tracked Data
○ Sub Menu
■ 1. Select By Date
● Sub Menu
● Which Date Would You Like To View?
● 1-26 Shows Dates(Pulled from database)
○ Sub Menu
○ After selecting, it shows All Activities, Total Hours
TRACKED/USED, and Total Hours UNTRACKED/ NOT
USED
○ 1. Enter Activity For This Day?
■ Takes user through enter activity process with
current day already selected
○ 2. Back
● 27. Back
■ 2. Select By Category
● Sub Menu
● Which one would you like to view?
● 1-X Shows Categories(Pulled from database)
○ Sub Menu
○ After selecting, it shows all activities from selected
category, dates they were performed, total time per
activity, and total time for the category(Ex: Sleeping
could have one entry per day, for X hours per day, for a
total of Y hours for the month) (Pulled from database)
○ 1. Back
● X+1. Back
■ 3. Select By Description
● Sub Menu
● Which one would you like to view?
● 1-X Shows Descriptions(Pulled from database)
4
● Sub Menu
○ After selection, it shows all activities from selected
description, dates they were performed, total time per
activity, and total time for the description(Ex: A
category of driving could have a description of “to
work,” which could happen five times a week, each week
of the month, for X amount of time during each drive,
for Y amount of time per week, or Z amount of time for
the month.) (Pulled from database)
○ 1. Back
● X+1. Back
■ 4. Back
● 3. Run Calculations
○ Sub Menu
■ Look At All Of The Cool Data Collected Over 26 Days:
■ Total Time Spent Working on School Work: (Pulled from database)
■ Total Time Spent on Personal Time: (Pulled from database)
■ Total Time on Outside Job: (Pulled from database)
■ Total Time Driving To School: (Pulled from database)
■ Percentage of Time on School Work vs Total Month: (Pulled from
database)
■ Percentage of Time with Family vs Total Month: (Pulled from
database)
■ ETC.ETC.ETC.
■ ...There needs to be at least 10 calculations run and shown to the
user...all of them must run a calculation from the data in the
database...you get to choose what those 10+ calculations are...
■ 1. Back
● 4. Exit

    */
    }
}
