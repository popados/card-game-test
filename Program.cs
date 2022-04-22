using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireDeckTest
{

    class Program
    {

        public static int consoleWidth = 200;
        public bool createDeck = true;
        static void Main(string[] args)
        {


            Console.SetWindowSize(150, 50);
            CreateMainStory();

            //using lists for each of the areas areas
            List<Card> shuffled = new List<Card>();
            List<Card> startHand = new List<Card>();
            List<Card> fieldArea = new List<Card>();
            List<Card> graveyardArea = new List<Card>();
            //create the enemy avatar
            Card player = new FireAvatar();
            Card enemy = new WaterAvatar();

            List<Card> deck = new List<Card>
            {
            //deck created with card objects
                new ImpCard(), new ImpCard(), new ImpCard(),
                new LittleDraco(), new LittleDraco(), new LittleDraco(),
                new SpiritOFire(), new SpiritOFire(), new SpiritOFire(),
                new FireDrake(), new FireDrake(), new FireDrake(),
                new FireBall(), new FireBall(), new FireBall(),
                new FlameStrike(), new FlameStrike(), new FlameStrike(),
                new WildFire(), new WildFire(), new WildFire() };

            //these three methods are to be run first
            shuffleFunction(deck, shuffled);
            Console.SetCursorPosition(consoleWidth/2,0);
            Console.WriteLine("~~~~~~SHUFFLED~~~~~~");
            CommanderInfo(player, enemy);
            createHand(shuffled, startHand);
            //set playerTurn true
            playerTurn(player, enemy, shuffled, startHand, fieldArea, graveyardArea);
        }
                //will exit when i set playerTurn to false
            //if the player picks a card && has no mana >> go to end turn
            //must call playerTurn method again
        //
        //use commander card to track the numbers i want to use?
        //after hand selection i need field selection
        //
        //at 0 mana end turn and loop back to draw until enemy health is 0
        //

        //foreach (var card in deck) //print deck
        //{
        //    Console.WriteLine(card.ToString());
        //    //+"\n Card: {0}" , deck.IndexOf(card) + 1
        //}

        //rewrite a new method that takes all objects: shuffled, hand, field, graveyard, player, enemy
        //i need an attack function
        //maybe do a staging area??
        //
        //while player.playerTurn = true 
        //probably want this in a function
        //all 6 major objects have to be in my function


        //hand print statement
        //Console.WriteLine("~~~~~~Your Hand~~~~~~");

        //Console.WriteLine("It is your turn. Press 1 to draw.");
        //Console.WriteLine("You drew: cardName");
        //Console.WriteLine("Show hand, ask player to pick a card, and print hand. Card selected prints the stats and then asks player to play or end turn");
        //first turn selection
        //printHand(startHand);

        //hand selection

            //create hand
            //mana
            //show hp
            //show field
            //play card
            //resolve field(?) make everything attack
            //end > loop > mana up
            //have to send mana to allow cards to be cast
            //+1 mana each turn
            //


public static void CreateMainStory()
        {
            
            Console.WriteLine("    |<--- Trading Card Game! --->|");
            Console.WriteLine("|<--- Press Enter to Continue --->|");
            Console.WriteLine();
            Console.ReadKey();
        }

        public static void shuffleFunction(List<Card> deck, List<Card> shuffled)
        {

            Random ran = new Random();

            int count = deck.Count();
            int selection = 0;

            for (int i = 0; i < count; i++)
            {
                selection = ran.Next(deck.Count - 1);
                shuffled.Add(deck[selection]);
                deck.RemoveAt(selection);
            }
            //shuffled deck

            //dont need to print deck
            //foreach (var card in shuffled)
            //{
            //    Console.WriteLine("Deck number: " + (shuffled.IndexOf(card) + 1) + card.ToString());
            //}

        }
        public static void createHand(List<Card> shuffled, List<Card> startHand)
        {
            int drawSize = 3;
            int deckIndex = shuffled.Count();

            for (int i = 0; i < drawSize; i++)
            {
                startHand.Add(shuffled[0]);
                shuffled.RemoveAt(0);
            }
        }

        //could probably change this to if(firstTurn = true) { //draw one } else { //draw two }
        public static void drawFunction(List<Card> startHand, List<Card> shuffled)
        {
            Console.WriteLine("Adding one card to your hand.");
            startHand.Add(shuffled[0]);
            shuffled.RemoveAt(0);

            //Console.WriteLine();
            //Console.WriteLine("Are you going first or second? Press 1 for first and 2 for second.");
            ////create a drawCard function
            ////if firstTurn
            ////add one
            ////else add two
            //var input = Console.ReadLine();
            //Int32.TryParse(input, out int result);
            //switch (result)
            //{
            //    case 1:
            //        Console.WriteLine("Adding one card to your hand.");
            //        startHand.Add(shuffled[0]);
            //        shuffled.RemoveAt(0);
            //        break;
            //    case 2:
            //        Console.WriteLine("Adding two cards to your hand.");
            //        startHand.Add(shuffled[0]);
            //        shuffled.RemoveAt(0);
            //        startHand.Add(shuffled[0]);
            //        shuffled.RemoveAt(0);
            //        break;
            //    default:
            //        isFirstTurn(startHand, shuffled);
            //        loop
            //        break;
            //}
        }

        public static void playerTurn(Card player, Card enemy, List<Card> shuffled, List<Card> startHand, List<Card> fieldArea, List<Card> graveyard)
        {
            while (enemy.Health > 0)
            {
                //play game
                if (player.playerTurn == false)
                {

                    printField(fieldArea);
                    Console.WriteLine("player mana: {0} and player turn {0}", player.currentMana, player.playerTurnCount);
                    player.playerTurn = true;
                    drawFunction(startHand, shuffled);
                    handSelection(startHand, fieldArea, player, enemy); // have no breaks in this yet -- maybe create if statement functions
                    foreach (var card in fieldArea)
                    {
                        Console.WriteLine("Field slot {0}: " + card.CardName, fieldArea.IndexOf(card) + 1);
                        if (card.isCreature == true && card.summonSickness == false) {
                            card.dealDamage(enemy);
                            //it exits after enemy is at 0 hp
                            //looking at mono game right now
                        } else if (card.summonSickness == true) {
                            Console.WriteLine("Can't attack this turn");
                            card.summonSickness = false;
                        }
                        if (card.CardName == "Little Draco")
                        {
                            Console.WriteLine("do fire logic");
                            //nesting 6 if statements isnt bad logic is it LMAO
                        }
                    }
                    //use currentMana
                    //cost   
                }
            } //ends game
        }


        public static void handSelection(List<Card> startHand, List<Card> fieldArea, Card player, Card enemy)
        {
            //printHand(startHand, fieldArea, player, enemy);
            //if (player.currentMana <= 0)
            //{
            //    Console.WriteLine("Out of mana");
            //    endTurn(startHand, fieldArea, player, enemy);
            //}
            //else {
            //    handSelection(startHand, fieldArea, player, enemy);
            //}
            int numCard = 0;
            Console.WriteLine();
            Console.WriteLine("Look at card in your hand using 1-6. 7 to view hand. 8 To view field. 9 to quit.");
            var input = Console.ReadLine();
            Int32.TryParse(input, out numCard);
            //will default to 0 if nothing selected
            switch (numCard)
            {
                case 1:
                    try
                    {
                        Console.WriteLine("You selected: " + startHand[numCard - 1].CardName);
                        startHand[numCard - 1].printCard();
                        Console.WriteLine("Press 1 to play the card. 2 to go back to hand.");
                        var numInput = Console.ReadLine();
                        Int32.TryParse(numInput, out int choice);
                        //default || zero if nothing input
                        switch (choice)
                        {
                            case 1:
                                if (startHand[numCard - 1].isCreature == true && startHand[numCard - 1].Cost <= player.currentMana)
                                {
                                    //if creature place on field && summonSickness == true
                                    //remove from hand and place on field
                                    Console.WriteLine("You played: " + startHand[numCard - 1].CardName);
                                    startHand[numCard - 1].summonSickness = true;
                                    fieldArea.Add(startHand[numCard - 1]);
                                    startHand.RemoveAt(numCard - 1);
                                    endTurn(startHand, fieldArea, player, enemy);
                                    player.playerTurn = false;
                                    player.currentMana--;
                                    break;
                                    //handSelection(startHand, fieldArea, player, enemy);
                                }
                                else if (startHand[numCard - 1].isCreature == true && startHand[numCard - 1].Cost >= player.currentMana)
                                {
                                    Console.WriteLine("This creature costs more than 1 mana");
                                    Console.ReadKey();
                                    handSelection(startHand, fieldArea, player, enemy);
                                }
                                else if (startHand[numCard - 1].isCreature == false && startHand[numCard - 1].Cost <= player.currentMana)
                                {
                                    Console.WriteLine("You played: " + startHand[numCard - 1].CardName);
                                    fieldArea.Add(startHand[numCard - 1]);
                                    startHand.RemoveAt(numCard - 1);
                                    startHand[numCard - 1].dealDamage(enemy);
                                    player.playerTurn = false;
                                    break;
                                    //damage logic
                                }
                                else if (startHand[numCard - 1].isCreature == false && startHand[numCard - 1].Cost >= player.currentMana)
                                {
                                    Console.WriteLine("This spell costs more than 1 mana");
                                    Console.ReadKey();
                                    handSelection(startHand, fieldArea, player, enemy);
                                }

                                ////card action and select targets etc
                                //startHand[numCard - 1].dealDamage(avatar);
                                //startHand.RemoveAt(numCard - 1);
                                //start next turn
                                break;
                            case 2:
                                handSelection(startHand, fieldArea, player, enemy);
                                break;
                            default:
                                handSelection(startHand, fieldArea, player, enemy);
                                break;
                        }
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        Console.WriteLine(e.Message);
                        handSelection(startHand, fieldArea, player, enemy);
                    }
                    break;
                case 2:
                    try
                    {
                        Console.WriteLine("You selected: " + startHand[numCard - 1].CardName);
                        startHand[numCard - 1].printCard();
                        ///Console.WriteLine("You selected: " + startHand[0].CardName);
                        Console.WriteLine("Press 1 to play the card. 2 to go back to hand.");
                        var numInput = Console.ReadLine();
                        Int32.TryParse(numInput, out int choice);
                        switch (choice)
                        {
                            case 1:
                                if (startHand[numCard - 1].isCreature == true && startHand[numCard - 1].Cost <= 1)
                                {
                                    //if creature place on field && summonSickness == true
                                    //remove from hand and place on field
                                    Console.WriteLine("You played: " + startHand[numCard - 1].CardName);
                                    startHand[numCard - 1].summonSickness = true;
                                    fieldArea.Add(startHand[numCard - 1]);
                                    startHand.RemoveAt(numCard - 1);
                                    player.playerTurn = false;
                                    break;
                                }
                                else if (startHand[numCard - 1].isCreature == true && startHand[numCard - 1].Cost >= 1)
                                {
                                    Console.WriteLine("This creature costs more than 1 mana");
                                    Console.ReadKey();
                                    handSelection(startHand, fieldArea, player, enemy);
                                }
                                else if (startHand[numCard - 1].isCreature == false && startHand[numCard - 1].Cost <= 1)
                                {
                                    Console.WriteLine("You played: " + startHand[numCard - 1].CardName);
                                    fieldArea.Add(startHand[numCard - 1]);
                                    startHand.RemoveAt(numCard - 1);
                                    handSelection(startHand, fieldArea, player, enemy);
                                    startHand[numCard - 1].dealDamage(enemy);
                                    //damage logic
                                }
                                else if (startHand[numCard - 1].isCreature == false && startHand[numCard - 1].Cost >= 1)
                                {
                                    Console.WriteLine("This spell costs more than 1 mana");
                                    Console.ReadKey();
                                    handSelection(startHand, fieldArea, player, enemy);
                                }

                                ////card action and select targets etc
                                //startHand[numCard - 1].dealDamage(avatar);
                                //startHand.RemoveAt(numCard - 1);
                                //start next turn
                                break;
                            case 2:
                                handSelection(startHand, fieldArea, player, enemy);
                                break;
                            default:
                                handSelection(startHand, fieldArea, player, enemy);
                                break;
                        }
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        //throw new ArgumentOutOfRangeException("no card in this slot", e);
                        Console.WriteLine(e.Message);
                        handSelection(startHand, fieldArea, player, enemy);
                    }
                    break;
                case 3:
                    try
                    {
                        Console.WriteLine("You selected: " + startHand[numCard - 1].CardName);
                        startHand[numCard - 1].printCard();
                        ///Console.WriteLine("You selected: " + startHand[0].CardName);
                        Console.WriteLine("Press 1 to play the card. 2 to go back to hand.");
                        var numInput = Console.ReadLine();
                        Int32.TryParse(numInput, out int choice);
                        switch (choice)
                        {
                            case 1:
                                if (startHand[numCard - 1].isCreature == true && startHand[numCard - 1].Cost <= 1)
                                {
                                    //if creature place on field && summonSickness == true
                                    //remove from hand and place on field
                                    Console.WriteLine("You played: " + startHand[numCard - 1].CardName);
                                    startHand[numCard - 1].summonSickness = true;
                                    fieldArea.Add(startHand[numCard - 1]);
                                    startHand.RemoveAt(numCard - 1);
                                    handSelection(startHand, fieldArea, player, enemy);
                                }
                                else if (startHand[numCard - 1].isCreature == true && startHand[numCard - 1].Cost >= 1)
                                {
                                    Console.WriteLine("This creature costs more than 1 mana");
                                    Console.ReadKey();
                                    handSelection(startHand, fieldArea, player, enemy);
                                }
                                else if (startHand[numCard - 1].isCreature == false && startHand[numCard - 1].Cost <= 1)
                                {
                                    Console.WriteLine("You played: " + startHand[numCard - 1].CardName);
                                    fieldArea.Add(startHand[numCard - 1]);
                                    startHand.RemoveAt(numCard - 1);
                                    handSelection(startHand, fieldArea, player, enemy);
                                    //damage logic
                                }
                                else if (startHand[numCard - 1].isCreature == false && startHand[numCard - 1].Cost >= 1)
                                {
                                    Console.WriteLine("This spell costs more than 1 mana");
                                    Console.ReadKey();
                                    handSelection(startHand, fieldArea, player, enemy);
                                }

                                ////card action and select targets etc
                                //startHand[numCard - 1].dealDamage(avatar);
                                //startHand.RemoveAt(numCard - 1);
                                //start next turn
                                break;
                            case 2:
                                handSelection(startHand, fieldArea, player, enemy);
                                break;
                            default:
                                handSelection(startHand, fieldArea, player, enemy);
                                break;
                        }
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        //throw new ArgumentOutOfRangeException("no card in this slot", e);
                        Console.WriteLine(e.Message);
                        handSelection(startHand, fieldArea, player, enemy);
                    }
                    break;
                case 4:
                    try
                    {
                        Console.WriteLine("You selected: " + startHand[numCard - 1].CardName);
                        startHand[numCard - 1].printCard();
                        ///Console.WriteLine("You selected: " + startHand[0].CardName);
                        Console.WriteLine("Press 1 to play the card. 2 to go back to hand.");
                        var numInput = Console.ReadLine();
                        Int32.TryParse(numInput, out int choice);
                        switch (choice)
                        {
                            case 1:
                                if (startHand[numCard - 1].isCreature == true && startHand[numCard - 1].Cost <= 1)
                                {
                                    //if creature place on field && summonSickness == true
                                    //remove from hand and place on field
                                    Console.WriteLine("You played: " + startHand[numCard - 1].CardName);
                                    startHand[numCard - 1].summonSickness = true;
                                    fieldArea.Add(startHand[numCard - 1]);
                                    startHand.RemoveAt(numCard - 1);
                                    handSelection(startHand, fieldArea, player, enemy);
                                }
                                else if (startHand[numCard - 1].isCreature == true && startHand[numCard - 1].Cost >= 1)
                                {
                                    Console.WriteLine("This creature costs more than 1 mana");
                                    Console.ReadKey();
                                    handSelection(startHand, fieldArea, player, enemy);
                                }
                                else if (startHand[numCard - 1].isCreature == false && startHand[numCard - 1].Cost <= 1)
                                {
                                    Console.WriteLine("You played: " + startHand[numCard - 1].CardName);
                                    fieldArea.Add(startHand[numCard - 1]);
                                    startHand.RemoveAt(numCard - 1);
                                    handSelection(startHand, fieldArea, player, enemy);
                                    //damage logic
                                }
                                else if (startHand[numCard - 1].isCreature == false && startHand[numCard - 1].Cost >= 1)
                                {
                                    Console.WriteLine("This spell costs more than 1 mana");
                                    Console.ReadKey();
                                    handSelection(startHand, fieldArea, player, enemy);
                                }

                                ////card action and select targets etc
                                //startHand[numCard - 1].dealDamage(avatar);
                                //startHand.RemoveAt(numCard - 1);
                                //start next turn
                                break;
                            case 2:
                                handSelection(startHand, fieldArea, player, enemy);
                                break;
                            default:
                                handSelection(startHand, fieldArea, player, enemy);
                                break;
                        }
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        //throw new ArgumentOutOfRangeException("no card in this slot", e);
                        Console.WriteLine(e.Message);
                        handSelection(startHand, fieldArea, player, enemy);
                    }
                    break;
                case 5:
                    try
                    {
                        Console.WriteLine("You selected: " + startHand[numCard - 1].CardName);
                        startHand[numCard - 1].printCard();
                        ///Console.WriteLine("You selected: " + startHand[0].CardName);
                        Console.WriteLine("Press 1 to play the card. 2 to go back to hand.");
                        var numInput = Console.ReadLine();
                        Int32.TryParse(numInput, out int choice);
                        switch (choice)
                        {
                            case 1:
                                if (startHand[numCard - 1].isCreature == true && startHand[numCard - 1].Cost <= 1)
                                {
                                    //if creature place on field && summonSickness == true
                                    //remove from hand and place on field
                                    Console.WriteLine("You played: " + startHand[numCard - 1].CardName);
                                    startHand[numCard - 1].summonSickness = true;
                                    fieldArea.Add(startHand[numCard - 1]);
                                    startHand.RemoveAt(numCard - 1);
                                    handSelection(startHand, fieldArea, player, enemy);
                                }
                                else if (startHand[numCard - 1].isCreature == true && startHand[numCard - 1].Cost >= 1)
                                {
                                    Console.WriteLine("This creature costs more than 1 mana");
                                    Console.ReadKey();
                                    handSelection(startHand, fieldArea, player, enemy);
                                }
                                else if (startHand[numCard - 1].isCreature == false && startHand[numCard - 1].Cost <= 1)
                                {
                                    Console.WriteLine("You played: " + startHand[numCard - 1].CardName);
                                    fieldArea.Add(startHand[numCard - 1]);
                                    startHand.RemoveAt(numCard - 1);
                                    handSelection(startHand, fieldArea, player, enemy);
                                    //damage logic
                                }
                                else if (startHand[numCard - 1].isCreature == false && startHand[numCard - 1].Cost >= 1)
                                {
                                    Console.WriteLine("This spell costs more than 1 mana");
                                    Console.ReadKey();
                                    handSelection(startHand, fieldArea, player, enemy);
                                }

                                ////card action and select targets etc
                                //startHand[numCard - 1].dealDamage(avatar);
                                //startHand.RemoveAt(numCard - 1);
                                //start next turn
                                break;
                            case 2:
                                handSelection(startHand, fieldArea, player, enemy);
                                break;
                            default:
                                handSelection(startHand, fieldArea, player, enemy);
                                break;
                        }
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        //throw new ArgumentOutOfRangeException("no card in this slot", e);
                        Console.WriteLine(e.Message);
                        handSelection(startHand, fieldArea, player, enemy);
                    }
                    break;
                case 6:
                    try
                    {
                        Console.WriteLine("You selected: " + startHand[numCard - 1].CardName);
                        startHand[numCard - 1].printCard();
                        ///Console.WriteLine("You selected: " + startHand[0].CardName);
                        Console.WriteLine("Press 1 to play the card. 2 to go back to hand.");
                        var numInput = Console.ReadLine();
                        Int32.TryParse(numInput, out int choice);
                        switch (choice)
                        {
                            case 1:
                                if (startHand[numCard - 1].isCreature == true && startHand[numCard - 1].Cost <= 1)
                                {
                                    //if creature place on field && summonSickness == true
                                    //remove from hand and place on field
                                    Console.WriteLine("You played: " + startHand[numCard - 1].CardName);
                                    startHand[numCard - 1].summonSickness = true;
                                    fieldArea.Add(startHand[numCard - 1]);
                                    startHand.RemoveAt(numCard - 1);
                                    handSelection(startHand, fieldArea, player, enemy);
                                }
                                else if (startHand[numCard - 1].isCreature == true && startHand[numCard - 1].Cost >= 1)
                                {
                                    Console.WriteLine("This creature costs more than 1 mana");
                                    Console.ReadKey();
                                    handSelection(startHand, fieldArea, player, enemy);
                                }
                                else if (startHand[numCard - 1].isCreature == false && startHand[numCard - 1].Cost <= 1)
                                {
                                    Console.WriteLine("You played: " + startHand[numCard - 1].CardName);
                                    fieldArea.Add(startHand[numCard - 1]);
                                    startHand.RemoveAt(numCard - 1);
                                    //damage logic
                                }
                                else if (startHand[numCard - 1].isCreature == false && startHand[numCard - 1].Cost >= 1)
                                {
                                    Console.WriteLine("This spell costs more than 1 mana");
                                    Console.ReadKey();
                                    handSelection(startHand, fieldArea, player, enemy);
                                }

                                ////card action and select targets etc
                                //startHand[numCard - 1].dealDamage(avatar);
                                //startHand.RemoveAt(numCard - 1);
                                //start next turn
                                break;
                            case 2:
                                handSelection(startHand, fieldArea, player, enemy);
                                break;
                            default:
                                handSelection(startHand, fieldArea, player, enemy);
                                break;
                        }
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        //throw new ArgumentOutOfRangeException("no card in this slot", e);
                        Console.WriteLine(e.Message);
                        handSelection(startHand, fieldArea, player, enemy);
                    }
                    break;
                case 7:
                    printHand(startHand, fieldArea, player, enemy);
                    handSelection(startHand, fieldArea, player, enemy);
                    break;
                case 8:
                    CommanderInfo(player, enemy);
                    printField(fieldArea);
                    endTurn(startHand, fieldArea, player, enemy);
                    break;
                case 9:
                    endTurn(startHand, fieldArea, player, enemy);
                    break;
                default:
                    handSelection(startHand, fieldArea, player, enemy);
                    break;
            }
        }



        public static void CommanderInfo(Card player, Card enemy)
        {
            Console.WriteLine("----Your Commanders Info---");
            player.printCard();
            Console.WriteLine("---Enemy Commander Info---");
            enemy.printCard();
        }

        public static void printHand(List<Card> startHand, List<Card> fieldArea, Card player, Card enemy)
        {
            //print hand
            Console.WriteLine("~~~~~~Your Hand~~~~~~");

            foreach (var card in startHand)
            {

                Console.WriteLine("Card: {0} " + card.ToString(), (startHand.IndexOf(card) + 1));
            }
            endTurn(startHand, fieldArea, player, enemy);
        }

        public static void endTurn(List<Card> startHand, List<Card> fieldArea, Card player, Card enemy)
        {
            Console.WriteLine("End turn? Press 1 for yes 2 for no.");
            var input = Console.ReadLine();
            Int32.TryParse(input, out int result);
            switch (result)
            {
                case 1:
                    Console.WriteLine("Mana++ here");
                    player.playerTurnCount++;
                    player.currentMana++;
                    player.maxMana++;
                    player.playerTurn = false;
                    break;
                case 2:
                    handSelection(startHand, fieldArea, player, enemy);
                    break;
                default:
                    Console.WriteLine("nothing here");
                    handSelection(startHand, fieldArea, player, enemy);
                    //ends
                    //send into a function for while loop
                    break;
            }
        }

        public static void printField(List<Card> fieldArea)
        {
            Console.WriteLine("*FIELD AREA*");

            foreach (var card in fieldArea)
            {
                Console.WriteLine("Field slot {0}: " + card.CardName, fieldArea.IndexOf(card) + 1);
            }
        }
    }
}
//function to create cards and add to a list?
//now that ive got my switch statements written as functions i can use them here 
//
//turns[] -- error in turn logic that doesnt always reset turn after endturn method
//--REQUIRES => player, enemy, hand, shuffled, field, graveyard
//---> something is added/removed/changed in these <---
//---> have a function that holds each turn action
//---> <start turn> <show mana> <show enemy & player hp> <show field> 
//---> <create hand> <draw> <play card> <mana up> <end turn>

//~~~~STEPS TO DO FOR TCG~~~//~~NOTES INCLUDED IN THIS~~//
//Create Deck object x
//create player object that takes inputs for other objects x
//find out what variables x
//i need to figure out a curve for 21 cards with the 7 cards
//3 of each card x
//create a hand x
//create a field x
//create a graveyard x
//each turn: draw > main phase(play cards to field) > attack phase(move to field from graveyard) > end turn
//loop turn until a player is below 0 health

//start creating program here
//for a card game the steps i need are
//create deck x
//create hand x
//select card from hand x
//play card x
//end turn x

////
//ways of creating a deck
//hard code the deck of 21 with specific cards and use loops to make multiples
//i need to put the cards into a list and then create a shuffle loop to display 3 random card names 
//to hard code the deck i need to add the number of cards at cost and duplicates
//21 cards in a deck 
//3 of each card
//
//create the cards that make the deck
//7 cards and 3 of each
//chose to create each card individually
//now I need to to shuffle the deck
////
///
//

//turn based system
//use card for the object constructor for both the player and the target
//steps to take for a single turn
//show player and enemy health and mana
//draw[x]
//select card[x]
//play card[x]
//show field(use field)[]
//select field card[]
//end turn[x]



//first loop is while player or enemy health is above 0 keep creating turns
//second loop that adds one mana to the avatar per turn to a max of 5(maybe iterate after each turn with isMaxMana)
//

//->if creature summonedSickness = false 
//-- ask if they want to attack
//->if spell cast it or go back to hand
//->if creature select to play or go back to hand
//-->same steps for player 2

//show player health and mana crystals(have 1 at the start, mana++ each looping turn to a max of 5) 
//have main loop be while (enemy.hp || player.hp > 0)  { // do logic}
//inside the main loop have a while (mana < 5) { mana++; }
//conditions of player.draw == true && player.playCard == true && player.endTurn??
//or give player options and use conditions to say playing this card isnt possible?
//

//maybe do a turn one bool
//one single turn is draw > pick > play > show field > pick > attack > end
//Second turn > automate the steps with the idea that the AI will play one > two > three mana costs
//OR I can do player turn and have player input
//

//everything is in the handselection
//my logic sends the card selected to the field
//create the loop to go through the program and adds mana
//make sure all my objects and properties allow for each method to work
//loop until health
//add each card properties as methods that check what object is in the fieldarea and plays
//