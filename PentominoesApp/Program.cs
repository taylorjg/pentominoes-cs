using System;
using System.Linq;
using System.Collections.Generic;
using PentominoesLib;
using DlxLib;

namespace PentominoesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var solutions = Pentominoes.Solve(OnSolutionFound);
            Console.WriteLine($"Total number of solutions found: {solutions.Count()}");
        }

        private static void OnSolutionFound(IEnumerable<Placement> rows, Solution solution, int solutionIndex)
        {
            DrawSolution(rows, solution);
        }

        private static void DrawSolution(IEnumerable<Placement> rows, Solution solution)
        {
            var cells = new string[8, 8];
            cells[3, 3] = " ";
            cells[3, 4] = " ";
            cells[4, 3] = " ";
            cells[4, 4] = " ";
            foreach (var rowIndex in solution.RowIndexes)
            {
                var placement = rows.ElementAt(rowIndex);
                foreach (var coords in placement.Variation.Coords)
                {
                    var x = placement.Location.X + coords.X;
                    var y = placement.Location.Y + coords.Y;
                    cells[y, x] = placement.Piece.Label;
                }
            }
            var lines = Enumerable.Range(0, 8).Select(rowIndex =>
                string.Join("", Enumerable.Range(0, 8).Select(colIndex =>
                    cells[rowIndex, colIndex])));
            foreach (var line in lines) Console.WriteLine(line);
            Console.WriteLine(new string('-', 80));
        }
    }
}
