using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace leeHart_ConvertedData
{


    class AnimatedBar
    {
        
        public AnimatedBar() { }

        

        public static void BarMaker(decimal y)
        {
            decimal z = 100;
            z -= y;
            if(y == 0)
            {
                Console.BackgroundColor = ConsoleColor.Gray; Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("NO RATING"); Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;
            }
            if (y < 0 && y <= 30)
            {
                
                
                {
                    
                    for (int i = 1; i <= y; i++)
                    { Console.BackgroundColor = ConsoleColor.Red; Console.Write(" "); }
                    for (int i = 1; i <= z; i++)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.Write(" ");
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                   
                }
            }

            if (y > 30 && y < 70)
            {
                
                {
                    
                    for (int i = 1; i <= y; i++)
                    { Console.BackgroundColor = ConsoleColor.Yellow; Console.Write(" "); }
                    for (int i = 1; i <= z; i++)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.Write(" ");
                    }
                }
                Console.BackgroundColor = ConsoleColor.Black;
               
            }


            if (y > 69 && y < 101)
            {
              
                {

                    for (int i = 1; i <= y; i++)
                    { Console.BackgroundColor = ConsoleColor.Green; Console.Write(" "); }
                    for (int i = 1; i <= z; i++)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.Write(" ");
                    }
                }

                Console.BackgroundColor = ConsoleColor.Black;
               
            }



        }


    }
}
