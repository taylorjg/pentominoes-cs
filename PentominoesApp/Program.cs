using System;
using System.Collections.Immutable;
using PentominoesLib;

namespace PentominoesApp
{
    using Solution = ImmutableArray<Placement>;

    class Program
    {
        static void Main(string[] args)
        {
            var solutions = Pentominoes.Solve();
            foreach (var solution in solutions)
            {
                DrawSolution(solution);
            }
            Console.WriteLine($"Number of solutions found: {solutions.Length}");
        }

        private static void DrawSolution(Solution solution)
        {
            foreach (var line in Pentominoes.FormatSolution(solution))
            {
                Console.WriteLine(line);
            }
            Console.WriteLine(new string('-', 80));
        }
    }
}
