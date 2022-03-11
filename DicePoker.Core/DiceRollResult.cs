using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicePoker.Core
{
    public class DiceRollResult : IDiceRollResult
    {
        public int Result { get; set; }

        public DiceRollResult(int result)
        {
            this.Result = result;
        }
    }
}
