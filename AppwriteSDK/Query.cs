using System.Collections.Generic;

namespace AppwriteSDK
{
	public static class Query
	{
		public static string OrderDesc(string attribute)
		{
			return $"orderDesc(\"{attribute}\")";
		}

		public static string OrderAsc(string attribute)
		{
			return $"orderAsc(\"{attribute}\")";
		}

		public static string Limit(int limit)
		{
			return $"limit({limit})";
		}

		public static string Offset(int offset)
		{
			return $"offset({offset})";
		}

		public static string CursorAfter(string documentId)
		{
			return $"cursorAfter(\"{documentId}\")";
		}

		public static string CursorBefore(string documentId)
		{
			return $"cursorBefore(\"{documentId}\")";
		}

		public static string Equal(string attribute, string value)
		{
			return AddQuery(attribute, "equal", value);
		}

		public static string Equal(string attribute, int value)
		{
			return AddQuery(attribute, "equal", value);
		}

		public static string Equal(string attribute, bool value)
		{
			return AddQuery(attribute, "equal", value);
		}

		public static string Equal(string attribute, IEnumerable<string> value)
		{
			return AddQuery(attribute, "equal", value);
		}

		public static string Equal(string attribute, IEnumerable<int> value)
		{
			return AddQuery(attribute, "equal", value);
		}

		public static string Equal(string attribute, IEnumerable<bool> value)
		{
			return AddQuery(attribute, "equal", value);
		}

		public static string NotEqual(string attribute, string value)
		{
			return AddQuery(attribute, "notEqual", value);
		}

		public static string NotEqual(string attribute, int value)
		{
			return AddQuery(attribute, "notEqual", value);
		}

		public static string NotEqual(string attribute, bool value)
		{
			return AddQuery(attribute, "notEqual", value);
		}

		public static string NotEqual(string attribute, IEnumerable<string> value)
		{
			return AddQuery(attribute, "notEqual", value);
		}

		public static string NotEqual(string attribute, IEnumerable<int> value)
		{
			return AddQuery(attribute, "notEqual", value);
		}

		public static string NotEqual(string attribute, IEnumerable<bool> value)
		{
			return AddQuery(attribute, "notEqual", value);
		}

		public static string Search(string attribute, string value)
		{
			return AddQuery(attribute, "search", value);
		}

		public static string Search(string attribute, int value)
		{
			return AddQuery(attribute, "search", value);
		}

		public static string Search(string attribute, bool value)
		{
			return AddQuery(attribute, "search", value);
		}

		public static string Search(string attribute, IEnumerable<string> value)
		{
			return AddQuery(attribute, "search", value);
		}

		public static string Search(string attribute, IEnumerable<int> value)
		{
			return AddQuery(attribute, "search", value);
		}

		public static string Search(string attribute, IEnumerable<bool> value)
		{
			return AddQuery(attribute, "search", value);
		}

		public static string LessThan(string attribute, string value)
		{
			return AddQuery(attribute, "lessThan", value);
		}

		public static string LessThan(string attribute, int value)
		{
			return AddQuery(attribute, "lessThan", value);
		}

		public static string LessThan(string attribute, bool value)
		{
			return AddQuery(attribute, "lessThan", value);
		}

		public static string LessThan(string attribute, IEnumerable<string> value)
		{
			return AddQuery(attribute, "lessThan", value);
		}

		public static string LessThan(string attribute, IEnumerable<int> value)
		{
			return AddQuery(attribute, "lessThan", value);
		}

		public static string LessThan(string attribute, IEnumerable<bool> value)
		{
			return AddQuery(attribute, "lessThan", value);
		}

		public static string LessThanEqual(string attribute, string value)
		{
			return AddQuery(attribute, "lessThanEqual", value);
		}

		public static string LessThanEqual(string attribute, int value)
		{
			return AddQuery(attribute, "lessThanEqual", value);
		}

		public static string LessThanEqual(string attribute, bool value)
		{
			return AddQuery(attribute, "lessThanEqual", value);
		}

		public static string LessThanEqual(string attribute, IEnumerable<string> value)
		{
			return AddQuery(attribute, "lessThanEqual", value);
		}

		public static string LessThanEqual(string attribute, IEnumerable<int> value)
		{
			return AddQuery(attribute, "lessThanEqual", value);
		}

		public static string LessThanEqual(string attribute, IEnumerable<bool> value)
		{
			return AddQuery(attribute, "lessThanEqual", value);
		}

		public static string GreaterThan(string attribute, string value)
		{
			return AddQuery(attribute, "greaterThan", value);
		}

		public static string GreaterThan(string attribute, int value)
		{
			return AddQuery(attribute, "greaterThan", value);
		}

		public static string GreaterThan(string attribute, bool value)
		{
			return AddQuery(attribute, "greaterThan", value);
		}

		public static string GreaterThan(string attribute, IEnumerable<string> value)
		{
			return AddQuery(attribute, "greaterThan", value);
		}

		public static string GreaterThan(string attribute, IEnumerable<int> value)
		{
			return AddQuery(attribute, "greaterThan", value);
		}

		public static string GreaterThan(string attribute, IEnumerable<bool> value)
		{
			return AddQuery(attribute, "greaterThan", value);
		}

		public static string GreaterThanEqual(string attribute, string value)
		{
			return AddQuery(attribute, "greaterThanEqual", value);
		}

		public static string GreaterThanEqual(string attribute, int value)
		{
			return AddQuery(attribute, "greaterThanEqual", value);
		}

		public static string GreaterThanEqual(string attribute, bool value)
		{
			return AddQuery(attribute, "greaterThanEqual", value);
		}

		public static string GreaterThanEqual(string attribute, IEnumerable<string> value)
		{
			return AddQuery(attribute, "greaterThanEqual", value);
		}

		public static string GreaterThanEqual(string attribute, IEnumerable<int> value)
		{
			return AddQuery(attribute, "greaterThanEqual", value);
		}

		public static string GreaterThanEqual(string attribute, IEnumerable<bool> value)
		{
			return AddQuery(attribute, "greaterThanEqual", value);
		}

		private static string AddQuery(string attribute, string method, string value)
		{
			return $"{method}(\"{attribute}\", [{ParseValues(value)}])";
		}

		private static string AddQuery(string attribute, string method, int value)
		{
			return $"{method}(\"{attribute}\", [{ParseValues(value)}])";
		}

		private static string AddQuery(string attribute, string method, bool value)
		{
			return $"{method}(\"{attribute}\", [{ParseValues(value)}])";
		}

		private static string AddQuery(string attribute, string method, IEnumerable<string> values)
		{
			return $"{method}(\"{attribute}\", [{ParseValues(values)}])";
		}

		private static string AddQuery(string attribute, string method, IEnumerable<int> values)
		{
			return $"{method}(\"{attribute}\", [{ParseValues(values)}])";
		}

		private static string AddQuery(string attribute, string method, IEnumerable<bool> values)
		{
			return $"{method}(\"{attribute}\", [{ParseValues(values)}])";
		}

		private static string ParseValues(string value)
		{
			return $"\"{value}\"";
		}

		private static string ParseValues(int value)
		{
			return value.ToString();
		}

		private static string ParseValues(bool value)
		{
			return value.ToString().ToLower();
		}

		private static string ParseValues(IEnumerable<string> value)
		{
			return string.Join(",", value);
		}

		private static string ParseValues(IEnumerable<int> value)
		{
			return string.Join(",", value);
		}

		private static string ParseValues(IEnumerable<bool> value)
		{
			return string.Join(",", value);
		}
	}
}