using System;
using System.Collections.Generic;

namespace AdventOfCode2021 {
    public static class AoCRunner {
        public static void Run(int year, int day, List<IPuzzle> puzzles) {
            var puzzle = puzzles[day - 1];
            var input = new InputLoader(year).ReadInput(day, puzzle.SampleMode);
            var result = puzzle.Solve(input);
            new ClipboardUtils().CopyToClipBoard(result.Item2 ?? result.Item1);
            Console.WriteLine(result);
        }
    }
}