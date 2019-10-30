﻿using System;

namespace Generator
{
    public static class Program
    {
        private const string DefaultDownloadBranch = "1.2";

        private static void Main(string[] args)
        {
            var redownloadCoreSpecification = false;
            var downloadBranch = DefaultDownloadBranch;

            var answer = "invalid";
            while (answer != "y" && answer != "n" && answer != "")
            {
                Console.Write("Download online specifications? [Y/N] (default N): ");
                answer = Console.ReadLine()?.Trim().ToLowerInvariant();
                redownloadCoreSpecification = answer == "y";
            }

            Console.Write($"Branch to use (default {downloadBranch}): ");
            var readBranch = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(readBranch)) downloadBranch = readBranch;

            if (string.IsNullOrEmpty(downloadBranch))
                downloadBranch = DefaultDownloadBranch;

            if (redownloadCoreSpecification)
                SpecificationDownloader.Download(downloadBranch);

            FileGenerator.Generate(downloadBranch);
        }
    }
}