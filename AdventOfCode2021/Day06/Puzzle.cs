using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day06 {
    public class Puzzle : IPuzzle {
        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {

            var fish = input[0].Split(',')
                .Select(x => int.Parse(x))
                .GroupBy(x => x)
                .ToDictionary(g => g.Key, g => (long)g.Count());

            for (var i = 0; i < 9; i++) {
                if (!fish.ContainsKey(i))
                    fish[i] = 0;
            }

            for (var i = 0; i < 80; i++)
                fish = SimulateADay(fish);
            var part1 = fish.Values.Sum();

            for (var i = 80; i < 256; i++)
                fish = SimulateADay(fish);
            var part2 = fish.Values.Sum();

            return (part1, part2);
        }
        private static Dictionary<int, long> SimulateADay(Dictionary<int, long> fish) {
            return new() {
                [0] = fish[1],
                [1] = fish[2],
                [2] = fish[3],
                [3] = fish[4],
                [4] = fish[5],
                [5] = fish[6],
                [6] = fish[7] + fish[0],
                [7] = fish[8],
                [8] = fish[0],
            };
        }
    }
}