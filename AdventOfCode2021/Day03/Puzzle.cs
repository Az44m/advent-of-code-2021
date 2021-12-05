using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.Day03 {
    public class Puzzle : IPuzzle {
        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {
            var part1 = Part1(input);
            var part2 = Part2(input);

            return (part1, part2);
        }

        private static long Part1(List<string> input) {
            var matrix = MatrixUtils.ToCharMatrix(input);
            var gammaRateString = new StringBuilder();

            for (var i = 0; i < matrix.GetLength(1); i++) {
                var column = MatrixUtils.GetMatrixColumn(matrix, i);
                var ones = column.Sum(bit => bit == '1' ? 1 : 0);
                _ = gammaRateString.Append(ones >= matrix.GetLength(0) / 2f ? '1' : '0');
            }

            var gammaRate = Convert.ToInt32(gammaRateString.ToString(), 2);
            var epsilonRate = Convert.ToInt32(BinaryUtils.Complement(gammaRateString.ToString()), 2);

            return gammaRate * epsilonRate;
        }

        private static long Part2(List<string> input) {
            var o2RateString = CalculateRating(input, (bool filter) => filter ? '1' : '0');
            var co2RateString = CalculateRating(input, (bool filter) => filter ? '0' : '1');

            var o2Rate = Convert.ToInt32(o2RateString.ToString(), 2);
            var co2Rate = Convert.ToInt32(co2RateString.ToString(), 2);

            return o2Rate * co2Rate;
        }

        private static string CalculateRating(List<string> input, Func<bool, char> filterFunction) {
            var filteredInput = input.ToList();

            for (var i = 0; i < filteredInput[0].Length; i++) {
                var matrix = MatrixUtils.ToCharMatrix(filteredInput);
                var column = MatrixUtils.GetMatrixColumn(matrix, i);
                var ones = column.Sum(bit => bit == '1' ? 1 : 0);
                var filter = ones >= matrix.GetLength(0) / 2f;
                if (filteredInput.Count > 1)
                    filteredInput = filteredInput.Where(x => x[i] == filterFunction(filter)).ToList();
            }

            return filteredInput.First();
        }
    }
}