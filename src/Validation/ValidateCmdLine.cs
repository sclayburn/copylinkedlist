using CopyLinkedList.Options;
using CopyLinkedListShared;
using System;

namespace CopyLinkedList.Validation
{
    public class ValidateCmdLine
    {
        /// <summary>
        /// Ensure that the command line options are valid and within bounds.
        /// </summary>
        /// <param name="opts"><see cref="CmdLineOptions"/> object that contains the parsed command line args.</param>
        public void IsCmdLineValid(CmdLineOptions opts)
        {
            if (opts == null)
            {
                throw new ArgumentNullException(nameof(opts));
            }

            IsLengthValid(opts.Length);
        }

        private void IsLengthValid(int length)
        {
            if (length < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(length), Consts.c_argExceptionDescLengthZero);
            }

            if (length > 10000000)
            {
                throw new ArgumentOutOfRangeException(nameof(length), Consts.c_argExceptionDescLengthLessThanTenMil);
            }
        }
    }
}
