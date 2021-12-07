using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day07 {
    public class Puzzle : IPuzzle {
        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {
            var positions = input[0].Split(',').Select(x => int.Parse(x)).OrderBy(x => x).ToList();
            var size = positions.Count;
            var mid = size / 2;
            var median = (size % 2 != 0) ? positions[mid] : (positions[mid] + positions[mid - 1]) / 2;
            var part1 = positions.Sum(x => Math.Abs(x - median));

            var part2 = Enumerable.Range(positions.Min(), positions.Max())
                           .Select(p => positions.Sum(p2 => Cost(Math.Abs(p2 - p))))
                           .Min();

            return (part1, part2);
        }

        private static int Cost(int move) {
            return move * (move + 1) / 2;
        }
    }
}