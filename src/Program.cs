using System;
using System.Threading.Tasks;
using CommandLine;
using Serilog;
using copylinkedlistshared;
using copylinkedlist.Options;
using copylinkedlist.Managers;

namespace copylinkedlist
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            WriteCopyright();

            int exitCode = await Parser.Default.ParseArguments<CmdLineOptions, object>(args)
            .MapResult(
                (CmdLineOptions opts) => ListManager.RunAndReturnExitCode(opts),
                errs => Task.FromResult(Consts.c_ExitCodeFailure));

            Log.CloseAndFlush();

            Environment.Exit(exitCode);
        }

        private static void WriteCopyright()
        {
            string copyrightYear = "2020";
            if (DateTime.Now.Year > 2020)
            {
                copyrightYear += $"-{DateTime.Now.Year}";
            }
            Log.Information($"copylinkedlist - Copyright © {copyrightYear}");

        }
    }
}
