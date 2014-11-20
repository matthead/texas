using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace texasholdem
{
    public  class Deck
    {
        public  List<Card> SetDeck()
        {
            List<Card> deck = new List<Card>();
            foreach (Suits suit in Enum.GetValues(typeof(Suits)))
            {
                foreach (FaceValues faceValue in Enum.GetValues(typeof(FaceValues)))
                {
                    Card card = new Card(faceValue, suit);
                    deck.Add(card);
                }
            }
            return deck;
        }
        private  void Shuffle(List<Card> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        public  Stack<Card> GetDeck()
        {
            List<Card> cards = SetDeck();
            Shuffle(cards);
            Stack<Card> theDeck=new Stack<Card>();
            foreach (Card card in cards)
            {
                theDeck.Push(card);
            }
            return theDeck;
        }
    }
}