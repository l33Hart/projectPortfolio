using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CoolCal
{
    class CoolCalUser
    {
        string _userID;
        int _view;
        public int[] _calendarID;
        Event[] _events;
        public CoolCalUser(string userName)
        {
            string query = $@"Select *  from Profile where UserName = '{userName}';";


            bool login = DatabaseConnection.login(userName);
            if (login)
            {
               DataTable userID  = DatabaseConnection.queryDatabase(query);
                foreach(DataRow row in userID.Rows)
                { _userID = row["UserID"].ToString();
                    int.TryParse(row["ViewTypeID"].ToString(), out _view);

                }
                query = $@"Select `CalendarID` from Calendars where UserID = {_userID}; ";
                DataTable userCals = DatabaseConnection.queryDatabase(query);
                _calendarID = new int[userCals.Rows.Count];
                foreach (DataRow row in userCals.Rows)
                {
                    int i = 0;

                    int.TryParse(row["CalendarID"].ToString(), out _calendarID[i]);

                    i++;


                }
            }
            else { }


        }
        public string UserID { get{ return _userID;  }set{ _userID = value; } }
        
        public void View(Event[] events)
        {
            

            if (_view == 1)
            {
                for (int i = 0; i < events.Count(); i++)
                {
                     { Console.WriteLine($"{events[i].ToString()}"); }
                }
            }
            if (_view == 2)
            {
                for (int i = 0; i < events.Count(); i++)
                {
                    { Console.WriteLine($"{events[i].ToString()}"); }
                }
            }
            if (_view == 3)
            {
                for (int i = 0; i < events.Count(); i++)
                {
                    { Console.WriteLine($"{events[i].ToString()}"); }
                }

            }
            if (_view == 4)

            {

                for (int i = 0; i < events.Count(); i++)
                {
                    { Console.WriteLine($"{events[i].ToString()}"); }
                }

            }

        }

        public Event[] CalEvents(DataTable[] tables, CoolCalUser user)
        {
           
            List<Event> CoolCalEvents = new List<Event>();
            for (int i = 0; i < tables.Count(); i++)
            {

                foreach (DataRow row in tables[i].Rows)


                {
                    string x = row["EventID"].ToString();


                    Event add = new Event(user, x );
                    CoolCalEvents.Add(add);

                }
            }
            return CoolCalEvents.ToArray();
        }
        public Event EventCreator(CoolCalUser users)
        {
            int i = 0;
           string description = Validations.Words("Please Enter the Description ");
            DataTable data = DatabaseConnection.queryDatabase(@"Select Distinct Color from Events ;");
            Dictionary<int, string> SelectColor = new Dictionary<int, string>();
            foreach(DataRow row in data.Rows) { Console.WriteLine($"{i + 1} + {row["Color"].ToString()}"); SelectColor.Add(i, row["Color"].ToString()); i++; }
            int select = Validations.GetInt( 1, i + 1, "Select Your Colors Number : ");
            string color = SelectColor[select - 1];
            string dateTime = Validations.Words("Please enter the Date & Time", 10, 0, false);
            DateTime eventDateTime;

            while (!(DateTime.TryParse(dateTime, out eventDateTime)))
            {
                dateTime = Validations.Words("Please enter the Date & Time", 10, 0 , false);


            };
            string location = Validations.Words("Please Enter the Location  : ",100,0, false);
            string additionalInfo = Validations.Words("Please enter additional info : ", 100, 0, false);
            int noticication = Validations.GetInt("Enter the notification priority 1 to 4 , 4 is the highest ");
            string notes = Validations.Words("Please Enter Notes ", 100, 0, false);
            int eventType = 4;
            i = 1;
            foreach (int y in _calendarID)
            { Console.WriteLine($"Calendaer {i}"); i++; }
            int calID = Validations.GetInt(1, i, "Enter the Calendar you want to add to  :  ") - 1;
            calID = _calendarID[calID];

            string addEvent = $@"({calID}, '{description}', '{color}' , '{eventDateTime.ToString("yyyy-MM-dd HH:mm:ss")}' , '{location}', '{additionalInfo}', {noticication}, '{notes}' , {eventType} )";
            Console.WriteLine(addEvent);
            Utility.Pause();
            Event Create = Event.CreateEvent(addEvent, users);
            
            return Create;
        }
    }
}
