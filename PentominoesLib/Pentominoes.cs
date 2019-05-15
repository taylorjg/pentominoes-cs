using System;
using System.Linq;
using System.Collections.Immutable;
using DlxLib;

namespace PentominoesLib
{
    public static class Pentominoes
    {
        public static ImmutableArray<Solution> Solve(Action<ImmutableArray<Placement>, Solution, int> onSolutionFound)
        {
            var rows = BuildRows;
            var matrix = BuildMatrix(rows);
            var dlx = new Dlx();
            dlx.SolutionFound += (_, e) =>
            {
                if (onSolutionFound != null)
                {
                    onSolutionFound(rows, e.Solution, e.SolutionIndex);
                }
            };
            var solutions = dlx.Solve(matrix, d => d, r => r);
            return solutions.ToImmutableArray();
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
