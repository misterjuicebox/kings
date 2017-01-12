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

public class Can
{
    public List<Card> canlist = new List<Card>();
    public int pop_number;
    public string beer_type;

    public Can(string beer)
    {
        Random rnd = new Random();
        pop_number = rnd.Next(15,26);
        beer_type = beer;
    }

}

    public class PlayerList
    {
        public List<Player> player_list = new List<Player>();
    }
    public class Player
    {
        public string name;
        public string gender;
        public int drinks;
        public string intoxication; 
        public List<Card> myhand = new List<Card>();

        public Player(string player_name, string gender_tag)
        {
            name = player_name;
            gender = gender_tag;
            drinks = 0;
        }

        public Card draw(Deck deck, Can can, PlayerList list)
        {
            Card oneCard = deck.deal();
            can.canlist.Add(oneCard);
            Console.WriteLine(oneCard.val + " " + oneCard.suit);
            if(oneCard.numerical_value == 1)
            {
                Console.WriteLine("Waterfall - Every player begins drinking, and no one can stop until the player before them does");
                for(int i = 0; i < list.player_list.Count; i++)
                {
                    list.player_list[i].drinks += 2;
                }
            }
            if(oneCard.numerical_value == 2)
            {
                Console.WriteLine("You - " + name + " assigns a drink. Enter the name of another player below.");
                string assign = Console.ReadLine();
                Console.WriteLine(assign + " drinks.");
                for(int i = 0; i < list.player_list.Count; i++)
                {
                    if(list.player_list[i].name == assign)
                    {
                        list.player_list[i].drinks += 1;
                    }
                }

            }
            if(oneCard.numerical_value == 3)
            {
                Console.WriteLine("Me - " + name + " drinks");
                drinks += 1;
            }
            if(oneCard.numerical_value == 4)
            {
                Console.WriteLine("Floor - Everyone races to touch the floor, last person to do so drinks");
            }
            if(oneCard.numerical_value == 5)
            {
                Console.WriteLine("Guys - Drink: ");
                for(int i = 0; i < list.player_list.Count; i++)
                {
                    if(list.player_list[i].gender == "male")
                    {
                    Console.WriteLine("Drink, " + list.player_list[i].name + ".");
                    drinks += 1;
                    }
                }
            }
            if(oneCard.numerical_value == 6)
            {
                Console.WriteLine("Ladies - Drink: ");
                for (int i = 0; i < list.player_list.Count; i++)
                {
                    if(list.player_list[i].gender == "female")
                    {
                     Console.WriteLine("Drink, " + list.player_list[i].name + ".");  
                     drinks += 1; 
                    }
                }
            }
            if(oneCard.numerical_value == 7)
            {
                Console.WriteLine("Heaven - All players point towards the sky, last player to do so drinks");
            }
            if(oneCard.numerical_value == 8)
            {
                Console.WriteLine("Date - Pick a person to drink with. Enter another players' name below.");
                string date = Console.ReadLine();
                Console.WriteLine(date + " drink with " + name);
                for(int i = 0; i < list.player_list.Count; i++)
                {
                    if(list.player_list[i].name == date)
                    {
                        drinks += 1;
                    }
                }
            }
            if(oneCard.numerical_value == 9)
            {
                Console.WriteLine("Rhyme - Say a phrase, and everyone else must say phrases that rhyme");
            }
            if(oneCard.numerical_value == 10)
            {
                Console.WriteLine("Categories - Pick a category, and say something from that category (i.e. if 'drinking games' was the category, 'kings' would be a viable answer.");
            }
            if(oneCard.numerical_value == 11)
            {
                Console.WriteLine("Never have I ever - Each player puts up 3 fingers, then starting with the person who drew the card, each player says 'never have I ever'. If you've done it, you put a finger down, until someone loses");
            }
            if(oneCard.numerical_value == 12)
            {
                Console.WriteLine("Questions - The person who drew the card asks a random person a question, and they then turn and ask a random person a question, until someone loses by either failing to ask a question or by responding to the person who just asked them a question");
            }
            if(oneCard.numerical_value == 13)
            {
                Console.WriteLine("Make a rule that everyone must follow until the next King is drawn (i.e. force everyone to drink after each turn)");
            }

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
            Console.WriteLine("Welcome to C# Kings! Let's get wasted!");
            Deck kings_deck = new Deck();
            PlayerList gamelist = new PlayerList();
            Console.WriteLine("What kind of beer will you get hosed with today?");
            string beer_choice = Console.ReadLine();
            Can kings_can = new Can(beer_choice);
            Console.WriteLine(kings_can.beer_type + " great choice!");
            Console.WriteLine("How many fools will be getting sloshed?");
            int num_players = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < num_players; i++)
            {
                Console.WriteLine("Enter player name.");
                string input_name = Console.ReadLine();
                Console.WriteLine("Enter gender ('male' or 'female').");
                string input_gender = Console.ReadLine();
                Player player_name = new Player(input_name, input_gender);
                gamelist.player_list.Add(player_name);
            }
            Console.WriteLine("Press Enter to shuffle the deck and deal them around the " + kings_can.beer_type + ".");
            Console.ReadLine();
            kings_deck.shuffle();
            while(kings_can.canlist.Count != kings_can.pop_number)
            {
                for(int i = 0; i < gamelist.player_list.Count; i++)
                {
                    Console.WriteLine("Your turn, " + gamelist.player_list[i].name + " press Enter to continue.");
                    Console.ReadLine();
                    gamelist.player_list[i].draw(kings_deck, kings_can, gamelist);
                    Console.WriteLine("Press Enter to end turn");
                    Console.ReadLine();
                    if(kings_can.canlist.Count == kings_can.pop_number)
                    {
                        Console.WriteLine(gamelist.player_list[i].name + " popped the top. You won Kings! Chug your " + kings_can.beer_type + "!");
                        break;
                    }
                }
            }
            for(int i = 0; i < gamelist.player_list.Count; i++)
            {
                if(gamelist.player_list[i].drinks < 5)
                {
                    Console.WriteLine(gamelist.player_list[i].name + " is a sober Sally. They have had " + gamelist.player_list[i].drinks + " drinks.");
                }
                else if(gamelist.player_list[i].drinks < 15)
                {
                    Console.WriteLine(gamelist.player_list[i].name + " is getting pretty tanked. They have had " + gamelist.player_list[i].drinks + " drinks.");
                }
                else
                {
                    Console.WriteLine(gamelist.player_list[i].name + " is blacked out! Somebody get that kid some water.");
                }
                
            }
        }
        }
    }

