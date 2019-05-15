using System;
using System.Collections.Immutable;

namespace PentominoesLib
{
    public class Variation
    {
        public Variation(Orientation orientation, bool reflected, ImmutableArray<Coords> coords)
        {
            Orientation = orientation;
            Reflected = reflected;
            Coords = coords;
        }

        public readonly Orientation Orientation;
        public readonly bool Reflected;
        public readonly ImmutableArray<Coords> Coords;
    }
}
