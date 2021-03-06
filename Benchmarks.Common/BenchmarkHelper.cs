﻿using System.Collections.Generic;
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
        public static void Run()
        {
            foreach (var summary in BenchmarkSwitcher.FromAssembly(Assembly.GetEntryAssembly()).Run())
                SaveSummary(summary);
        }

        private static void SaveSummary(Summary summary)
        {
            var solutionDir = GetSolutionDirectory();
            if (solutionDir == null)
                return;

            var title = GetTitle(summary);
            if (title == null)
                return;

            var titleLine = $"## {title}";

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
                        if (line == titleLine)
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
            var targetTypes = summary.BenchmarksCases.Select(i => i.Descriptor.Type).Distinct().ToList();
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
