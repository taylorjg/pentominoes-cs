using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;
using DlxLib;

namespace PentominoesLib
{
    public static class Pentominoes
    {
        public static ImmutableArray<ImmutableArray<Placement>> Solve()
        {
            var rows = BuildRows;
            var matrix = BuildMatrix(rows);
            var dlx = new Dlx();
            var allSolutions = dlx.Solve(matrix, d => d, r => r);

            var seed = new
            {
                UniqueSolutions = ImmutableList.Create<ImmutableArray<Placement>>(),
                UniqueBoards = ImmutableList.Create<string>()
            };

            var finalAcc = allSolutions
                .Select(solution => ResolveSolution(rows, solution))
                .Aggregate(seed, (acc, placements) =>
                    SolutionDeDuplicator.SolutionIsUnique(placements, acc.UniqueBoards)
                        ? new
                        {
                            UniqueSolutions = acc.UniqueSolutions.Add(placements),
                            UniqueBoards = acc.UniqueBoards.Add(FormatBoardOneLine(placements))
                        }
                        : acc);
            return finalAcc.UniqueSolutions.ToImmutableArray();
        }

        public static ImmutableArray<string> FormatSolution(ImmutableArray<Placement> solution)
        {
            var seed = ImmutableList.Create<(int x, int y, string label)>(
                (3, 3, " "),
                (3, 4, " "),
                (4, 3, " "),
                (4, 4, " ")
            );
            var cells = solution.Aggregate(seed, (accOuter, placement) =>
                placement.Variation.Coords.Aggregate(accOuter, (accInner, coords) =>
                {
                    var x = placement.Location.X + coords.X;
                    var y = placement.Location.Y + coords.Y;
                    return accInner.Add((x, y, placement.Piece.Label));
                }));
            var lines =
                from y in Enumerable.Range(0, 8)
                let row = Enumerable.Range(0, 8).Select(x => cells.First(t => t.x == x && t.y == y))
                select string.Join("", row.Select(t => t.label));
            return lines.ToImmutableArray();
        }

        private static string FormatBoardOneLine(ImmutableArray<Placement> placements)
        {
            return string.Join("|", FormatSolution(placements));
        }

        private static ImmutableArray<Placement> ResolveSolution(ImmutableArray<Placement> rows, Solution solution)
        {
            return solution.RowIndexes.Select(rowIndex => rows[rowIndex]).ToImmutableArray();
        }

        private static bool PlacementIsValid(Placement placement)
        {
            foreach (var coords in placement.Variation.Coords)
            {
                var x = placement.Location.X + coords.X;
                var y = placement.Location.Y + coords.Y;
                if (x >= 8 || y >= 8) return false;
                if ((x == 3 || x == 4) && (y == 3 || y == 4)) return false;
            }
            return true;
        }

        private static ImmutableArray<Coords> AllLocations =>
            (
                from x in Enumerable.Range(0, 8)
                from y in Enumerable.Range(0, 8)
                select new Coords(x, y)
            ).ToImmutableArray();

        private static ImmutableArray<Placement> AllPlacements =>
            (
                from piece in Pieces.AllPieces
                from varation in piece.Variations
                from location in AllLocations
                select new Placement(piece, varation, location)
            ).ToImmutableArray();

        private static ImmutableArray<Placement> BuildRows =>
            AllPlacements.Where(PlacementIsValid).ToImmutableArray();

        private static ImmutableArray<int> MakePieceColumns(Placement placement)
        {
            var pieceIndex = Pieces.AllPieces.FindIndex(piece => piece.Equals(placement.Piece));
            return Enumerable.Range(0, Pieces.AllPieces.Count)
                .Select(index => index == pieceIndex ? 1 : 0)
                .ToImmutableArray();
        }

        private static ImmutableArray<int> MakeLocationColumns(Placement placement)
        {
            var locationIndices = placement.Variation.Coords.Select(coords =>
            {
                var x = placement.Location.X + coords.X;
                var y = placement.Location.Y + coords.Y;
                return y * 8 + x;
            });
            var excludeIndices = new[] { 27, 28, 35, 36 };
            return Enumerable.Range(0, 64).SelectMany(index =>
                excludeIndices.Contains(index)
                    ? Enumerable.Empty<int>()
                    : Enumerable.Repeat(locationIndices.Contains(index) ? 1 : 0, 1)
            ).ToImmutableArray();
        }

        private static ImmutableArray<ImmutableArray<int>> BuildMatrix(ImmutableArray<Placement> rows) =>
            rows.Select(placement =>
            {
                var pieceColumns = MakePieceColumns(placement);
                var locationColumns = MakeLocationColumns(placement);
                return pieceColumns.AddRange(locationColumns);
            }).ToImmutableArray();
    }
}
