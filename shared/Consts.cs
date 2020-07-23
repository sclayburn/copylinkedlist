using System;
using System.Collections.Generic;
using System.Text;

namespace copylinkedlistshared
{
	public static class Consts
	{
		public const string c_paramNameParent = "parent";
		public const string c_paramNameMaxDepth = "maxDepth";
		public const string c_paramNameListOne = "listOne";
		public const string c_paramNameListTwo = "listTwo";
		public const string c_paramNameOpts = "opts";
		public const string c_paramNameLength = "length";

		public const string c_argExceptionDescMaxDepth = "maxDepth must be greater than 0";
		public const string c_argExceptionDescLengthZero = "Length is required to be greater than zero";
		public const string c_argExceptionDescLengthLessThanTenMil = "Length is required to be less than 10000000";

		public const string c_RootTag = "Root";

		public const string c_ListOneLabel = "Original List";
		public const string c_ListTwoLabel = "Duplicate List";

		public const int c_ExitCodeSuccess = 0;
		public const int c_ExitCodeFailure = 1;

		public const int c_CopyrightYear = 2020;
		public const string c_CopyrightFormat = "copylinkedlist - Copyright © ";
	}
}
