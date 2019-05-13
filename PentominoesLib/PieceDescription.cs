using System;
using System.Linq;
using System.Collections.Generic;

namespace PentominoesLib
{
    public class PieceDescription
    {
        public PieceDescription(string label, IEnumerable<string> pattern)
        {
            Label = label;
            Pattern = pattern;
        }

        public readonly string Label;
        public readonly IEnumerable<string> Pattern;
    }
}
