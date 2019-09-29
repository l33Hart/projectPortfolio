using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leeHart_ConvertedData
{
    class Cards
    {
        int Suit;
       public int Card;
       private Cards( int z, int suit)
        {
            Suit = suit;
            Card = z;




        }

        public static List<Cards> Deck()
        {
            List<Cards> deck = new List<Cards>();
            int s = 1;
            int i = 1;
            int y = 52;
            for (int g = 0; g < y; g++)
            {
                Cards add = new Cards(i, s);

                if (i * 4 == y)
                {

                    i = 1; s++;
                }
                else { i++; }
                deck.Add(add);
            }
            
            return deck;

        }
        
        public override string ToString()
        {
            
            Console.BackgroundColor = ConsoleColor.White;
            string Cards;
            string cards = "";
            string suit = "";
            if (Suit == 1 || Suit == 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (Suit == 1)
                { suit = "♥"; }
                if (Suit == 2)
                {
                    suit = "♦";
                }
            }
            if (Suit == 3 || Suit == 4)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                if (Suit == 3)
                { suit = "♠"; }
                if (Suit == 4)
                { suit = "♣"; }
            }
            if (Card == 1) { cards = " A"; }
            if (Card > 1 && Card < 10)
            { cards = Card.ToString(" 0"); }
            if (Card == 10) {cards =  Card.ToString(" 00"); }
            if (Card == 11)
            { cards = " J"; }
            if(Card == 12)
            { cards = " Q"; }
            if (Card == 13)
            { cards = " K"; }
            Cards = $"{cards} {suit}".PadRight(6, ' ');
            

            return Cards;
        }
    }
}
