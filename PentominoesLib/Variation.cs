using System;
using System.Linq;
using System.Collections.Generic;

namespace PentominoesLib
{
    public class Variation
    {
        public Variation(Orientation orientation, Boolean reflected, IEnumerable<Coords> coords)
        {
            Orientation = orientation;
            Reflected = reflected;
            Coords = coords;
        }

        public readonly Orientation Orientation;
        public readonly Boolean Reflected;
        public readonly IEnumerable<Coords> Coords;
    }
}
