
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021 {
    public static class LogUtils {
        public static void Log(params object[] input) {
            Console.WriteLine(string.Join(", ", input.Select(x => x.ToString())));
        }

        public static void Log<T>(IEnumerable<T> input) {
            Console.WriteLine(string.Join(", ", input.Select(x => x.ToString())));
        }
    }
}