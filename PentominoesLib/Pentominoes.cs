using System;
using System.Linq;
using System.Collections.Generic;
using DlxLib;

namespace PentominoesLib
{
    public static class Pentominoes
    {
        public static IEnumerable<Solution> Solve()
        {
            var matrix = new[,]
                {
                    {1, 0, 0, 0},
                    {0, 1, 1, 0},
                    {1, 0, 0, 1},
                    {0, 0, 1, 1},
                    {0, 1, 0, 0},
                    {0, 0, 1, 0}
                };
            var dlx = new Dlx();
            return dlx.Solve(matrix);
        }
    }
}
