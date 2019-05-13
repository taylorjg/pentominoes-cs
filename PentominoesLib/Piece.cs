using System;
using System.Linq;
using System.Collections.Generic;

namespace PentominoesLib
{
    public class Piece
    {
        public Piece(string label, IEnumerable<Variation> variations)
        {
            Label = label;
            Variations = variations;
        }

        public readonly string Label;
        public readonly IEnumerable<Variation> Variations;
    }
}
