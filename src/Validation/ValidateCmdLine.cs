using copylinkedlist.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace copylinkedlist.Validation
{
    public class ValidateCmdLine
    {
        public void IsCmdLineValid(CmdLineOptions opts)
        {
            IsLengthValid(opts.Length);
        }

        private void IsLengthValid(int length)
        {
            if (length < 1)
            {
                throw new ArgumentException("Length is required to be greater than zero");
            }

            if (length > 1024)
            {
                throw new ArgumentException("Length is required to be less than 1024");
            }
        }
    }
}
