using System;
using System.Linq;
using System.Collections.Generic;

namespace PentominoesLib
{
    public static class Pieces
    {
        public static IEnumerable<Piece> ThePieces =
            PieceDescriptions.ThePieceDescriptions.Select(MakePiece);

        private static Piece MakePiece(PieceDescription pieceDescription)
        {
            var northPattern = pieceDescription.Pattern;
            var westPattern = Manipulations.RotateStrings(northPattern);
            var southPattern = Manipulations.RotateStrings(westPattern);
            var eastPattern = Manipulations.RotateStrings(southPattern);
            var northReflectedPattern = Manipulations.ReflectStrings(northPattern);
            var westReflectedPattern = Manipulations.ReflectStrings(westPattern);
            var southReflectedPattern = Manipulations.ReflectStrings(southPattern);
            var eastReflectedPattern = Manipulations.ReflectStrings(eastPattern);
            var allVariations = new[] {
                new Variation(Orientation.North, false, PatternToCoords(northPattern)),
                new Variation(Orientation.West, false, PatternToCoords(westPattern)),
                new Variation(Orientation.South, false, PatternToCoords(southPattern)),
                new Variation(Orientation.East, false, PatternToCoords(eastPattern)),
                new Variation(Orientation.North, true, PatternToCoords(northReflectedPattern)),
                new Variation(Orientation.West, true, PatternToCoords(westReflectedPattern)),
                new Variation(Orientation.South, true, PatternToCoords(southReflectedPattern)),
                new Variation(Orientation.East, true, PatternToCoords(eastReflectedPattern))
            };
            // TODO: calculate unique variations from all variations
            return new Piece(pieceDescription.Label, allVariations);
        }

        private static IEnumerable<Coords> PatternToCoords(IEnumerable<string> pattern)
        {
            var patternList = pattern.ToList();
            var xs = Enumerable.Range(0, patternList[0].Length);
            var ys = Enumerable.Range(0, patternList.Count);
            return
                from x in xs
                from y in ys
                select new Coords(x, y);
        }
    }
}
