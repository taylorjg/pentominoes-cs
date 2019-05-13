using System;

namespace PentominoesLib
{
    public class Placement
    {
        public Placement(Piece piece, Variation variation, Coords location)
        {
            Piece = piece;
            Variation = variation;
            Location = location;
        }

        public readonly Piece Piece;
        public readonly Variation Variation;
        public readonly Coords Location;
    }
}
