using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prisoner_sDilemma
{
    public interface IStratege
    {
        Prisoner Prisoner { get; }

        void Start(bool countStep, bool isGoStep);
    }
}
