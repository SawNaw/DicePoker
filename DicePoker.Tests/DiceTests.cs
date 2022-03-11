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
            for (int i = 0; i < 99999; i++)
            {
                var result = dice.Roll();
                rolls.Add(result.Result);
            }

            Assert.Contains(1, rolls);
            Assert.Contains(2, rolls);
            Assert.Contains(3, rolls);
            Assert.Contains(4, rolls);
            Assert.Contains(5, rolls);
            Assert.Contains(6, rolls);

            Assert.True(rolls.All(x => x >= 1 && x <= 6));
        }
    }
}
