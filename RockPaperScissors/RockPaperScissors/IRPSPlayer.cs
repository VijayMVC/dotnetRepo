using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public interface IRPSPlayer
    {
        string Name { get; }
        Choices GetChoice();
    }
}
