using System;
using System.Collections.Immutable;

namespace PentominoesLib
{
    public class PieceDescription
    {
        public PieceDescription(string label, ImmutableArray<string> pattern)
        {
            Label = label;
            Pattern = pattern;
        }

        public readonly string Label;
        public readonly ImmutableArray<string> Pattern;
    }
}
