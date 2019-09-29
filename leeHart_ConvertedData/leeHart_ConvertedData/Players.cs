using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace leeHart_ConvertedData
{
    class Players
    {
       
        int _score;
        List<Cards> _hand;
        string _playerName;
        int _playerNum;
      
        public Players(int score, List<Cards> hand,int playerNum)
        {
            _playerNum = playerNum;
            _score = score;
            _hand = hand;
            string query = @"select * from RestaurantReviewers Order by RAND() limit 1;";
            DataTable PLayers = restaurantReviewsData.RestaurauntData(query);
            foreach (DataRow row in PLayers.Rows)
            {
                _playerName = $"{row["First"]} {row["Last"]}";

            }
            
        }
        public int Score { get { return _score; } set { } }
        public string Name { get { return _playerName; } set { } }

        public List<Cards> Hand{ get {return _hand;} set {} }

        public override string ToString()
        { 
            string Cards = "";
            
            return $"\r\nPlayer {_playerNum} \r\n{_playerName}\r\n{Cards} \r\nScore : {_score} \r\n ";
        }

    }
}

