using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using MySql;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Windows;


namespace leeHart_ConvertedData
{

    class Program
    {
        

        static void Main(string[] args)

        {

           


            int selection;
                bool running = true;

    


            do
            {

                Utility.Pause();

               string memu = "Hello Admin, What Would You Like To Do Today?\r\n"+ 
                "1. Convert The Restaurant Profile Table From SQL To JSON\r\n" +
                    "2.Showcase Our 5 Star Rating System\r\n" +
                   "3.Showcase Our Animated Bar Graph Review System\r\n" +
                   "4.Play A Card Game\r\n" +
                    "5.Exit\r\n";

               
                selection = Validations.GetInt(1,100, memu + "Enter Your Numbered Selection : ");

                switch (selection)
                {
                    case 1:
                        {
                            restaurantReviewsData Restaurant = new restaurantReviewsData();
                            Restaurant.runRestaurantReveiws();
                        }break;
                    case 2:
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            RestaurantReviewsDisplay restaurant = new RestaurantReviewsDisplay();
                            restaurant.runRestaurantReviews();
                        } break;








                    case 5: { running = false; } break;
                    default: { Console.WriteLine("Program Unavailable or invalid selection");
                            Utility.Pause();
                        } break;

                }

            } while (running);
        }

       




    }
}