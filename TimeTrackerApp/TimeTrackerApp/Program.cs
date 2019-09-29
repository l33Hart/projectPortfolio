using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TimeTrackerApp
{
    class Program
    {
        
        static void Main(string[] args)
        {

            bool run = false;
            string userName;
            int user;
            
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Utility.Pause();
            userName = Validations.Words("Please enter your userName : ",1,1,false);
            run = DatabaseConnection.login(userName);
            int.TryParse(userName, out user);
            if (run)
            {
                Menu.MenuStart(user);
            }
        }



    }
}
