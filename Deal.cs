using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace texasholdem
{
    class Deal
    {
        public List<Player> Start(int numberOfPlayers,Stack<Card>theDeck)
        {
           // List<Card> theDeck = myDeck.GetDeck();
            List<Player> allPlayers=new List<Player>();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Player player = new Player();
                player.hand.Add(theDeck.Pop());
                player.hand.Add(theDeck.Pop());
                allPlayers.Add(player);

            }
            return allPlayers;
        }
        public List<Card> Flop(Stack<Card>theDeck)
        {
            List<Card>flop=new List<Card>();
            for (int i = 0; i <  3; i++) 
            {
                flop.Add(theDeck.Pop());
            }
            return flop;
        }
        
        public Card Turn(Stack<Card>theDeck)
        {
            return theDeck.Pop();
        }
        public Card River(Stack<Card> theDeck)
        {
            return theDeck.Pop();
        }
    }
}
