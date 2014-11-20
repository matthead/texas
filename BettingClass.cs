using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace texasholdem
{
    class BettingClass
    {
        bool CheckBets(List<int> bets,int numOfPeople)//checks to see that all players bet the same amount
        {
            for (int i = bets.Count() - 1; i > bets.Count() - numOfPeople; i--)
            {
                if(bets[i]!=bets[i-1])
                {
                    return false;
                }
            }
            return true;
        }
        public List<Player> MainBet( List<Player> players)
        {
            int bet=0;
            //List<int> indexesOfPeopleWhoFolded = new List<int>();
            List<int> allBets = new List<int>();
            bool allBetsAreTheSame=false;
            bool removeFlag = false;
            int index=0;
            do
            {
                removeFlag = false;
                Console.WriteLine("player " + index);
                bet = OriginalOptions();
                if (bet != -1) //-1 equals a folded hand
                {
                    players[index].bet = bet;
                    allBets.Add(bet);
                }
                else//player Folded removes players from List to create a function i woul have to pass the list and the index. that doesnt seem woth it
                {
                    removeFlag = true;
                    players[index].chips -= bet + 1;
                    if (index  > 0)
                    {
                        //allBets.Add(allBets[index - 1]);//gives bet the same value as the person before him 
                    }
                    players.RemoveAt(index);
                    
                }
                if(allBets.Count()>=players.Count())//makes sure everyone has had a turn to act
                {
                    allBetsAreTheSame = CheckBets(allBets,players.Count());//checks all bets
                }
                if (removeFlag == false)
                {
                    index++;
                }
                if (index > players.Count()-1 && allBetsAreTheSame == false)//resets index if needed to reloop
                {
                    index = 0;
                }
                
            } while (index < players.Count()&&allBetsAreTheSame==false);
            return players;
        }
        private int OriginalOptions()
        {            
            Console.WriteLine("1 to check 2 to bet 3 to fold");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                return 0;
            }
            else if(choice==2)
            {
                Console.WriteLine("enter your bet");
                int temp = int.Parse(Console.ReadLine());
                return temp;
            }
            else
            {
                return -1;
            }
        }
    }
}
