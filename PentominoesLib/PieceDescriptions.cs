using System;
using System.Linq;
using System.Collections.Generic;

namespace PentominoesLib
{
    public static class PieceDescriptions
    {
        public static IEnumerable<PieceDescription> ThePieceDescriptions = new[] {
            new PieceDescription("F", new[]{
                " XX",
                "XX ",
                " X "
            }),
            new PieceDescription("I", new[]{
                "X",
                "X",
                "X",
                "X",
                "X"
            }),
            new PieceDescription("L", new[]{
                "X ",
                "X ",
                "X ",
                "XX"
            }),
            new PieceDescription("P", new[]{
                "XX",
                "XX",
                "X "
            }),
            new PieceDescription("N", new[]{
                " X",
                "XX",
                "X ",
                "X "
            }),
            new PieceDescription("T", new[]{
                "XXX",
                " X ",
                " X "
            }),
            new PieceDescription("U", new[]{
                "X X",
                "XXX"
            }),
            new PieceDescription("V", new[]{
                "X  ",
                "X  ",
                "XXX"
            }),
            new PieceDescription("W", new[]{
                "X  ",
                "XX ",
                " XX"
            }),
            new PieceDescription("X", new[]{
                " X ",
                "XXX",
                " X "
            }),
            new PieceDescription("Y", new[]{
                " X",
                "XX",
                " X",
                " X"
            }),
            new PieceDescription("Z", new[]{
                "XX ",
                " X ",
                " XX"
            }),
        };
    }
}
