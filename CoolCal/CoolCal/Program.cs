using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CoolCal
{
    class Program
    {
        public static string UserName;
        static void Main(string[] args)
        {

            UserName = Validations.Words("Please Enter User Name  :  ", 1 ,1 , false);
            CoolCalUser currentUser = new CoolCalUser(UserName);

            Event _events = new Event(currentUser);
            DataTable[] data = _events.EventFinder();
            Event[] events = currentUser.CalEvents(data, currentUser);
                bool running = true;
            while (running)
            {
                currentUser.View(events);
                Utility.Pause();
                bool run = Validations.GetBool("Do you want to add an event?");
                if (run) { currentUser.EventCreator(currentUser); }
                else{ running = false; }
            }
           
            

        }
    }
}
