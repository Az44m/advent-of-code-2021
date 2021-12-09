using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day09 {
    public class Puzzle : IPuzzle {
        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {
            var matrix = MatrixUtils.ToIntMatrix(input);

            var part1 = 0;
            var basinSizes = new List<int>();

            for (var x = 0; x < matrix.GetLength(0); x++) {
                for (var y = 0; y < matrix.GetLength(1); y++) {
                    var neighbors = MatrixUtils.GetDirect4Neighbors(matrix, x, y);
                    var isLowPoint = neighbors.All(n => n > matrix[x, y]);
                    if (isLowPoint) {
                        part1 += matrix[x, y] + 1;
                        basinSizes.Add(CalculateBasinSize_FloodFill(MatrixUtils.ToIntMatrix(input), x, y));
                    }
                }
            }

            var part2 = basinSizes.OrderByDescending(x => x).Take(3).Aggregate((x, y) => x * y);
            return (part1, part2);
        }

        private static int CalculateBasinSize_FloodFill(int[,] matrix, int x, int y) {
            var basinSize = 0;
            var positions = new Stack<(int x, int y)>();
            positions.Push((x, y));

            while (positions.Count > 0) {
                var p = positions.Pop();
                if (MatrixUtils.IsWithinBounds(p.x, p.y, matrix.GetLength(0), matrix.GetLength(1))) {
                    if (matrix[p.x, p.y] is < 9 and not -1) {
                        matrix[p.x, p.y] = -1;
                        basinSize++;
                        foreach (var position in MatrixUtils.NeighborDirections4.Select(p1 => (p1.x + p.x, p1.y + p.y))) {
                            positions.Push(position);
                        }
                    }
                }
            }

            return basinSize;
        }
    }
}