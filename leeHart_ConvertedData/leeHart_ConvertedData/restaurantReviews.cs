using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leeHart_ConvertedData
{
    class RestaurantsReviews
    {
        string name;
        decimal rating;
        public void RestaurantReviews(string restaurantName, decimal rate)
        { Name = restaurantName;
            Rating = rate;
        }

        public string Name { get { return name; } set {name = value; } }
        public decimal Rating { get { return rating; } set { rating = value; } }

        public override string ToString()
        {
            string RestName = Name;
            int pad = 50;
                pad -= RestName.Count();
            Name = RestName.PadRight(50, ' ');

            return Name;

        }
        public static void ColorStarPrinter(List<RestaurantsReviews> reviews )
        {
            foreach (RestaurantsReviews pairs in reviews)
            {
                if (pairs.Rating <= 2.49m)
                {
                    

                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("Restaurant Name : " + pairs.ToString() + "Rating          : ");

                    if (pairs.Rating <= 0) { Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine("NO RATING"); Console.ForegroundColor = ConsoleColor.Gray; }
                    if (pairs.Rating <= 1.49m && pairs.Rating > 0) { Console.ForegroundColor = ConsoleColor.Red; Console.Write("*"); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine("****"); }
                    if (pairs.Rating > 1.49m) { Console.ForegroundColor = ConsoleColor.Red; Console.Write("**"); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine("***"); }
                }
                if (pairs.Rating <= 3.49m && pairs.Rating >= 2.49m)
                {

                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("Restaurant Name : " + pairs.ToString() + "Rating          : ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("***");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("**");

                }

                if (pairs.Rating > 3.49m)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("Restaurant Name : " + pairs.ToString() + "Rating          : ");
                    if (pairs.Rating > 3.49m && pairs.Rating <= 4.49m) { Console.ForegroundColor = ConsoleColor.Green; Console.Write("****"); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine("*"); }
                    if (pairs.Rating > 4.49m) { Console.ForegroundColor = ConsoleColor.Green; Console.Write("*****"); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine(""); }

                }
            }
            Utility.Pause("\r\nPress R to continue\r\n");Console.Clear();
        }
    }
}
