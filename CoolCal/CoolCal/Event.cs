using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CoolCal
{
    class Event
    {
       private int _eventID;
        CoolCalUser _user;
        string EventDescr;
        string color;
        public Event(CoolCalUser user)
        {
            _user = user;
        }
        public Event( CoolCalUser user , string eventID)
        {
            int.TryParse(eventID, out _eventID);
            _user = user;

        }
        public  DataTable[] EventFinder()
        {
            int i = 0;
            DataTable ThisEvent;
            DataTable[] Events = new DataTable[_user._calendarID.Count()] ;
            foreach (int cals in _user._calendarID)
            {
                
                string query = $@"Select * from Events where CalendarID = {cals.ToString()} ;";
                Events[i] = DatabaseConnection.queryDatabase(query);


                i++;
            }
            return Events;

        }

        public override string ToString()
        {
            string returned = null;
            string query = $@"Select * from Events where EventID = {_eventID}";
            DataTable Events = DatabaseConnection.queryDatabase(query);

           foreach(DataRow row in Events.Rows)
            {
                color = row["Color"].ToString();
                if (color == "	green	")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.Gray;

                }
                if (color == "	red 	")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Gray;
                }
                if (color == "	blue	")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.BackgroundColor = ConsoleColor.Gray;

                }
                returned = $"Description        : {row["Description"].ToString().PadRight(75 - row["Description"].ToString().Count())}\r\n"+
                           $"Event Date & Time  : {row["EventDateTime"].ToString().PadRight(75 - row["EventDateTime"].ToString().Count())}\r\n"+
                           $"Location           : {row["Location"].ToString().PadRight(75 - row["Location"].ToString().Count())}\r\n"+
                           $"Additional Info    : {row["AdditionalInfo"].ToString().PadRight(75 - row["AdditionalInfo"].ToString().Count())}\r\n"+
                           $"Notes              : {row["Notes"].ToString().PadRight(75 - row["Notes"].ToString().Count())}\r\n";


            }

            return returned; ;
        }

        public static Event CreateEvent(string value, CoolCalUser user)

        {
            Event Created = null;
            string query = $@"Insert Into Events ( CalendarID , Description , Color , EventDateTime , Location , AdditionalInfo, NotificationID , Notes , EventTypeID ) value {value};";
            DatabaseConnection.queryDataInsert(query);
            query = $@"Select EventID from Events where ( CalendarID , Description , Color , EventDateTime , Location , AdditionalInfo, NotificationID , Notes , EventTypeID ) =  {value}  ; ";
            DataTable tables = DatabaseConnection.queryDatabase(query);
          foreach(DataRow table in tables.Rows) { Created = new Event(user , table["EventID"].ToString()); }

            return Created;
        }
    }
}
