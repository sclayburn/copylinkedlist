using copylinkedlist.Options;
using copylinkedlistshared;
using System;
using System.Collections.Generic;
using System.Text;

namespace copylinkedlist.Validation
{
    public class ValidateCmdLine
    {
        /// <summary>
        /// Ensure that the command line options are valid and within bounds
        /// </summary>
        /// <param name="opts">CmdLineOptions object that contains the parsed command line args</param>
        public void IsCmdLineValid(CmdLineOptions opts)
        {
            if (opts == null)
            {
                throw new ArgumentNullException(Consts.c_paramNameOpts);
            }

            IsLengthValid(opts.Length);
        }

        private void IsLengthValid(int length)
        {
            if (length < 1)
            {
                throw new ArgumentOutOfRangeException(Consts.c_paramNameLength, Consts.c_argExceptionDescLengthZero);
            }

            if (length > 10000000)
            {
                throw new ArgumentOutOfRangeException(Consts.c_paramNameLength, Consts.c_argExceptionDescLengthLessThanTenMil);
            }
        }
    }
}
