using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace texasholdem
{
    public class Card :IComparable<Card>
    {
        public Card(FaceValues faceValue,Suits suit)
        {
            this.faceValues=faceValue;
            this.suit=suit;
        }
        public FaceValues faceValues;
        public Suits suit;
        public int CompareTo(Card b)
        {
            return this.faceValues.CompareTo(b.faceValues);
        }
    }


    public enum FaceValues { ace, two, three, four, five, six, seven, eight, nine, ten, jack, queen, king };
    public enum Suits { hearts, spades, diamonds, clubs };
}
