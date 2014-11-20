using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace texasholdem
{
    class Calculate
    {
        public void PassCards(ref List<Card> oneHand,List<Card> community)//function used for testing
        {
            oneHand = oneHand.Union(community).ToList<Card>();
            oneHand.Sort();
            //hand is sorted
            if (IsFourOfAKind(oneHand))
            {
                Console.WriteLine("four of a kind");
            }
            //straight flush needed
            else if (IsFullHouse(oneHand))
            {
                Console.WriteLine("full house");
            }
            else if (IsFlush(oneHand))
            {
                Console.WriteLine("flush");
            }
            else if (IsStraight(oneHand))
            {
                Console.WriteLine("straight");
            }
            else if (IsThreeOfAKind(oneHand))
            {
                Console.WriteLine("three of a kind");
            }
            else if (IsTwoPair(oneHand))
            {
                Console.WriteLine("two pair");
            }
            else if (IsPair(oneHand))
            {
                Console.WriteLine("pair");
            }

        }
        List<Card> HighCard(List<Card>hand)
        {
            List<Card> temp = new List<Card>();
            for (int i = hand.Count -1; i > hand.Count -6; i--)
            {
                temp.Add(hand[i]);
            }
            return temp;
        }

        bool IsStraight(List<Card> hand)
        {
            int count = 1;
            bool countWasFourAndKing = false;
            for (int i = 1; i < hand.Count(); i++)
            {
                if (hand[i].faceValues == hand[i - 1].faceValues + 1)
                {
                    count++;
                    if (count == 5)
                        return true;

                    if (count == 4 && hand[i].faceValues == FaceValues.king)//case for straight from 10-ace
                    {

                        countWasFourAndKing = true;
                    }
                }
                else if ((!(hand[i].faceValues == hand[i - 1].faceValues)))
                {                   
                    count = 1;
                }
                if (countWasFourAndKing)
                {
                    if (hand[0].faceValues == FaceValues.ace)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        bool IsFullHouse(List<Card> hand)
        {
            //if(IsPair(hand) && IsThreeOfAKind(hand))
            return false;
        }
        bool IsFlush(List<Card> hand)
        {
            int spadesCounter=0, diamondsCounter=0, clubsCounter=0, heartsCounter=0;
            foreach (Card card in hand)
            {
                switch ((int)card.suit)
                {
                    case (int)Suits.clubs:
                        clubsCounter++;
                        break;
                    case (int)Suits.spades:
                        spadesCounter++;
                        break;
                    case (int)Suits.diamonds:
                        diamondsCounter++;
                        break;
                    case (int)Suits.hearts:
                        heartsCounter++;
                        break;
                    default:
                        { }
                        break;
                }
                if (spadesCounter > 4 || diamondsCounter > 4 || clubsCounter > 4 || heartsCounter > 4)
                    return true;
            }
            return false;
        }
        bool IsFourOfAKind(List<Card> hand)
        {
            int count = 1;
            //the first card in index 0 alrdy count in count =1
            for (int i = 1; i < hand.Count(); i++)
            {
                if (i<hand.Count()-1&& hand[i].faceValues == hand[i + 1].faceValues)//make sure you check index first 
                {
                    if (hand[i].faceValues == hand[i - 1].faceValues)
                    {
                        count++;
                    }
                    else
                    {
                        count = 1;
                    }
                }
                else if (count == 3 && hand[i].faceValues == hand[i - 1].faceValues)
                {
                    count++;                
                    return true;
                }
            }
            return false;
        }

        bool IsThreeOfAKind(List<Card> hand)
        {
            int count = 1;
            //the first card in index 0 alrdy count in count =1
            for (int i = 1; i < hand.Count(); i++)
            {
                if (i < hand.Count() - 1 && hand[i].faceValues == hand[i + 1].faceValues)//make sure you check index first 
                {
                    if (hand[i].faceValues == hand[i - 1].faceValues)
                    {
                        count++;
                    }
                    else
                    {
                        count = 1;
                    }
                }
                else if (count == 2 && hand[i].faceValues == hand[i - 1].faceValues)
                {
                    count++;
                    return true;
                }
            }
            return false;
        }

        bool IsPair(List<Card> hand)
        {
            for (int i = hand.Count-1; i > hand.Count - 7; i--)
            {
                if(i>0 && hand[i].faceValues==hand[i-1].faceValues)
                {              
                   return true;
                }
            }
            return false;
        }
        bool IsTwoPair(List<Card> hand)
        {
            int count = 0;
            for (int i = 1; i < hand.Count(); i++)
            {
                if (i < hand.Count() - 1 && hand[i].faceValues == hand[i + 1].faceValues)//make sure you check index first 
                {
                    count++;
                }
                if (count > 1)
                    return true;
            }
            return false;
        }
    }
}
