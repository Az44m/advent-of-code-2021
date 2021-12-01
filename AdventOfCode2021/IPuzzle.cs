using System.Collections.Generic;

namespace AdventOfCode2021 {
    public interface IPuzzle {
        bool SampleMode { get; }
        (object, object) Solve(List<string> input);
    }
}