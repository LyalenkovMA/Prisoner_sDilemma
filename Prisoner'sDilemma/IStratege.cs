using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prisoner_sDilemma
{
    public interface IStratege
    {
        string Title { get; }

        void Start(int[] listStep, int indexStep);

        int GetChoice();
    }
}
