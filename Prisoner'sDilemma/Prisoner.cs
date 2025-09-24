using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prisoner_sDilemma
{
    public class Prisoner
    {
        public bool IsBitray { get; private set; }

        public void Choice(int key)
        {
            const int KeyBitray = 1;
            const int KeyNotBitray = 2;

            switch (key)
            {
                case KeyBitray:
                    IsBitray = true;
                    break;
                case KeyNotBitray:
                    IsBitray = false;
                    break;
            }
        }
    }
}
