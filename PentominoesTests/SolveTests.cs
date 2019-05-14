using System;
using System.Linq;
using Xunit;
using PentominoesLib;

namespace PentominoesTests
{
    public class SolveTests
    {
        [Fact]
        public void FindsCorrectNumberOfSolutions()
        {
            var solutions = Pentominoes.Solve(null);
            Assert.Equal(520, solutions.Count());
        }
    }
}
