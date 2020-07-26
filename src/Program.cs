using CommandLine;
using CopyLinkedList.Managers;
using CopyLinkedList.Options;
using CopyLinkedListShared;
using Serilog;
using System;
using System.Threading.Tasks;

namespace CopyLinkedList
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
                (CmdLineOptions opts) => ListManager.RunAndReturnExitCodeAsync(opts),
                errs => Task.FromResult(Consts.c_exitCodeFailure));

            Log.CloseAndFlush();

            Environment.Exit(exitCode);
        }

        private static void WriteCopyright()
        {
            string copyrightYear = Consts.c_copyrightYear.ToString();
            if (DateTime.Now.Year > Consts.c_copyrightYear)
            {
                copyrightYear += $"-{DateTime.Now.Year}";
            }
            Log.Information($"{Consts.c_copyrightFormat}{copyrightYear}");

        }
    }
}
