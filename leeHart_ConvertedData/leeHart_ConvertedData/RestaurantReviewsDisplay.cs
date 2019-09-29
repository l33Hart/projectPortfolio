using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace leeHart_ConvertedData
{
    class RestaurantReviewsDisplay
    {
        public RestaurantReviewsDisplay() { }

        public void runRestaurantReviews()
        {

            bool running = true;
            string RestaurantProfiles = @"Select * from `RestaurantProfiles`;";
            string menustring = " Hello user, How would you like to sort the data:\r\n" +
       "1. List Restaurants Alphabetically(Show Rating Next To Name)\r\n" +
       "2. List Restaurants in Reverse Alphabetical(Show Rating Next To Name)\r\n" +
       "3. Sort Restaurants From Best to Worst(Show Rating Next To Name)\r\n" +
       "4. Sort Restaurants From Worst to Best(Show Rating Next To Name)\r\n" +
       "5. Show Only X stars and Up\r\n" +
            "6. Exit \r\n";
            string menuSub = "" +
                 "1. Show the Best(5 Stars)\r\n" +
                 "2. Show 4 Stars and Up\r\n" +
                 "3. Show 3 Stars and Up\r\n" +
                 "4. Show the Worst(1 Stars)\r\n" +
                 "5. Show Unrated\r\n" +
                 "6. Back\r\n" +
                 "7. Exit \r\n";
            do
            {

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Clear();
                int selection = Validations.GetInt(menustring + "Make A Selection 1 through 5 : ");
                
                Console.ForegroundColor = ConsoleColor.Gray;
                switch (selection)
                {
                    case 1:
                        {
                            RestaurantProfiles = @"Select RestaurantName, OverallRating from RestaurantProfiles order by RestaurantName ASC ;";
                            List<RestaurantsReviews> reviews = ReviewsQuery(RestaurantProfiles);
                            RestaurantsReviews.ColorStarPrinter(reviews);

                        }; break;
                    case 2:
                        {
                            RestaurantProfiles = @"Select RestaurantName, OverallRating from RestaurantProfiles order by RestaurantName DESC ;";
                            List<RestaurantsReviews> reviews = ReviewsQuery(RestaurantProfiles);
                            RestaurantsReviews.ColorStarPrinter(reviews);
                        }
                        break;
                    case 3:
                        {

                            RestaurantProfiles = @"Select RestaurantName, OverallRating from RestaurantProfiles order by OverallRating DESC ;";
                            List<RestaurantsReviews> reviews = ReviewsQuery(RestaurantProfiles);
                            RestaurantsReviews.ColorStarPrinter(reviews);
                        }
                        break;
                    case 4:
                        {
                            RestaurantProfiles = @"Select RestaurantName, OverallRating from RestaurantProfiles order by OverallRating ASC ;";
                            List<RestaurantsReviews> reviews = ReviewsQuery(RestaurantProfiles);
                            RestaurantsReviews.ColorStarPrinter(reviews);
                        }
                        break;
                    case 5:
                        {
                            int selectionSub = Validations.GetInt(menuSub + "Make A Selection 1 through 7 : ");
                            switch (selectionSub)
                            {
                                case 1:
                                    {
                                        RestaurantProfiles = @"Select RestaurantName, OverallRating from RestaurantProfiles where OverallRating >= 4.50  order by OverallRating DESC ;";
                                        List<RestaurantsReviews> reviews = ReviewsQuery(RestaurantProfiles);
                                        RestaurantsReviews.ColorStarPrinter(reviews);
                                    } break;
                                case 2:
                                    {
                                        RestaurantProfiles = @"Select RestaurantName, OverallRating from RestaurantProfiles where OverallRating >= 3.50  order by OverallRating DESC ;";
                                        List<RestaurantsReviews> reviews = ReviewsQuery(RestaurantProfiles);
                                        RestaurantsReviews.ColorStarPrinter(reviews);
                                    } break;
                                case 3:
                                    {
                                        RestaurantProfiles = @"Select RestaurantName, OverallRating from RestaurantProfiles where OverallRating >= 2.50  order by OverallRating DESC ;";
                                        List<RestaurantsReviews> reviews = ReviewsQuery(RestaurantProfiles);
                                        RestaurantsReviews.ColorStarPrinter(reviews);
                                    } break;
                                case 4:
                                    {
                                        RestaurantProfiles = @"Select RestaurantName, OverallRating from RestaurantProfiles where OverallRating <= 1.49 and OverallRating >=.50  order by OverallRating DESC ;";
                                        List<RestaurantsReviews> reviews = ReviewsQuery(RestaurantProfiles);
                                        RestaurantsReviews.ColorStarPrinter(reviews);
                                    } break;
                                case 5:
                                    {
                                        RestaurantProfiles = @"Select RestaurantName, OverallRating from RestaurantProfiles where OverallRating <=> 0.00 or OverallRating <=> NULL  order by OverallRating DESC ;";
                                        List<RestaurantsReviews> reviews = ReviewsQuery(RestaurantProfiles);
                                        RestaurantsReviews.ColorStarPrinter(reviews);
                                    } break;
                                case 6: { } break;
                                case 7: { running = false; } break;
                                default: { Console.ForegroundColor = ConsoleColor.DarkRed; Console.Write("YOU BROKE ME"); } break;




                            }
                           

                        }
                        break;
                    case 6: { running = false; } break;

                    default:
                        { }
                        break;
                }

                Utility.Pause("PRESS R TO CONTINUE");
               

            } while (running);
        }
        public List<RestaurantsReviews> ReviewsQuery(string RestaurantProfiles)
        {
            DataTable newTable = restaurantReviewsData.RestaurauntData(RestaurantProfiles);
            List<RestaurantsReviews> reviews = new List<RestaurantsReviews>();
            foreach (DataRow row in newTable.Rows)
            {

                string one = row[@"RestaurantName"].ToString();
                string key = row[@"OverallRating"].ToString();
                decimal two;
                decimal.TryParse(key, out two);
                RestaurantsReviews restReview = new RestaurantsReviews();
                restReview.Name = one;
                restReview.Rating = two;
                reviews.Add(restReview);


            }
            return reviews;
        }
        }
        }

    

