using System.Linq;

namespace AdventOfCode2021 {
    public static class BinaryUtils {
        public static string Complement(string binaryNumber) {
            return new string(binaryNumber.Select(x => x == '0' ? '1' : '0').ToArray());
        }
    }
}