using System.Collections.Generic;

namespace AdventOfCode2021.Day11 {
    public class Puzzle : IPuzzle {
        public bool SampleMode => false;

        public (object, object) Solve(List<string> input) {
            var octopuses = MatrixUtils.ToIntMatrix(input);
            var numberOfIterations = 400;
            var flashes = 0;
            var allFlashedAt = 0;
            var numberOfOctopuses = octopuses.GetLength(0) * octopuses.GetLength(1);

            void SimulateEnergyLevelChange(int[,] octopuses, int x, int y, bool[,] flashMap, int iterations) {
                if (octopuses[x, y] == 0) {
                    if (!flashMap[x, y]) {
                        octopuses[x, y]++;
                    }
                    return;
                }

                if (octopuses[x, y] == 9) {
                    octopuses[x, y] = 0;
                    flashMap[x, y] = true;
                    if (iterations < 100)
                        flashes++;
                    var neighbors = MatrixUtils.GetDirect8NeighborsWithCoordinates(octopuses, x, y);
                    foreach (var neighbor in neighbors) {
                        SimulateEnergyLevelChange(octopuses, neighbor.Key.x, neighbor.Key.y, flashMap, iterations);
                    }
                }
                else if (octopuses[x, y] != 9) {
                    octopuses[x, y]++;
                }
            }

            for (var i = 0; i < numberOfIterations; i++) {
                var flashMap = new bool[octopuses.GetLength(0), octopuses.GetLength(1)];
                for (var x = 0; x < octopuses.GetLength(0); x++) {
                    for (var y = 0; y < octopuses.GetLength(1); y++) {
                        SimulateEnergyLevelChange(octopuses, x, y, flashMap, i);
                    }
                }
                if (MatrixUtils.Find(flashMap, x => x == true).Count == numberOfOctopuses) {
                    allFlashedAt = i + 1;
                    break;
                }
            }

            return (flashes, allFlashedAt);
        }
    }
}