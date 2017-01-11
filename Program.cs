using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Card
    {
        public string val;
        public string suit;
        public int numerical_value;

        public Card(string uservalue, string usersuit, int usernumerical_value)
        {
            val = uservalue;
            suit = usersuit;
            numerical_value = usernumerical_value;
        }
    }

    public class Deck
    {
        public List<Card> mydeck = new List<Card>();

        public Deck()
        {
        string[] valueArray = {"A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};
        string[] suitArray = {"Clubs", "Spades", "Hearts", "Diamonds"};
        int[] numerical_valueArray = {1,2,3,4,5,6,7,8,9,10,11,12,13};

        for (int i = 0; i < suitArray.Length; i++)
        {
            for (int x = 0; x < valueArray.Length; x++)
            {
                mydeck.Add(new Card(valueArray[x],suitArray[i],numerical_valueArray[x]));
            }
        }
        }
        public Card deal()
        {
          Card deal_card = mydeck[0];
          mydeck.RemoveAt(0);
          return deal_card; 
        }

        public void shuffle()
        {
            Random rnd = new Random();
            int swap = 0; 
            for(int i = 0; i < mydeck.Count; i++)
            {
                swap = rnd.Next(0,52);
                Card temp = mydeck[swap];
                mydeck[swap] = mydeck[i];
                mydeck[i] = temp;
            }
        }
        
        public void reset()
        {
            Deck reset_deck = new Deck();
            mydeck = reset_deck.mydeck;
        }
    }

    public class Player
    {
        public string name;
        public List<Card> myhand = new List<Card>();

        public Player(string player_name)
        {
            name = player_name;
        }

        public Card draw(Deck deck)
        {
            Card oneCard = deck.deal();
            myhand.Add(oneCard);
            return oneCard;
        }

        public Boolean discard(Card mycard)
        {
            for(int i = 0; i < myhand.Count; i++)
            {
                Card test_card = myhand[i];
                if(test_card.val == mycard.val && test_card.suit == mycard.suit)
                {
                myhand.RemoveAt(i);
                return true;
                }
            }
            return false;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Deck myfirstdeck = new Deck();
            myfirstdeck.shuffle();
            myfirstdeck.reset();
            // for (int i = 0; i < myfirstdeck.mydeck.Count; i++)
            // {
            //     Console.WriteLine(myfirstdeck.mydeck[i].val);
            //     Console.WriteLine(myfirstdeck.mydeck[i].suit);
            //     Console.WriteLine(myfirstdeck.mydeck[i].numerical_value);
            // }
            // myfirstdeck.deal();
            Player chan = new Player("Johnny Chan");
            Console.WriteLine(chan.name);
            chan.draw(myfirstdeck);
            chan.draw(myfirstdeck);
            chan.discard(chan.myhand[0]);
            // Console.WriteLine(chan.myhand[0]);
            for (int i = 0; i < chan.myhand.Count; i++)
            {
                Console.WriteLine(chan.myhand[i].val);
                Console.WriteLine(chan.myhand[i].suit);
                Console.WriteLine(chan.myhand[i].numerical_value);
            }
        }
    }
}
