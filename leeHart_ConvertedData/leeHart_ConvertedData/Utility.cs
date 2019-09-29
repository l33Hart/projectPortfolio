using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace leeHart_ConvertedData
{
    class Utility
    {
       public static void Pause()
        {
            Console.WriteLine("Program is paused hit any key");
            Console.ReadKey();

        }
        public static void Pause(string mess)
        {
            Console.WriteLine($"{mess}\r\nProgram is paused hit any key");
            Console.ReadKey();

        }
    }
}
