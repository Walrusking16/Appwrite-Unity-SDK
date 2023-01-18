namespace AppwriteSDK
{
	public enum Status
	{
		None,
		Verified,
		Unverified
	}

	public static class Role
	{
		public static string Any()
		{
			return "any";
		}

		public static string Guests()
		{
			return "guests";
		}

		public static string User(string id, Status status = Status.None)
		{
			return AppendStatus($"user:{id}", status);
		}

		public static string Users(Status status = Status.None)
		{
			return AppendStatus("users", status);
		}

		public static string Team(string id, Status status = Status.None)
		{
			return AppendStatus($"team:{id}", status);
		}

		public static string Member(string id)
		{
			return $"member:{id}";
		}

		private static string AppendStatus(string role, Status status)
		{
			return status != Status.None ? $"{role}/{StatusToString(status)}" : role;
		}

		private static string StatusToString(Status status)
		{
			return status switch
			{
				Status.Verified => "verified",
				Status.Unverified => "unverified",
				_ => "unknown"
			};
		}
	}
}