using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day05 {
    public class Puzzle : IPuzzle {
        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {

            var mapPart1 = new Dictionary<(int x, int y), int>();
            var mapPart2 = new Dictionary<(int x, int y), int>();

            foreach (var item in input) {
                var splitted = item.Split(" -> ");
                var splitPoint1 = splitted[0].Split(',');
                var point1 = (x: int.Parse(splitPoint1[0]), y: int.Parse(splitPoint1[1]));
                var splitPoint2 = splitted[1].Split(',');
                var point2 = (x: int.Parse(splitPoint2[0]), y: int.Parse(splitPoint2[1]));

                if (point1.x == point2.x) {
                    var ys = new[] { point1.y, point2.y }.OrderBy(x => x).ToArray();
                    for (var i = ys[0]; i < ys[1] + 1; i++) {
                        var point = (point1.x, i);
                        if (!mapPart1.ContainsKey(point))
                            mapPart1[point] = 0;
                        mapPart1[point]++;
                        if (!mapPart2.ContainsKey(point))
                            mapPart2[point] = 0;
                        mapPart2[point]++;
                    }
                }
                else if (point1.y == point2.y) {
                    var xs = new[] { point1.x, point2.x }.OrderBy(x => x).ToArray();
                    for (var i = xs[0]; i < xs[1] + 1; i++) {
                        var point = (i, point1.y);
                        if (!mapPart1.ContainsKey(point))
                            mapPart1[point] = 0;
                        mapPart1[point]++;
                        if (!mapPart2.ContainsKey(point))
                            mapPart2[point] = 0;
                        mapPart2[point]++;
                    }
                }
                else {
                    var delta = (x: Math.Sign(point2.x - point1.x), y: Math.Sign(point2.y - point1.y));
                    var x = point1.x;
                    var y = point1.y;
                    var point = (x, y);
                    if (!mapPart2.ContainsKey(point))
                        mapPart2[point] = 0;
                    mapPart2[point]++;

                    while (x != point2.x) {
                        x += delta.x;
                        y += delta.y;
                        point = (x, y);
                        if (!mapPart2.ContainsKey(point))
                            mapPart2[point] = 0;
                        mapPart2[point]++;
                    }
                }
            }

            var part1 = mapPart1.Values.Sum(x => x > 1 ? 1 : 0);
            var part2 = mapPart2.Values.Sum(x => x > 1 ? 1 : 0);

            return (part1, part2);
        }
    }
}