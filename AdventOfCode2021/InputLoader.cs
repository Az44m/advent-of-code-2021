using System.Threading;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System;

namespace AdventOfCode2021 {
    public class InputLoader {
        private const string Session = "<SESSION>";
        public int Year { get; }

        public InputLoader(int year) => Year = year;

        public List<string> ReadInput(int day, bool sample = false) {
            var basePath = $"Day{day:D2}";
            if (!Directory.Exists(basePath))
                basePath = $"AdventOfCode{Year}\\Day{day:D2}";

            var inputPath = $"{basePath}\\day{day:D2}.in";
            var samplePath = $"{basePath}\\day{day:D2}.sample";

            if (!File.Exists(inputPath))
                File.Create(inputPath).Close();
            if (!File.Exists(samplePath))
                File.Create(samplePath).Close();

            if (sample)
                return File.ReadLines(samplePath).ToList();

            var fileLines = File.ReadLines(inputPath).ToList();
            if (fileLines.Any())
                return fileLines;

            var webLines = GetInput($"https://adventofcode.com/{Year}/day/{day}/input");

            if (!webLines.Any())
                Console.WriteLine("Couldn't fetch the input. Out of tries...");

            File.WriteAllLines(inputPath, webLines);

            return webLines;
        }

        private static List<string> GetInput(string uri) {
            var counter = 0;
            while (counter < 6) {
                var lines = TryGetInput(uri);
                if (lines.Any())
                    return lines;
                counter++;
                Thread.Sleep(10000);
            }
            return new List<string>();
        }

        private static List<string> TryGetInput(string uri) {
            var lines = new List<string>();

            try {
                var request = (HttpWebRequest)WebRequest.Create(uri);

                var cookieContainer = new CookieContainer();
                var cookie = new Cookie("session", Session) {
                    Domain = "adventofcode.com"
                };
                cookieContainer.Add(cookie);
                request.CookieContainer = cookieContainer;
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate | DecompressionMethods.Brotli;

                using var response = request.GetResponse();
                using var stream = response.GetResponseStream();
                using var reader = new StreamReader(stream);

                string line;
                while ((line = reader.ReadLine()) != null)
                    lines.Add(line);
            }
            catch (WebException) {
                Console.WriteLine("Couldn't fetch the input. Try again...");
                return lines;
            }

            Console.WriteLine("Input fetched. Preview:");
            Console.WriteLine(string.Join('\n', lines.Take(5)));

            return lines;
        }
    }
}