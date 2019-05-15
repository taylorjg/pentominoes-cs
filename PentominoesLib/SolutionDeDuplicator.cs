using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;
using DlxLib;

namespace PentominoesLib
{
    public class SolutionDeDuplicator
    {
        public bool SolutionIsUnique(ImmutableArray<Placement> placements)
        {
            var board1 = Pentominoes.FormatSolution(placements);
            var board2 = StringManipulations.RotateStrings(board1);
            var board3 = StringManipulations.RotateStrings(board2);
            var board4 = StringManipulations.RotateStrings(board3);
            var board5 = StringManipulations.ReflectStrings(board1);
            var board6 = StringManipulations.ReflectStrings(board2);
            var board7 = StringManipulations.ReflectStrings(board3);
            var board8 = StringManipulations.ReflectStrings(board4);
            var boards = new[] {
                string.Join("|", board1),
                string.Join("|", board2),
                string.Join("|", board3),
                string.Join("|", board4),
                string.Join("|", board5),
                string.Join("|", board6),
                string.Join("|", board7),
                string.Join("|", board8)
            };
            return UniqueBoards.Intersect(boards).Count() == 0;
        }


        public void Add(ImmutableArray<Placement> placements)
        {
            var board = string.Join("|", Pentominoes.FormatSolution(placements));
            UniqueSolutions.Add(placements);
            UniqueBoards.Add(board);
        }

        public ImmutableArray<ImmutableArray<Placement>> GetUniqueSolutions() {
            return UniqueSolutions.ToImmutableArray();
        }

        private List<ImmutableArray<Placement>> UniqueSolutions = new List<ImmutableArray<Placement>>();
        private List<string> UniqueBoards = new List<string>();
    }
}
