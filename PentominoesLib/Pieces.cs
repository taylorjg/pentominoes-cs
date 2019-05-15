using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace PentominoesLib
{
    public static class Pieces
    {
        public static ImmutableList<Piece> AllPieces =
            PieceDescriptions.AllPieceDescriptions
                .Select(MakePiece)
                .ToImmutableList();

        private static Piece MakePiece(PieceDescription pieceDescription)
        {
            var northPattern = pieceDescription.Pattern;
            var westPattern = StringManipulations.RotateStrings(northPattern);
            var southPattern = StringManipulations.RotateStrings(westPattern);
            var eastPattern = StringManipulations.RotateStrings(southPattern);
            var northReflectedPattern = StringManipulations.ReflectStrings(northPattern);
            var westReflectedPattern = StringManipulations.ReflectStrings(westPattern);
            var southReflectedPattern = StringManipulations.ReflectStrings(southPattern);
            var eastReflectedPattern = StringManipulations.ReflectStrings(eastPattern);
            var allPatternVariations = new[] {
                new PatternVariation(Orientation.North, false, northPattern),
                new PatternVariation(Orientation.West, false, westPattern),
                new PatternVariation(Orientation.South, false, southPattern),
                new PatternVariation(Orientation.East, false, eastPattern),
                new PatternVariation(Orientation.North, true, northReflectedPattern),
                new PatternVariation(Orientation.West, true, westReflectedPattern),
                new PatternVariation(Orientation.South, true, southReflectedPattern),
                new PatternVariation(Orientation.East, true, eastReflectedPattern)
            };
            var uniquePatternVariations = allPatternVariations.Distinct(new PatternVariationComparer());
            var uniqueVariations = uniquePatternVariations
                .Select(upv =>
                    new Variation(upv.Orientation, upv.Reflected, PatternToCoords(upv.Pattern)))
                .ToImmutableArray();
            return new Piece(pieceDescription.Label, uniqueVariations);
        }

        private static ImmutableArray<Coords> PatternToCoords(ImmutableArray<string> pattern)
        {
            var xs = Enumerable.Range(0, pattern[0].Length);
            var ys = Enumerable.Range(0, pattern.Length);
            var coords =
                from x in xs
                from y in ys
                where pattern[y][x] == 'X'
                select new Coords(x, y);
            return coords.ToImmutableArray();
        }
    }

    class PatternVariation
    {
        public PatternVariation(Orientation orientation, Boolean reflected, ImmutableArray<string> pattern)
        {
            Orientation = orientation;
            Reflected = reflected;
            Pattern = pattern;
        }

        public readonly Orientation Orientation;
        public readonly Boolean Reflected;
        public readonly ImmutableArray<string> Pattern;
    }

    class PatternVariationComparer : IEqualityComparer<PatternVariation>
    {
        public bool Equals(PatternVariation pv1, PatternVariation pv2)
        {
            return pv1.Pattern.SequenceEqual(pv2.Pattern);
        }

        public int GetHashCode(PatternVariation pv)
        {
            return 0;
        }
    }
}
