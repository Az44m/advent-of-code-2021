using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day10 {
    public class Puzzle : IPuzzle {
        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {

            var pairs = new[] { (a: '[', b: ']'), (a: '(', b: ')'), (a: '{', b: '}'), (a: '<', b: '>') };
            var pointMapPart1 = new Dictionary<char, int>() { { ')', 3 }, { ']', 57 }, { '}', 1197 }, { '>', 25137 } };
            var pointMapPart2 = new Dictionary<char, int>() { { ')', 1 }, { ']', 2 }, { '}', 3 }, { '>', 4 } };

            long part1 = 0;
            var pointsPart2 = new List<long>();

            foreach (var line in input) {
                var error = false;
                var syntaxStack = new Stack<char>();

                for (var i = 0; i < line.Length; i++) {
                    var c = line[i];
                    if (c is '[' or '(' or '{' or '<') {
                        syntaxStack.Push(c);
                    }
                    else {
                        var c2 = syntaxStack.Pop();
                        var (_, b) = pairs.First(p => p.a == c2);
                        if (c != b) {
                            part1 += pointMapPart1[c];
                            error = true;
                            break;
                        }
                    }
                }

                if (syntaxStack.Count > 0 && !error) {
                    var completionString = "";
                    long points = 0;
                    while (syntaxStack.Count > 0) {
                        var c2 = syntaxStack.Pop();
                        var (_, b) = pairs.First(p => p.a == c2);
                        completionString += b;
                    }
                    foreach (var c in completionString) {
                        points *= 5;
                        points += pointMapPart2[c];
                    }
                    pointsPart2.Add(points);
                }
            }

            var part2 = pointsPart2.OrderBy(x => x).ToArray()[pointsPart2.Count / 2];

            return (part1, part2);
        }

    }
}