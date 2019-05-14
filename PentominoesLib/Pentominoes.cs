using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;
using DlxLib;

namespace PentominoesLib
{
    public static class Pentominoes
    {
        public static IEnumerable<Solution> Solve()
        {
            var rows = BuildRows;
            var matrix = BuildMatrix(rows);
            var dlx = new Dlx();
            return dlx.Solve(matrix, d => d, r => r);
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

        private static IEnumerable<Coords> AllLocations =>
            from x in Enumerable.Range(0, 8)
            from y in Enumerable.Range(0, 8)
            select new Coords(x, y);

        private static IEnumerable<Placement> AllPlacements =>
            from piece in Pieces.AllPieces
            from varation in piece.Variations
            from location in AllLocations
            select new Placement(piece, varation, location);

        private static IEnumerable<Placement> BuildRows =>
            AllPlacements.Where(PlacementIsValid);

        private static IEnumerable<int> MakePieceColumns(Placement placement)
        {
            var piecesList = Pieces.AllPieces.ToList();
            var pieceIndex = piecesList.FindIndex(piece => piece.Label == placement.Piece.Label);
            return Enumerable.Range(0, piecesList.Count).Select(index => index == pieceIndex ? 1 : 0);
        }

        private static IEnumerable<int> MakeLocationColumns(Placement placement)
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
            );
        }

        private static IEnumerable<IEnumerable<int>> BuildMatrix(IEnumerable<Placement> rows) =>
            rows.Select(placement =>
            {
                var pieceColumns = MakePieceColumns(placement);
                var locationColumns = MakeLocationColumns(placement);
                return pieceColumns.Concat(locationColumns);
            });
    }
}
