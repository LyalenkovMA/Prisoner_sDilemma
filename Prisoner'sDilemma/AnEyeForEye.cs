using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prisoner_sDilemma
{
    internal class AnEyeForEye : IStratege
    {
        public AnEyeForEye(Prisoner prisoner) 
        {
            Prisoner = prisoner;
        }

        public Prisoner Prisoner { get; }

        public void Start(bool countStep, bool isGoStep)
        {
            
        }
    }
}
