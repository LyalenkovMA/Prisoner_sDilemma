using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prisoner_sDilemma
{
    internal class AnEyeForEye : IStratege
    {
        public Prisoner Prisoner { get; }

        public void Start(int[] listStep, int indexStep)
        {
            if (listStep[indexStep - 1] == 1)
                Prisoner.Choice(1);
            if (listStep[indexStep - 1] == 2)
                Prisoner.Choice(2);

        }
    }
}
