using System;
using System.Linq;
using PentominoesLib;

namespace PentominoesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var solutions = Pentominoes.Solve();
            Console.WriteLine($"Number of solutions found: {solutions.Count()}");
        }
    }
}
