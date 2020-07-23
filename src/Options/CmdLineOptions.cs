using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;

namespace copylinkedlist.Options
{
    [Verb("duplist", HelpText = "Generate a random list and duplicate that list in memory")]
    public class CmdLineOptions
    {
        [Option('l', "length", Required = true, HelpText = "The length of the random singly linked list that will be generated")]
        public int Length { get; set; }
    }
}
