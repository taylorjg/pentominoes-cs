using System;
using System.Collections.Immutable;

namespace PentominoesLib
{
    public class Piece
    {
        public Piece(string label, ImmutableArray<Variation> variations)
        {
            Label = label;
            Variations = variations;
        }

        public readonly string Label;
        public readonly ImmutableArray<Variation> Variations;
    }
}
