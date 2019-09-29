using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace leeHart_ConvertedData
{
    class AnimatedBarGraph
    {
        
        private static System.Timers.Timer myAnimationTimer;


        static int myTimerCounter = 0;

        public AnimatedBarGraph()
        {

           
                SetTimer();


                Console.CursorVisible = false;


                Console.ReadLine();
           



        }
        private static void SetTimer()
        {

            myAnimationTimer = new System.Timers.Timer(50);

            myAnimationTimer.Elapsed += OnTimedEvent;


            myAnimationTimer.AutoReset = true;


            myAnimationTimer.Enabled = true;
        }




        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {

            var myBackgroundColor = ConsoleColor.Gray;
            


            myTimerCounter++;


            Random myRandomNumber = new Random();

            var theRating = myRandomNumber.Next(0, 101);

            if (theRating == 0)
            {
                Console.BackgroundColor = ConsoleColor.Gray; Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("NO RATING"); Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;
            }
            if (theRating < 30)
            {
                

                for (int ii = 0; ii <= theRating; ii++)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(" ");
                }
            }
            if (theRating > 30 && theRating < 70)
            {
                

                for (int ii = 0; ii <= theRating; ii++)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write(" ");
                }
            }
            if (theRating > 70)
            {
                

                for (int ii = 0; ii <= theRating; ii++)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write(" ");
                }
            }

            int myTotalNumber = 100;

            
            Console.BackgroundColor = myBackgroundColor;


            for (int iii = theRating; iii <= myTotalNumber; iii++)
            {
                Console.BackgroundColor = myBackgroundColor;
                Console.Write(" ");
            }


            Console.CursorLeft = 0;


            if (myTimerCounter == 50)
            {

                myAnimationTimer.Stop();

                for (int x = 0; x < 5; x++)
                {
                    Console.Write("");
                }


                Console.CursorVisible = true;

            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
