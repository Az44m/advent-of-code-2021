
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021 {
    public static class LogUtils {
        public static void Log(string input) {
            Console.WriteLine(input);
        }

        public static void Log(params object[] input) {
            Console.WriteLine(string.Join(", ", input.Select(x => x.ToString())));
        }

        public static void Log<T>(IEnumerable<T> input) {
            Console.WriteLine(string.Join(", ", input.Select(x => x.ToString())));
        }

        public static void Log<T>(T[,] matrix) {
            for (var x = 0; x < matrix.GetLength(0); x++)
                Console.WriteLine(string.Join("", Enumerable.Range(0, matrix.GetLength(1)).Select(y => matrix[x, y]).ToArray()));
        }
    }
}