using System;
using System.Linq;
using System.Collections.Generic;
using DlxLib;

namespace PentominoesLib
{
    public static class Pentominoes
    {
        public static IEnumerable<Solution> Solve()
        {
            Console.WriteLine($"BuildRows.Count(): {BuildRows.Count()}");

            var matrix = new[,]
                {
                    {1, 0, 0, 0},
                    {0, 1, 1, 0},
                    {1, 0, 0, 1},
                    {0, 0, 1, 1},
                    {0, 1, 0, 0},
                    {0, 0, 1, 0}
                };
            var dlx = new Dlx();
            return dlx.Solve(matrix);
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
    }
}
