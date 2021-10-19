using BenchmarkDotNet.Running;
using Dgt.Dojo.FizzBuzz;

_ = BenchmarkRunner.Run<FizzBuzzBenchmarks>();