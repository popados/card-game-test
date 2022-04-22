# Original Card Game

Been working on this for years. I have a spreadsheet with different ideas.

Worked on this with a group. Nxinifinity & Plainsimplex.

This is the first iteration of a console app that I want to support:

- 4 to 6 decks.

- Avatars

- Card Hand

- Mana(Hearthstone)

- Multiplayer

- 

EVERYTHING RECURSIVELY LOOPS IN HANDSELECTION!

 Objects/Logic/Stuff needed for TCG Battle System:
 
  -  Card[x] -- templates done

  -  Deck[x] - shuffling done

  -  Hand[x] - idea is to remove from shuffled[deck.Count-1] and add to hand list

  -  drawCards[x] - need to refactor into methods that call the lists after they are made

  -  Play Area[x] -- remove from hand and add to play area(no larger than 5)

  -  Graveyard[x] -- list is made

  -  player avatar card[x] -- using card to create a commander maybe have mana attached to the commander? like player.maxMana++

  -  enemy avatar card[x] -- ^^

  -  hand selection[x]

  -  mana and mana count[x]

  -  attack conditions[] --

  -  turns[x] -- error in turn logic that doesnt always reset turn after endturn method


  
    --REQUIRES => player, enemy, hand, shuffled, field, graveyard
    ---> something is added/removed/changed in these <---
    ---> have a function that holds each turn action
    --> <start turn> <show mana> <show enemy & player hp> <show ield> <create hand> <draw>
    ---> <play card> <mana up> <end turn>
    //might try to create a new method that uses 1-5 and test issues with recursion
    //i think its the endturn doesnt break into anything so it doesnt know where to find the -while loop unless i cycle
    //card lists[]
