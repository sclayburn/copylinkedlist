using CommandLine;

namespace CopyLinkedList.Options
{
    /// <summary>
    /// Defines the valid commandline options that the CommandLineParser assembly will accept.
    /// </summary>
    [Verb("duplist", HelpText = "Generate a random list and duplicate that list in memory")]
    public class CmdLineOptions
    {
        [Option('l', "length", Required = true, HelpText = "The length of the random singly linked list that will be generated")]
        public int Length { get; set; }
    }
}
