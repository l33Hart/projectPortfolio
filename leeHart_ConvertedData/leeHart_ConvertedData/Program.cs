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
using System.Timers;

namespace leeHart_ConvertedData
{
    
    class Program
    {
       

        static void Main(string[] args)

        {



            int score;
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

                    case 3:
                        {
                            AnimatedBarGraph animation = new AnimatedBarGraph();
                            string mess = "What would you like to do? \r\n1. Show Average of Reviews for Restaurants\r\n2. Dinner Spinner\r\n3. Top 10 Restaurants";
                            int i = 1;
                            int d = Validations.GetInt(mess+"\r\nPlease enter your selection.  : ");
                            RestaurantReviewGraphs[] Graphs = restaurantReviewsData.ReviewGraphs();
                            List<RestaurantReviewGraphs> _graphs = new List<RestaurantReviewGraphs>();
                            switch (d)
                            {
                                
                                case 1:

                                    {
                                        Graphs = restaurantReviewsData.ReviewGraphs();
                                        foreach (RestaurantReviewGraphs reviewAvg in Graphs)
                                        {
                                            Console.WriteLine(i + "\r\n"); reviewAvg.ToString();
                                            if (i % 10 == 0) { Utility.Pause("Press Space Bar to See the Next 10 : "); }
                                            i++;
                                        }
                                        Utility.Pause();
                                    } break;
                                case 2:
                                    {
                                       _graphs = restaurantReviewsData.ReviewedGraphs();
                                        foreach (RestaurantReviewGraphs reviewAvg in _graphs)
                                        {
                                            Console.WriteLine(i + "\r\n"); reviewAvg.ToString();
                                            if (i % 10 == 0) { Utility.Pause("Press Space Bar to End : "); }
                                            i++;
                                        }

                                    }
                                    break;
                                case 3:
                                    {
                                        _graphs = restaurantReviewsData.ReviewedGraphsTopTen();
                                        foreach (RestaurantReviewGraphs reviewAvg in _graphs)
                                        {
                                            Console.WriteLine(i + "\r\n"); reviewAvg.ToString();
                                            if (i % 10 == 0) { Utility.Pause("Press Space Bar to End : "); }
                                            i++;
                                        }
                                    } break;


                            }

                            
                            
                            Dictionary<int, RestaurantReviewGraphs[]> review = restaurantReviewsData.AllReviews();

                           
                            
                            
                        }break;

                    case 4:
                        {

                            
                                bool runs = true;
                                do
                                {
                                List<Players> currentPlayers = new List<Players>();

                                int playnum = 0;

                                CardGame1 currentGame = new CardGame1();
                                int i = 1;
                                
                                List<Cards>[] allhands = currentGame.Deal(13, 4);
                                foreach (List<Cards> hands in allhands)
                                    {
                                    
                                    score = currentGame.Score(hands);
                                    Players player = new Players(score, hands,i);
                                    currentPlayers.Add(player);
                                    i++;
                                    }
                               
                                    foreach (Players player in currentPlayers)
                                    {
                                    
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(player.ToString());
                                    foreach(Cards card in player.Hand)
                                    {
                                        Console.Write(card.ToString()); Console.BackgroundColor = ConsoleColor.Black; Console.Write(" ");
                                    }
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                currentGame.Results(currentPlayers);
                                Utility.Pause("Hit Space Bar to Continue");
                                runs = Validations.GetBool("Do you want to play again? : ");

                            } while (runs);
                            
                        }break;




                    case 5: { running = false; } break;
                    default: { Console.WriteLine("Program Unavailable or invalid selection");
                            Utility.Pause();
                        } break;

                }

            } while (running);
        }





    }
}