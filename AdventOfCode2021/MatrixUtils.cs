using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021 {
    public static class MatrixUtils {

        public static T[] GetMatrixColumn<T>(T[,] matrix, int columnNumber) {
            return Enumerable
                .Range(0, matrix.GetLength(0))
                .Select(x => matrix[x, columnNumber])
                .ToArray();
        }

        public static T[] GetMatrixRow<T>(T[,] matrix, int rowNumber) {
            return Enumerable
                .Range(0, matrix.GetLength(1))
                .Select(x => matrix[rowNumber, x])
                .ToArray();
        }

        public static char[,] ToCharMatrix<T>(T input) where T : IList<string> {
            var matrix = new char[input.Count, input[0].Length];
            for (var x = 0; x < input.Count; x++) {
                for (var y = 0; y < input[x].Length; y++)
                    matrix[x, y] = input[x][y];
            }

            return matrix;
        }

        public static int[,] ToIntMatrix<T>(T input) where T : IList<string> {
            var matrix = new int[input.Count, input[0].Length];
            for (var x = 0; x < input.Count; x++) {
                for (var y = 0; y < input[x].Length; y++)
                    matrix[x, y] = (int)char.GetNumericValue(input[x][y]);
            }

            return matrix;
        }

        public static readonly (int x, int y)[] NeighborDirections4 = { (0, 1), (1, 0), (0, -1), (-1, 0) };

        public static bool IsWithinBounds(int x, int y, int width, int height) => x >= 0 && x < width && y >= 0 && y < height;

        public static IEnumerable<T> GetDirect4Neighbors<T>(T[,] matrix, int x, int y) => GetDirectNeighbors(matrix, x, y, NeighborDirections4);

        private static IEnumerable<T> GetDirectNeighbors<T>(T[,] matrix, int x, int y, (int x, int y)[] neighborDirections) {
            return neighborDirections
                .Where(dir => IsWithinBounds(dir.x + x, dir.y + y, matrix.GetLength(0), matrix.GetLength(1)))
                .Select(pos => matrix[pos.x + x, pos.y + y]);
        }
    }
}