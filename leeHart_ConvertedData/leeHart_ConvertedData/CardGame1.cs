using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leeHart_ConvertedData
{
    class CardGame1
    {
        List<Cards> _deck;
        public CardGame1 ()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            _deck = Cards.Deck();

        }

        public List<Cards>[] Deal(int perPlayer, int players)
        {
            List<Cards>[] NewGame = new List<Cards>[players];
          for(int w = 0; w < players; w++)
            {
                NewGame[w] = new List<Cards>();

            }
            
           
            for (int y = 0; y < perPlayer; y++)
            {
                
                for (int i = 0; i < players; i++)
                {
                    Cards card;
                   
                    int cardDealt = RandomNumber(0, _deck.Count - 1);
                    
                    card = _deck.ElementAt(cardDealt);
                    
                   NewGame[i % players].Add(card);
                    _deck.Remove(card);
                }
                
            }
            return NewGame;
        }
       public int Score(List<Cards> cards)
        {
            int total = 0;
            foreach(Cards card in cards)
            {
                if(card.Card == 1) { total += 15; }
                if (card.Card > 1 && card.Card <= 10)
                { total += card.Card; }
                if (card.Card == 11)
                { total += 12; }
                if (card.Card == 12)
                { total += 12; }
                if (card.Card == 13)
                { total += 12; }


            }
            
            
            return total;
        }
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);

        }
        public void Results(List<Players> currentPlayers)
        {
            for (int sc = 0; sc < currentPlayers.Count; sc++)
            {
                Players current = currentPlayers[sc];
                if (current.Score >= currentPlayers[0].Score && sc != 0)
                {
                    current = currentPlayers[0]; currentPlayers[0] = currentPlayers[sc]; currentPlayers[sc] = current;

                }
                if (current.Score == currentPlayers[0].Score && sc != 0)
                {
                    current = currentPlayers[1]; currentPlayers[1] = currentPlayers[sc]; currentPlayers[sc] = current;
                }

                if ((current.Score > currentPlayers[1].Score && current.Score < currentPlayers[0].Score) && sc != 1)
                {
                    current = currentPlayers[1]; currentPlayers[1] = currentPlayers[sc]; currentPlayers[sc] = current;
                }
                if (current.Score == currentPlayers[1].Score && sc != 1)
                {
                    current = currentPlayers[2]; currentPlayers[2] = currentPlayers[sc]; currentPlayers[sc] = current;
                }
                if ((current.Score > currentPlayers[2].Score && current.Score < currentPlayers[1].Score) && sc != 2)
                {
                    current = currentPlayers[2]; currentPlayers[2] = currentPlayers[sc]; currentPlayers[sc] = current;
                }
                if (current.Score == currentPlayers[2].Score && sc != 2)
                {
                    current = currentPlayers[3]; currentPlayers[3] = currentPlayers[sc]; currentPlayers[sc] = current;
                }

            }
            

            Console.WriteLine($"\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\nThe Highest score is {currentPlayers[0].Score}\r\n{currentPlayers[0].Name} finished with a score of {currentPlayers[0].Score}\r\n" +
                              $"{currentPlayers[1].Name}  finished with a score of  {currentPlayers[1].Score}\r\n" +
                 $"{currentPlayers[2].Name}  finished with a score of {currentPlayers[2].Score}\r\n" +
                  $"{currentPlayers[3].Name}  finished with a score of {currentPlayers[3].Score}\r\n");
         
            
        }
    }
}
