using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day02 {
    public class Puzzle : IPuzzle {
        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {
            var moves = input
                  .Select(x => {
                      var splitted = x.Split(' ');
                      var direction = splitted[0];
                      var value = int.Parse(splitted[1]);
                      return (direction, value);
                  })
                  .ToList();

            (int depth, int dist) submarinePositionPart1 = (0, 0);
            (int depth, int dist, int aim) submarinePositionPart2 = (0, 0, 0);

            for (var i = 0; i < moves.Count; i++) {
                if (moves[i].direction == "forward") {
                    submarinePositionPart1.dist += moves[i].value;
                    submarinePositionPart2.depth += moves[i].value;
                    submarinePositionPart2.dist += submarinePositionPart2.aim * moves[i].value;
                }
                if (moves[i].direction == "up") {
                    submarinePositionPart1.depth += moves[i].value;
                    submarinePositionPart2.aim -= moves[i].value;
                }
                if (moves[i].direction == "down") {
                    submarinePositionPart1.depth -= moves[i].value;
                    submarinePositionPart2.aim += moves[i].value;
                }
            }

            var part1 = Math.Abs(submarinePositionPart1.dist * submarinePositionPart1.depth);
            var part2 = Math.Abs(submarinePositionPart2.dist * submarinePositionPart2.depth);

            return (part1, part2);
        }

    }
}