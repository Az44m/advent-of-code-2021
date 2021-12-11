namespace AdventOfCode2021 {
    public class Program {
        private static void Main() {
            AoCRunner.Run(2021, 5,
             new() {
                 new Day01.Puzzle(),
                 new Day02.Puzzle(),
                 new Day03.Puzzle(),
                 new Day04.Puzzle(),
                 new Day05.Puzzle(),
                 new Day06.Puzzle(),
                 new Day07.Puzzle(),
                 new Day08.Puzzle(),
                 new Day09.Puzzle(),
                 new Day10.Puzzle(),
             });
        }
    }
}
