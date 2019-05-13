using System;
using System.Linq;
using System.Collections.Generic;

namespace PentominoesLib
{
    public static class Manipulations
    {
        public static IEnumerable<string> RotateStrings(IEnumerable<string> strings)
        {
            var stringsList = strings.ToList();
            var w = stringsList[0].Length;
            var h = stringsList.Count;
            var reversedStrings = ReflectStrings(strings).ToArray();
            var xs = Enumerable.Range(0, w);
            var ys = Enumerable.Range(0, h);
            return xs.Select(x => new String(ys.Select(y => reversedStrings[y][x]).ToArray()));
        }

        public static IEnumerable<string> ReflectStrings(IEnumerable<string> strings)
        {
            return strings.Select(s => new String(s.ToArray().Reverse().ToArray()));
        }
    }
}
