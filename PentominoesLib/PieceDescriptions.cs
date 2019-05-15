using System;
using System.Collections.Immutable;

namespace PentominoesLib
{
    public static class PieceDescriptions
    {
        public static ImmutableArray<PieceDescription> AllPieceDescriptions = ImmutableArray.Create(
            new PieceDescription("F", ImmutableArray.Create(
                " XX",
                "XX ",
                " X "
            )),
            new PieceDescription("I", ImmutableArray.Create(
                "X",
                "X",
                "X",
                "X",
                "X"
            )),
            new PieceDescription("L", ImmutableArray.Create(
                "X ",
                "X ",
                "X ",
                "XX"
            )),
            new PieceDescription("P", ImmutableArray.Create(
                "XX",
                "XX",
                "X "
            )),
            new PieceDescription("N", ImmutableArray.Create(
                " X",
                "XX",
                "X ",
                "X "
            )),
            new PieceDescription("T", ImmutableArray.Create(
                "XXX",
                " X ",
                " X "
            )),
            new PieceDescription("U", ImmutableArray.Create(
                "X X",
                "XXX"
            )),
            new PieceDescription("V", ImmutableArray.Create(
                "X  ",
                "X  ",
                "XXX"
            )),
            new PieceDescription("W", ImmutableArray.Create(
                "X  ",
                "XX ",
                " XX"
            )),
            new PieceDescription("X", ImmutableArray.Create(
                " X ",
                "XXX",
                " X "
            )),
            new PieceDescription("Y", ImmutableArray.Create(
                " X",
                "XX",
                " X",
                " X"
            )),
            new PieceDescription("Z", ImmutableArray.Create(
                "XX ",
                " X ",
                " XX"
            ))
        );
    }
}
