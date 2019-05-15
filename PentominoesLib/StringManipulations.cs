using System;
using System.Linq;
using System.Collections.Immutable;

namespace PentominoesLib
{
    public static class StringManipulations
    {
        public static ImmutableArray<string> RotateStrings(ImmutableArray<string> strings)
        {
            var reversedStrings = ReflectStrings(strings);
            var w = reversedStrings[0].Length;
            var h = reversedStrings.Length;
            var xs = Enumerable.Range(0, w);
            var ys = Enumerable.Range(0, h);
            return xs
                .Select(x => new string(ys.Select(y => reversedStrings[y][x]).ToArray()))
                .ToImmutableArray();
        }

        public static ImmutableArray<string> ReflectStrings(ImmutableArray<string> strings)
        {
            return strings
                .Select(s => new string(s.ToCharArray().Reverse().ToArray()))
                .ToImmutableArray();
        }
    }
}
