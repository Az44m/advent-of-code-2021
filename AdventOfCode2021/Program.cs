namespace AdventOfCode2021 {
    public class Program {
        private static void Main() {
            AoCRunner.Run(2021, 3,
             new() {
                 new Day01.Puzzle(),
                 new Day02.Puzzle(),
                 new Day03.Puzzle(),
             });
        }
    }
}
