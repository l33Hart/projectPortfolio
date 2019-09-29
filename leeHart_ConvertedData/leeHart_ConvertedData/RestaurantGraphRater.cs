using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leeHart_ConvertedData
{
    class RestaurantGraphRater : AnimatedBar 
    {


        decimal _rating;
        string _name;



       public  RestaurantGraphRater(string name , decimal y) : base ()
        {
            _name = name;

            _rating = y;


        }

        public override string ToString()
        {

            return null;
        }

    
    }
}
