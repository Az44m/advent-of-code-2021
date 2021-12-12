using System;
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

        public static int[,] LineToIntMatrix(string input, string itemSeparator, string lineSeparator) {
            var splitted = input.Split(lineSeparator);
            var matrix = new int[splitted.Length, splitted.Length];
            for (var x = 0; x < splitted.Length; x++) {
                var splitted2 = splitted[x].Split(itemSeparator);
                for (var y = 0; y < splitted2.Length; y++)
                    matrix[x, y] = int.Parse(splitted2[y]);
            }

            return matrix;
        }

        public static List<T> Find<T>(T[,] matrix, Func<T, bool> filterFunction) {
            var result = new List<T>();
            for (var x = 0; x < matrix.GetLength(0); x++) {
                for (var y = 0; y < matrix.GetLength(1); y++) {
                    if (filterFunction(matrix[x, y]))
                        result.Add(matrix[x, y]);
                }
            }

            return result;
        }

        public static T[,] FindAndReplace<T>(T[,] matrix, T searchTerm, T replacement) {
            for (var x = 0; x < matrix.GetLength(0); x++) {
                for (var y = 0; y < matrix.GetLength(1); y++) {
                    if (EqualityComparer<T>.Default.Equals(matrix[x, y], searchTerm))
                        matrix[x, y] = replacement;
                }
            }

            return matrix;
        }

        public static T[] GetColumn<T>(T[,] matrix, int columnNumber) {
            return Enumerable.Range(0, matrix.GetLength(0))
                .Select(x => matrix[x, columnNumber])
                .ToArray();
        }

        public static T[] GetRow<T>(T[,] matrix, int rowNumber) {
            return Enumerable.Range(0, matrix.GetLength(1))
                .Select(x => matrix[rowNumber, x])
                .ToArray();
        }

        private static readonly (int x, int y)[] _neighborDirections4 = { (0, 1), (1, 0), (0, -1), (-1, 0) };
        private static readonly (int x, int y)[] _neighborDirections8 = { (-1, 1), (0, 1), (1, 1), (1, 0), (1, -1), (0, -1), (-1, -1), (-1, 0) };

        public static bool IsWithinBounds(int x, int y, int width, int height) => x >= 0 && x < width && y >= 0 && y < height;

        public static IEnumerable<T> GetDirect4Neighbors<T>(T[,] matrix, int x, int y) => GetDirectNeighbors(matrix, x, y, _neighborDirections4);
        public static IEnumerable<T> GetDirect8Neighbors<T>(T[,] matrix, int x, int y) => GetDirectNeighbors(matrix, x, y, _neighborDirections8);

        private static IEnumerable<T> GetDirectNeighbors<T>(T[,] matrix, int x, int y, (int x, int y)[] neighborDirections) {
            return neighborDirections
                .Where(dir => IsWithinBounds(dir.x + x, dir.y + y, matrix.GetLength(0), matrix.GetLength(1)))
                .Select(pos => matrix[pos.x + x, pos.y + y]);
        }

        public static Dictionary<(int x, int y), T> GetDirect4NeighborsWithCoordinates<T>(T[,] matrix, int x, int y) {
            return GetDirectNeighborsWithCoordinates(matrix, x, y, _neighborDirections4);
        }
        public static Dictionary<(int x, int y), T> GetDirect8NeighborsWithCoordinates<T>(T[,] matrix, int x, int y) {
            return GetDirectNeighborsWithCoordinates(matrix, x, y, _neighborDirections8);
        }

        private static Dictionary<(int x, int y), T> GetDirectNeighborsWithCoordinates<T>(T[,] matrix, int x, int y,
            (int x, int y)[] neighborDirections) {
            return neighborDirections
                .Where(dir => IsWithinBounds(dir.x + x, dir.y + y, matrix.GetLength(0), matrix.GetLength(1)))
                .ToDictionary(pos => (pos.x + x, pos.y + y), pos => matrix[pos.x + x, pos.y + y]);
        }

    }
}