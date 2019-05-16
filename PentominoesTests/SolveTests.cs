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
            var solutions = Pentominoes.Solve();
            Assert.Equal(65, solutions.Count());
        }
    }
}
