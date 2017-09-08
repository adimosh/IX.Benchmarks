//using IX.StandardExtensions.TestUtils;
using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace IX.Benchmarks
{
    public class StringShifting
    {
        private readonly ITestOutputHelper output;

        public StringShifting(ITestOutputHelper output)
        {
            this.output = output;
        }

        private const int iterations = 1000000;

        private string ShiftLeftCopyToArray(string originalString, int shiftDistance)
        {
            var length = originalString.Length;
            var breakpoint = length - shiftDistance;
            char[] charArray = new char[length];

            originalString.CopyTo(shiftDistance, charArray, 0, breakpoint);
            originalString.CopyTo(0, charArray, breakpoint, shiftDistance);

            return new string(charArray);
        }

        private string ShiftLeftSubstring(string originalString, int shiftDistance) => originalString.Substring(shiftDistance) + originalString.Substring(0, shiftDistance);

        [Fact(DisplayName = "String shift left algorithms comparison.")]
        public void Benchmark()
        {
            // Preparation
            string data;
            string finalDataMethod1;
            string finalDataMethod2;
            var sw = new Stopwatch();

            // Very small size string
            // =================
            data = DataGenerator.RandomString(5);

            // Method 1
            finalDataMethod1 = data;
            sw.Start();
            for (var i = 0; i < iterations; i++)
            {
                finalDataMethod1 = ShiftLeftCopyToArray(finalDataMethod1, 3);
            }
            sw.Stop();
            this.output.WriteLine($"Left shift by copying char array took {sw.ElapsedMilliseconds} ms on a string of length {data.Length}.");
            sw.Reset();

            // Method 2
            finalDataMethod2 = data;
            sw.Start();
            for (var i = 0; i < iterations; i++)
            {
                finalDataMethod2 = ShiftLeftCopyToArray(finalDataMethod2, 3);
            }
            sw.Stop();
            this.output.WriteLine($"Left shift by substring took {sw.ElapsedMilliseconds} ms on a string of length {data.Length}.");
            sw.Reset();

            Assert.Equal(finalDataMethod1, finalDataMethod2);

            // Small size string
            // =================
            data = DataGenerator.RandomString(20);

            // Method 1
            finalDataMethod1 = data;
            sw.Start();
            for (var i = 0; i < iterations; i++)
            {
                finalDataMethod1 = ShiftLeftCopyToArray(finalDataMethod1, 7);
            }
            sw.Stop();
            this.output.WriteLine($"Left shift by copying char array took {sw.ElapsedMilliseconds} ms on a string of length {data.Length}.");
            sw.Reset();

            // Method 2
            finalDataMethod2 = data;
            sw.Start();
            for (var i = 0; i < iterations; i++)
            {
                finalDataMethod2 = ShiftLeftCopyToArray(finalDataMethod2, 7);
            }
            sw.Stop();
            this.output.WriteLine($"Left shift by substring took {sw.ElapsedMilliseconds} ms on a string of length {data.Length}.");
            sw.Reset();

            Assert.Equal(finalDataMethod1, finalDataMethod2);

            // Medium size string
            // =================
            data = DataGenerator.RandomString(50);

            // Method 1
            finalDataMethod1 = data;
            sw.Start();
            for (var i = 0; i < iterations; i++)
            {
                finalDataMethod1 = ShiftLeftCopyToArray(finalDataMethod1, 7);
            }
            sw.Stop();
            this.output.WriteLine($"Left shift by copying char array took {sw.ElapsedMilliseconds} ms on a string of length {data.Length}.");
            sw.Reset();

            // Method 2
            finalDataMethod2 = data;
            sw.Start();
            for (var i = 0; i < iterations; i++)
            {
                finalDataMethod2 = ShiftLeftCopyToArray(finalDataMethod2, 7);
            }
            sw.Stop();
            this.output.WriteLine($"Left shift by substring took {sw.ElapsedMilliseconds} ms on a string of length {data.Length}.");
            sw.Reset();

            Assert.Equal(finalDataMethod1, finalDataMethod2);

            // Big size string
            // =================
            data = DataGenerator.RandomString(120);

            // Method 1
            finalDataMethod1 = data;
            sw.Start();
            for (var i = 0; i < iterations; i++)
            {
                finalDataMethod1 = ShiftLeftCopyToArray(finalDataMethod1, 7);
            }
            sw.Stop();
            this.output.WriteLine($"Left shift by copying char array took {sw.ElapsedMilliseconds} ms on a string of length {data.Length}.");
            sw.Reset();

            // Method 2
            finalDataMethod2 = data;
            sw.Start();
            for (var i = 0; i < iterations; i++)
            {
                finalDataMethod2 = ShiftLeftCopyToArray(finalDataMethod2, 7);
            }
            sw.Stop();
            this.output.WriteLine($"Left shift by substring took {sw.ElapsedMilliseconds} ms on a string of length {data.Length}.");
            sw.Reset();

            Assert.Equal(finalDataMethod1, finalDataMethod2);

            // Gigantic size string
            // =================
            data = DataGenerator.RandomString(1000);

            // Method 1
            finalDataMethod1 = data;
            sw.Start();
            for (var i = 0; i < iterations; i++)
            {
                finalDataMethod1 = ShiftLeftCopyToArray(finalDataMethod1, 7);
            }
            sw.Stop();
            this.output.WriteLine($"Left shift by copying char array took {sw.ElapsedMilliseconds} ms on a string of length {data.Length}.");
            sw.Reset();

            // Method 2
            finalDataMethod2 = data;
            sw.Start();
            for (var i = 0; i < iterations; i++)
            {
                finalDataMethod2 = ShiftLeftCopyToArray(finalDataMethod2, 7);
            }
            sw.Stop();
            this.output.WriteLine($"Left shift by substring took {sw.ElapsedMilliseconds} ms on a string of length {data.Length}.");
            sw.Reset();

            Assert.Equal(finalDataMethod1, finalDataMethod2);

            // Humongous size string
            // =================
            data = DataGenerator.RandomString(10000);

            // Method 1
            finalDataMethod1 = data;
            sw.Start();
            for (var i = 0; i < iterations; i++)
            {
                finalDataMethod1 = ShiftLeftCopyToArray(finalDataMethod1, 7);
            }
            sw.Stop();
            this.output.WriteLine($"Left shift by copying char array took {sw.ElapsedMilliseconds} ms on a string of length {data.Length}.");
            sw.Reset();

            // Method 2
            finalDataMethod2 = data;
            sw.Start();
            for (var i = 0; i < iterations; i++)
            {
                finalDataMethod2 = ShiftLeftCopyToArray(finalDataMethod2, 7);
            }
            sw.Stop();
            this.output.WriteLine($"Left shift by substring took {sw.ElapsedMilliseconds} ms on a string of length {data.Length}.");
            sw.Reset();

            Assert.Equal(finalDataMethod1, finalDataMethod2);
        }
    }
}
