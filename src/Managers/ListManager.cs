using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using copylinkedlist.Options;
using copylinkedlist.Validation;
using copylinkedlistshared;

namespace copylinkedlist.Managers
{
    public class ListManager
    {
        public static async Task<int> RunAndReturnExitCode(CmdLineOptions opts)
        {
            //Validate Input
            ValidateCmdLine val = new ValidateCmdLine();
            val.IsCmdLineValid(opts);
            
            await Task.Run(() => 
            {
                Node rootNode = Helpers.CreateRandomList(opts.Length);
                Node dupNode = Node.DuplicateList(rootNode);
                Helpers.PrintLists(rootNode, dupNode);
            });

            return Consts.c_ExitCodeSuccess;
        }
    }
}
