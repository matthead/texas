using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace texasholdem
{
    class Program
    {
        static public List<Player> players;
        static int currentplayers;
        static void Main(string[] args)
        {
            int numberOfPlayersTotal = 2;
            currentplayers = numberOfPlayersTotal;
            Deal deal = new Deal();
            Program program=new Program();
            Deck myDeck=new Deck();
            //List<Card> theDeck = myDeck.GetDeck();
            Stack<Card> theDeck = myDeck.GetDeck();
            players = deal.Start(numberOfPlayersTotal,theDeck); // these are all the player hands   
            //shows players hand
            program.ShowHands();
            BettingClass bet = new BettingClass();

            //round of betting
            if(players.Count>1)        
                players=bet.MainBet(players);//wiil update the players if they folded  

            //flop
            Console.WriteLine("below is the flop");
            List<Card> communityCards = deal.Flop(theDeck);
            program.ShowCommunityCards(communityCards);
            if (players.Count > 1)
                players = bet.MainBet(players);

            //turn
            Console.WriteLine("below is the flop and turn");
            communityCards.Add(deal.Turn(theDeck));
            program.ShowCommunityCards(communityCards);
            if (players.Count > 1)
                players = bet.MainBet(players);

            //river 

            Console.WriteLine("below is the flop turn and river");
            communityCards.Add(deal.Turn(theDeck));
            program.ShowCommunityCards(communityCards);

            //Calculate hands
            Calculate calc = new Calculate();
            foreach (Player player in players)
            {
                calc.PassCards(ref player.hand, communityCards);
            }          
        }
        void ShowHands()
        {
            foreach (Player player in players)
            {
                foreach (Card card in player.hand)
                {
                    Console.Write(card.faceValues + " " + card.suit);
                }
                Console.WriteLine("");
            }
        }             
        private void ShowCommunityCards(List<Card>communityCards)
        {
            foreach(Card card in communityCards)
            {
                Console.WriteLine(card.faceValues+" "+card.suit);
            }
        }

    }
}
