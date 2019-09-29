using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace leeHart_ConvertedData
{
    class RestaurantReviewGraphs : RestaurantGraphRater

    {
        string _info;
        public decimal Bar;
        public RestaurantReviewGraphs(string name, string info, decimal rating) : base(name, rating)
        {

            _info = info;

            Bar = rating;
        }



        public override string ToString()
        {
           
            Console.WriteLine(_info);
            AnimatedBar.BarMaker(Bar);
            Console.WriteLine(Bar);
            return null;
        }

    }
    
     
        
    
}
