using BenchmarkDotNet.Running;
using Dgt.Dojo.Optimisations;

_ = BenchmarkSwitcher.FromAssembly(typeof(AssemblyMarker).Assembly).Run(args);