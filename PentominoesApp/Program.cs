using System;
using System.Linq;
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
            var solutionsCount = solutions.Aggregate(0, (acc, solution) =>
            {
                DrawSolution(solution);
                return acc + 1;
            });
            Console.WriteLine($"Number of solutions found: {solutionsCount}");
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
