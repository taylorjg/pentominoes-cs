using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;
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

        // const uniqueSolutions = []
        // const uniqueJoinedGrids = []

        // const isSolutionUnique = (rows, solution) => {
        //   const formattedSolution1 = formatSolution(rows, solution)
        //   const formattedSolution2 = M.rotateStrings(formattedSolution1)
        //   const formattedSolution3 = M.rotateStrings(formattedSolution2)
        //   const formattedSolution4 = M.rotateStrings(formattedSolution3)
        //   const formattedSolution5 = M.reflectStrings(formattedSolution1)
        //   const formattedSolution6 = M.reflectStrings(formattedSolution2)
        //   const formattedSolution7 = M.reflectStrings(formattedSolution3)
        //   const formattedSolution8 = M.reflectStrings(formattedSolution4)
        //   const joinedGrids = [
        //     formattedSolution1.join('|'),
        //     formattedSolution2.join('|'),
        //     formattedSolution3.join('|'),
        //     formattedSolution4.join('|'),
        //     formattedSolution5.join('|'),
        //     formattedSolution6.join('|'),
        //     formattedSolution7.join('|'),
        //     formattedSolution8.join('|')
        //   ]
        //   return R.intersection(joinedGrids, uniqueJoinedGrids).length === 0
        // }        

        private static void DrawSolution(IEnumerable<Placement> rows, Solution solution)
        {
            var rowsArray = rows.ToImmutableArray();
            var seed = ImmutableArray.Create<(int x, int y, string label)>(
                (3, 3, " "),
                (3, 4, " "),
                (4, 3, " "),
                (4, 4, " ")
            );
            var cellsArray = solution.RowIndexes.Aggregate(seed, (accOuter, rowIndex) =>
            {
                var placement = rowsArray[rowIndex];
                return placement.Variation.Coords.Aggregate(accOuter, (accInner, coords) =>
                {
                    var x = placement.Location.X + coords.X;
                    var y = placement.Location.Y + coords.Y;
                    return accInner.Add((x, y, placement.Piece.Label));
                });
            });
            var lines =
                from y in Enumerable.Range(0, 8)
                let row = Enumerable.Range(0, 8).Select(x => cellsArray.First(t => t.x == x && t.y == y))
                select string.Join("", row.Select(t => t.label));
            foreach (var line in lines) Console.WriteLine(line);
            Console.WriteLine(new string('-', 80));
        }
    }
}
