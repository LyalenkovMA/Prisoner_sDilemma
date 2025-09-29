using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prisoner_sDilemma
{
    public class OnMyMind : IStratege
    {
        private const int KeyNotBitray = 2;
        private const int KeyBitray = 1;
        private int _choice;
        private int _baseChance;

        public OnMyMind()
        {
            Title = "У себя на уме";
            _baseChance = 10;
        }

        public string Title { get; private set; }

        public int GetChoice()
        {
            return _choice;
        }

        public void Start(int[] listStep, int indexStep)
        {
            if(indexStep > 0)
            {
                if (IsBetrayed(_baseChance))
                    _choice = KeyBitray;
                else
                    _choice = KeyNotBitray;
            }

        }

        private bool IsBetrayed(int chance) 
        {
            int minRandom = 0;
            int maxRandom = 100;
            Random random = new Random();

            if(random.Next(minRandom,maxRandom)<= chance)
                return true;
            else
                return false;
        }
    }
}
