namespace AdventOfCode2021 {
    public class Program {
        private static void Main() {
            AoCRunner.Run(2021, 8,
             new() {
                 new Day01.Puzzle(),
                 new Day02.Puzzle(),
                 new Day03.Puzzle(),
                 null,
                 null,
                 new Day06.Puzzle(),
                 new Day07.Puzzle(),
                 new Day08.Puzzle(),
             });
        }
    }
}
