using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day08 {
    public class Puzzle : IPuzzle {
        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {
            var part1 = 0;
            var part2 = 0;

            foreach (var row in input) {
                var splitted = row.Split(" | ");
                var patterns = splitted[0].Split(' ').ToList();
                var outputDigits = splitted[1].Split(' ').Select(d => new string(d.ToCharArray().OrderBy(x => x).ToArray())).ToList();

                var digits = new Dictionary<int, string> {
                    [1] = patterns.First(x => x.Length == 2),
                    [4] = patterns.First(x => x.Length == 4),
                    [7] = patterns.First(x => x.Length == 3),
                    [8] = patterns.First(x => x.Length == 7)
                };

                digits[9] = patterns.First(x => x.Length == 6 && x.Except(digits[4]).Count() == 2);
                digits[6] = patterns.First(x => x.Length == 6 && x.Except(digits[7]).Count() == 4);
                digits[0] = patterns.First(x => x.Length == 6 && x != digits[6] && x != digits[9]);

                digits[3] = patterns.First(x => x.Length == 5 && x.Except(digits[1]).Count() == 3);
                digits[2] = patterns.First(x => x.Length == 5 && x.Except(digits[4]).Count() == 3);
                digits[5] = patterns.First(x => x.Length == 5 && x != digits[2] && x != digits[3]);

                for (var i = 0; i < digits.Count; i++)
                    digits[i] = new string(digits[i].ToCharArray().OrderBy(x => x).ToArray());

                var simpleDigitCount = outputDigits.Sum(d => d == digits[1] || d == digits[4] || d == digits[7] || d == digits[8] ? 1 : 0);
                var number = string.Join("", outputDigits.Select(d => digits.First(x => x.Value == d).Key.ToString()));

                part1 += simpleDigitCount;
                part2 += int.Parse(number);
            }

            return (part1, part2);
        }
    }
}