using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicePoker
{
    internal class Dice
    {
        public IDiceRollResult Roll()
        {
            return new DiceRollResult(new Random().Next(1, 6));
        }
    }
}
