using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using CopyLinkedList.Options;
using CopyLinkedList.Validation;
using CopyLinkedListShared;

namespace CopyLinkedList.Managers
{
    public class ListManager
    {
        /// <summary>
        /// Manager that will handle running the list cmdline options and return a status code to the caller.
        /// </summary>
        /// <param name="opts"><see cref="CmdLineOptions"/> object that contains the parsed command line args.</param>
        /// <returns>Error Code.  0 = Success, 1 = Failure.</returns>
        public static async Task<int> RunAndReturnExitCodeAsync(CmdLineOptions opts)
        {
            if (opts == null)
            {
                throw new ArgumentNullException(nameof(opts));
            }
            
            // Validate Input
            ValidateCmdLine val = new ValidateCmdLine();
            val.IsCmdLineValid(opts);
            
            await Task.Run(() => 
            {
                Node rootNode = Helpers.CreateRandomList(opts.Length);
                Node dupNode = Node.DuplicateList(rootNode);
                Helpers.PrintLists(rootNode, dupNode);
            });

            return Consts.c_exitCodeSuccess;
        }
    }
}
