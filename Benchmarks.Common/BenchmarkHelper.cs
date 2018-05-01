using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace Benchmarks.Common
{
    public static class BenchmarkHelper
    {
        public static void ValidateAndRun<TBenchmark>(params object[] validationArgs)
        {
            var benchmarks = Validate<TBenchmark>(validationArgs);
            var summary = BenchmarkRunner.Run(benchmarks);
            SaveSummary(summary);
        }

        private static BenchmarkRunInfo Validate<TBenchmark>(params object[] args)
        {
            var benchmarks = BenchmarkConverter.TypeToBenchmarks(typeof(TBenchmark));

            var methods = benchmarks.Benchmarks.Select(i => i.Target.Method).Distinct().ToList();

            var returnTypes = methods.Select(i => i.ReturnType).Distinct().ToList();
            if (returnTypes.Count == 0)
                throw new InvalidOperationException($"No benchmarks found in {benchmarks.Type}");
            if (returnTypes.Count > 1)
                throw new InvalidOperationException($"Benchmark methods have different return types in {benchmarks.Type}");

            var logger = ConsoleLogger.Default;

            var returnType = returnTypes.Single();
            if (returnType != typeof(void))
            {
                var instance = Activator.CreateInstance(benchmarks.Type);

                var results = methods
                    .Select(i => (method: i, value: i.Invoke(instance, args)))
                    .ToList();

                logger.WriteLine();
                logger.WriteLineHeader("Return values:");

                foreach (var (method, result) in results)
                    logger.WriteLineResult($"{method.Name}: {result}");

                logger.WriteLine();

                if (results.Any(i => !Equals(i.value, results[0].value)))
                    throw new InvalidOperationException($"Benchmark method return values are not equal in {benchmarks.Type}");
            }

            return benchmarks;
        }

        private static void SaveSummary(Summary summary)
        {
            var solutionDir = GetSolutionDirectory();
            if (solutionDir == null)
                return;

            var title = GetTitle(summary);
            if (title == null)
                return;

            var titleLine = $"## Summary: {title}";

            var filePath = Path.Combine(solutionDir, "README.md");

            var prefixLines = new List<string>();
            var suffixLines = new List<string>();

            if (File.Exists(filePath))
            {
                var allLines = File.ReadAllLines(filePath);

                var foundSummary = false;
                var inOldSummary = false;

                foreach (var line in allLines)
                {
                    if (!foundSummary)
                    {
                        if (line.StartsWith(titleLine))
                        {
                            foundSummary = true;
                            inOldSummary = true;
                            continue;
                        }

                        prefixLines.Add(line);
                        continue;
                    }

                    if (inOldSummary)
                    {
                        if (!line.StartsWith("#"))
                            continue;

                        inOldSummary = false;
                    }

                    suffixLines.Add(line);
                }
            }

            using (var fileWriter = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                var logger = new StreamLogger(fileWriter);

                foreach (var line in prefixLines)
                    logger.WriteLine(line);

                logger.WriteLineHeader(titleLine);
                logger.WriteLine();

                MarkdownExporter.GitHub.ExportToLog(summary, logger);
                logger.WriteLine();

                foreach (var line in suffixLines)
                    logger.WriteLine(line);
            }
        }

        private static string GetTitle(Summary summary)
        {
            var targetTypes = summary.Benchmarks.Select(i => i.Target.Type).Distinct().ToList();
            return targetTypes.Count == 1 ? targetTypes[0].Name : null;
        }

        private static string GetSolutionDirectory()
        {
            var dir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            while (!string.IsNullOrEmpty(dir))
            {
                if (Directory.EnumerateFiles(dir, "*.sln", SearchOption.TopDirectoryOnly).Any())
                    return dir;

                dir = Path.GetDirectoryName(dir);
            }

            return null;
        }
    }
}
