using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireDeckTest
{
    class Deck
    {
        public int DeckSize { get; set; }
        public int oneCostCards { get; set; }
        public int twoCostCards { get; set; }
        public int threeCostCards { get; set; }
        public int startingHandSize { get; set; }
        // deck constructor
        public Deck()
        {
            int DeckSize = 20;
            int oneCostCards = 8;
            int twoCostCards = 6;
            int threeCostCards = 6;
            int startingHandSize = 3;


        }

        static void CreateDeck()
        {

        }

    }
}
//i need to figure out a curve for 20 cards with the 7 cards
//8 random 1 cost, 6 random 2 cost, 6 random 3 cost, 

//need to create a hand and draw function for the deck
//add card objects to a list to create the deck