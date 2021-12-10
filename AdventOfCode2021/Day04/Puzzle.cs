using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day04 {
    public class Puzzle : IPuzzle {
        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {
            var numbers = input[0].Split(',').Select(x => int.Parse(x));

            var bingoBoards = CreateBingoBoards(input.Skip(2).Select(line => line.Replace("  ", " ")).ToList()).ToList();
            var part1 = 0;
            foreach (var number in numbers) {
                bingoBoards = bingoBoards.Select(board => MatrixUtils.FindAndReplace(board, number, -1)).ToList();
                foreach (var board in bingoBoards.ToList()) {
                    for (var i = 0; i < board.GetLength(0); i++) {
                        var row = MatrixUtils.GetRow(board, i);
                        var col = MatrixUtils.GetColumn(board, i);
                        if (row.All(x => x == -1) || col.All(x => x == -1)) {
                            var result = MatrixUtils.Find(board, (cell) => cell > -1);
                            part1 = result.Sum(x => x) * number;
                            break;
                        }
                    }
                    if (part1 > 0)
                        break;
                }
                if (part1 > 0)
                    break;
            }

            bingoBoards = CreateBingoBoards(input.Skip(2).Select(line => line.Replace("  ", " ")).ToList()).ToList();
            var index = bingoBoards.Count;
            var part2 = 0;
            foreach (var number in numbers) {
                bingoBoards = bingoBoards.Select(board => MatrixUtils.FindAndReplace(board, number, -1)).ToList();
                for (var j = 0; j < bingoBoards.ToList().Count; j++) {
                    var board = bingoBoards.ToList()[j];
                    var winner = false;
                    for (var i = 0; i < board.GetLength(0); i++) {
                        var row = MatrixUtils.GetRow(board, i);
                        var col = MatrixUtils.GetColumn(board, i);
                        if (row.All(x => x == -1) || col.All(x => x == -1)) {
                            winner = true;
                            break;
                        }
                    }
                    if (winner) {
                        if (bingoBoards.Count > 1) {
                            bingoBoards.RemoveAt(j);
                        }
                        else {
                            var result = MatrixUtils.Find(board, (cell) => cell > -1);
                            part2 = result.Sum(x => x) * number;
                            break;
                        }
                    }
                    if (part2 > 0)
                        break;
                }
                if (part2 > 0)
                    break;
            }

            return (part1, part2);
        }

        private static IEnumerable<int[,]> CreateBingoBoards(List<string> input) {
            var flattenedImageFragments = InputProcessingUtils.ConcatGroupOfLines(input, "\n", string.Empty);

            foreach (var line in flattenedImageFragments) {
                if (line == string.Empty)
                    continue;

                var imageFragmentWithTitle = line.Replace("\n ", "\n");
                yield return MatrixUtils.LineToIntMatrix(imageFragmentWithTitle, " ", "\n");
            }
        }
    }
}