
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireDeckTest
{
    public abstract class Card
    {
        //variables for cards
        public string CardName { get; set; }
        public string CardDescription { get; set; }
        public string AbilityDescription { get; set; }
        public string CardType { get; set; }
        public int Attack { get; set; }
        public int Health { get; set; }
        public int Cost { get; set; }
        public int maxMana { get; set; }
        public int currentMana { get; set; }
        public int playerTurnCount { get; set; }
        public bool playerTurn { get; set; }
        public bool isDead { get; set; }
        public bool summonSickness { get; set; }
        public bool isCreature { get; set; }

        //constructor for cards with default values
        //all cards are created as Card card = new CardName();
        //all commented out code between class and constructor in inheirented classes is for saving
        public Card()
        {
            CardName = "Card Name";
            CardDescription = "Card Description";
            AbilityDescription = "N/A";
            CardType = "Creature or Spell";
            Attack = 0;
            Health = 0;
            Cost = 0;
            isCreature = false;
            summonSickness = false;
        }

        public override string ToString()
        {
            return ":--" + CardName + "--:";
            //+ "\t Mana Cost: " + Cost
        }
        public void printCard() {
            Console.WriteLine("Card: " + CardName +
                 "\n Description: " + CardDescription +
                "\n Ability: " + AbilityDescription +
                "\n Type: " + CardType +
                "\n Attack: " + Attack +
                "\n Health: " + Health +
                "\n Cost: " + Cost + 
                "\n Just summoned: " + summonSickness);
            Console.WriteLine();
            //Console.ReadKey();
        }
        public virtual void dealDamage(Card target)
        {
            target.Health -= Attack;
            Console.WriteLine(CardName + " attacked for {0} damage", Attack);
            //could nest my if statements here
            //each creature is summoned > summonedSickness
            //ability function?? could over ride an empty ability
            //i want it to go like this player sel > card > field > ability > attack > end
            //i have sel > card > field > attack > end
            //each card can have an ability that checks field area
            //i.e fire drake gains +1/+1 atk/hp if (card.cardName = fire draco)
            //
        }
        //most of these need to rely on the card triggering the effect
        //could check field and if > creature && has effect
        //
        
        //enum each type maybe to make an easy property to read for the card
        //creature damage[x]
        //spell damage[x]
        //aura[] -- spell damage doesnt work
        //call[] -- additional summon from hand
        //defender[] -- blocker
        //first strike[] -- only attack creature && if summoned = true
        //force[] -- return creature card to hand
        //hyper[] -- creature ignores summoning sickness
        //last will[] -- effect trigger in graveyard
        //mute[] -- removes effects of creature
        //overkill[] -- defender destroyed deals damage to its hp
        //overpower[] -- destroy defenders immediately
        //rally[] -- additional summon from deck
        //ressurect[] -- happen from graveyard
        //ritual[] -- play cost to do effect
        //unstoppable[] -- can attack directly

    }
    public class ImpCard : Card
    {
        //string CardName = "Imp";
        //string CardDescription = "Totally not a Warlock pet.";
        //string AbilityDescription = "N/A";
        //string CardType = "Creature";
        //int Attack = 3;
        //int Health = 1;
        //int Cost = 1;
        public ImpCard()
        {
            CardName = "Imp";
            CardDescription = "Totally not a Warlock pet.";
            AbilityDescription = "N/A";
            CardType = "Creature";
            Attack = 3;
            Health = 1;
            Cost = 1;
            isCreature = true;
            isDead = false;
            summonSickness = false;
            //nothing but an attack
        }
        public override void dealDamage(Card target)
        {
            target.Health -= Attack;
        }
    }
    public class LittleDraco : Card
    {
        //string CardName = "Little Draco";
        //string CardDescription = "Small Dragon.";
        //string AbilityDescription = "N/A";
        //string CardType = "Creature";
        //int Attack = 1;
        //int Health = 3;
        //int Cost = 1;
        public LittleDraco()
        {
            CardName = "Little Draco";
            CardDescription = "Small Dragon.";
            AbilityDescription = "N/A";
            CardType = "Creature";
            Attack = 1;
            Health = 3;
            Cost = 1;
            isCreature = true;
            isDead = false;
            summonSickness = false;
            //nothing will use card name for fire drake

        }
    }
    public class SpiritOFire : Card
    {
        //string CardName = "Spirit Of Fire";
        //string CardDescription = "Its the spirit of da fire, mon.";
        //string AbilityDescription = "N/A";
        //string CardType = "Creature";
        //int Attack = 3;
        //int Health = 4;
        //int Cost = 2;
        public SpiritOFire()
        {
            CardName = "Spirit Of Fire";
            CardDescription = "Its the spirit of da fire, mon.";
            AbilityDescription = "N/A";
            CardType = "Creature";
            Attack = 3;
            Health = 4;
            Cost = 2;
            isCreature = true;
            isDead = false;
            summonSickness = false;
            //if spirit fire dies(last will) {1 damage}
        }
    }
    public class FireDrake : Card
    {
        //string CardName = "Fire Drake";
        //string CardDescription = "Big Big Dragon.";
        //string AbilityDescription = "+1/+1 for each Little Draco in play.";
        //string CardType = "Creature";
        //int Attack = 5;
        //int Health = 3;
        //int Cost = 3;
        public FireDrake()
        {
            CardName = "Fire Drake";
            CardDescription = "Big Big Dragon.";
            AbilityDescription = "+1/+1 for each Little Draco in play.";
            CardType = "Creature";
            Attack = 5;
            Health = 3;
            Cost = 3;
            isCreature = true;
            isDead = false;
            summonSickness = false;
            //for each (cardName fire drake) +1/+1 atk/def
        }
    }
    public class FireBall : Card
    {
        //string CardName = "Fireball";
        //string CardDescription = "Fire in your face.";
        //string AbilityDescription = "Deal 1 damage to target creature/commander.";
        //string CardType = "Spell";
        //int Attack = 0;
        //int Health = 0;
        //int Cost = 1;
        public FireBall()
        {
            CardName = "Fireball";
            CardDescription = "Fire in your face.";
            AbilityDescription = "Deal 2 damage to target creature/commander.";
            CardType = "Spell";
            Attack = 2;
            Health = 0;
            Cost = 1;
            isCreature = false;
            summonSickness = false;
        }
    }
    public class FlameStrike : Card
    {
        //string CardName = "Flamestrike";
        //string CardDescription = "Fire strikes the earth.";
        //string AbilityDescription = "1 damage three times to random enemies.";
        //string CardType = "Spell";
        //int Attack = 0;
        //int Health = 0;
        //int Cost = 3;
        public FlameStrike()
        {
            CardName = "Flamestrike";
            CardDescription = "Fire strikes the earth.";
            AbilityDescription = "1 Damage to three creatures.";
            CardType = "Spell";
            Attack = 1;
            Health = 0;
            Cost = 2;
            isCreature = false;
            //for each card in field area list [i] = random ran for index//
            //add enemy to list
            //no summon sickness for spells
        }
    }
    public class WildFire : Card
    {
        //string CardName = "Wildfire";
        //string CardDescription = "Uncontrollable flames.";
        //string AbilityDescription = "Deal 2 damage to enemy creatures and commanders.";
        //string CardType = "Spell";
        //int Attack = 0;
        //int Health = 0;
        //int Cost = 2;
        public WildFire()
        {
            CardName = "Wildfire";
            CardDescription = "Uncontrollable flames.";
            AbilityDescription = "Deal 2 damage to all creatures and commanders.";
            CardType = "Spell";
            Attack = 2;
            Health = 0;
            Cost = 3;
            isCreature = false;
            //no summon sickness for spells
            //for each field area // etc //etc
        }
    }
    public class FireAvatar : Card {
        public FireAvatar() {
            CardName = "Atria, the Phoenix of Rebirth";
            CardDescription = "Commander of fire. Edge and all.";
            AbilityDescription = "I AM THE COMMANDER! HAhaAhaA.";
            CardType = "Hero/Avatar";
            Attack = 0;
            Health = 15;
            Cost = 0;
            maxMana = 5;
            currentMana = 1;
            playerTurnCount = 0;
            playerTurn = false;
            isCreature = false;
            //no summon sickness for spells
        }
    }
    public class WaterAvatar : Card
    {
        public WaterAvatar()
        {
            CardName = "Celiana, Siren of the Sea";
            CardDescription = "Commander of Water. She gotchu swimming.";
            AbilityDescription = "I AM THE COMMANDER! HAhaAhaA.";
            CardType = "Hero/Avatar";
            Attack = 0;
            Health = 15;
            Cost = 0;
            maxMana = 0;
            isCreature = false;
            //no summon sickness for spells
        }
    }
}

