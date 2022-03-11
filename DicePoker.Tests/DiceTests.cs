using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DicePoker.Core;
using Xunit;

namespace DicePoker.Tests
{
    public class DiceTests
    {
        [Fact]
        public void Roll_GeneratesNumbers_1To6_Inclusive()
        {
            var rolls = new List<int>();
            var dice = new Dice();

            // Roll the dice a lot of times to ensure that every number is generated.
            for (int i = 0; i < 1000; i++)
            {
                var result = dice.Roll();
                rolls.Add(result.Result);
            }

            // Every number should have been generated.
            Assert.Contains(1, rolls);
            Assert.Contains(2, rolls);
            Assert.Contains(3, rolls);
            Assert.Contains(4, rolls);
            Assert.Contains(5, rolls);
            Assert.Contains(6, rolls);

            // All numbers generated should be 1 to 6 inclusive.
            Assert.True(rolls.All(x => x >= 1 && x <= 6));
        }
    }
}
