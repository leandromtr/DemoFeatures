using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using System.Text;

namespace aaaa
{
    public class Program
    {
        static void Main(string[] args)
        {
            var results = BenchmarkRunner.Run<Demo>();
        }
    }

    [MemoryDiagnoser]
    [SimpleJob(RuntimeMoniker.Net472, baseline:true)]
    [SimpleJob(RuntimeMoniker.Net60)]
    public class Demo
    {
        [Benchmark(Baseline = true)]
        public string GetFullStringNormally()
        {
            string output = "";

            for (int i = 0; i < 100; i++)
            {
                output += i;
            }
            return output;
        }

        [Benchmark]
        public string GetFullStringWithStringBuilder()
        {
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < 100; i++)
            {
                output.Append(i);
            }
            return output.ToString();
        }
    }

}
