using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicePoker.Core
{
    public class ScoreCalculator
    {
        private IDiceRollResult diceRoll1;
        private IDiceRollResult diceRoll2;
        private IDiceRollResult diceRoll3;
        private IDiceRollResult diceRoll4;

        private IEnumerable<IDiceRollResult> allDiceRolls;

        public ScoreCalculator(IDiceRollResult result1,
                               IDiceRollResult result2,
                               IDiceRollResult result3,
                               IDiceRollResult result4)
        {
            this.diceRoll1 = result1;
            this.diceRoll2 = result2; 
            this.diceRoll3 = result3;
            this.diceRoll4 = result4;

            allDiceRolls = new List<IDiceRollResult>() { this.diceRoll1, this.diceRoll2, this.diceRoll3, this.diceRoll4 }
                           .OrderBy(x => x.Result);
        }

        private bool Has4OfAKind()
        {
            return (this.diceRoll1.Result == this.diceRoll2.Result) 
                && (this.diceRoll2.Result == this.diceRoll3.Result)
                && (this.diceRoll3.Result == this.diceRoll4.Result);
        }

        private bool HasStraight()
        {
            return allDiceRolls.ElementAt(0).Result == allDiceRolls.ElementAt(1).Result - 1
                && allDiceRolls.ElementAt(1).Result == allDiceRolls.ElementAt(2).Result - 1
                && allDiceRolls.ElementAt(2).Result == allDiceRolls.ElementAt(3).Result - 1;
        }

        private bool Has3OfAKind()
        {
            return allDiceRolls.Any(x => allDiceRolls.Count(y => x == y) >= 3);
        }

        private bool Has2OfAKind()
        {
            return allDiceRolls.Any(x => allDiceRolls.Count(y => x == y) >= 2);
        }

        private int HighestSingleDiceValue()
        {
            return allDiceRolls.Max(r => r.Result);
        }

        public int CalculateScore()
        {
            if (Has4OfAKind())
            {
                return 100;
            }
            else if (HasStraight())
            {
                return 50;
            }
            else if (Has3OfAKind())
            {
                return 25;
            }
            else if (Has2OfAKind())
            {
                return 10;
            }
            else return allDiceRolls.Max(x => x.Result);
        }
    }
}
