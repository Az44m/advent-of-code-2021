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
    }
}