namespace CopyLinkedListShared
{
    /// <summary>
    /// Allows for the centralization of all const char strings in the project.  
    /// This is a preference thing, but I like having all my const char strings in a 
    /// central place rather than scattered around at the top of each file.
    /// </summary>
    public static class Consts
    {
        public const string c_argExceptionDescMaxDepth = "maxDepth must be greater than 0";
        public const string c_argExceptionDescLengthZero = "Length is required to be greater than zero";
        public const string c_argExceptionDescLengthLessThanTenMil = "Length is required to be less than 10000000";

        public const string c_rootTag = "Root";

        public const string c_listOneLabel = "Original List";
        public const string c_listTwoLabel = "Duplicate List";

        public const int c_exitCodeSuccess = 0;
        public const int c_exitCodeFailure = 1;

        public const int c_copyrightYear = 2020;
        public const string c_copyrightFormat = "copylinkedlist - Copyright © ";
    }
}
