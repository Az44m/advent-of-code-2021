using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021.Day13 {
    public class Puzzle : IPuzzle {
        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {
            var coordinates = new List<(int x, int y)>();
            var folds = new List<(bool isX, int position)>();
            var parseFolds = false;
            foreach (var item in input) {
                if (string.IsNullOrWhiteSpace(item)) {
                    parseFolds = true;
                    continue;
                }
                if (!parseFolds) {
                    var splitted = item.Split(',');
                    coordinates.Add((int.Parse(splitted[1]), int.Parse(splitted[0])));
                }
                else {
                    var splitted = item.Split(new[] { ' ', '=' }).TakeLast(2).ToArray();
                    folds.Add((splitted[0] == "x", int.Parse(splitted[1])));
                }
            }

            var map = new Dictionary<(int x, int y), int>();

            foreach (var item in coordinates) {
                if (!map.ContainsKey(item))
                    map[item] = 0;

                map[item]++;
            }

            var part1 = 0;

            for (var i = 0; i < folds.Count; i++) {
                var (isX, position) = folds[i];
                foreach (var item in new Dictionary<(int x, int y), int>(map)) {
                    if (!isX) {
                        if (item.Key.x > position) {
                            map[item.Key] = 0;
                            map[(item.Key.x - (item.Key.x - position) * 2, item.Key.y)] = 1;
                        }
                    }
                    else {
                        if (item.Key.y > position) {
                            map[item.Key] = 0;
                            map[(item.Key.x, item.Key.y - (item.Key.y - position) * 2)] = 1;
                        }
                    }
                }
                if (i == 0)
                    part1 = map.Values.Sum(x => x > 0 ? 1 : 0);
            }

            var lines = new StringBuilder();
            for (var x = 0; x < 10; x++) {
                for (var y = 0; y < 50; y++) {
                    if (map.ContainsKey((x, y)) && map[(x, y)] > 0) {
                        _ = lines.Append('#');
                    }
                    else {
                        _ = lines.Append('.');
                    }
                }
                _ = lines.AppendLine();
            }

            LogUtils.Log(lines.ToString());

            return (part1, null);
        }


    }
}