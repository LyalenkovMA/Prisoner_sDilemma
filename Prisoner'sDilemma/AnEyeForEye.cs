using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prisoner_sDilemma
{
    internal class AnEyeForEye : IStratege
    {
        private const int KeyNotBitray = 2;
        private int _choice;

        public AnEyeForEye() 
        {
            _choice = KeyNotBitray;
            Title = "Око за око";
        }

        public string Title { get; private set; }

        public int GetChoice()
        {
            return _choice;
        }

        public void Start(int[] listStep, int indexStep)
        {
            if(indexStep >0)
                _choice = listStep[indexStep - 1];
        }
    }
}
