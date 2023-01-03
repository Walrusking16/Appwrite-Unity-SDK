using System;
using System.Collections.Generic;

namespace AppwriteSDK.Database
{
	/// <summary>
	///     Contains data that all documents returned share
	/// </summary>
	[Serializable]
	public class BaseDatabaseResponse
	{
		public string _id, _collectionId, _databaseId, _createdAt, _updatedAt;
		public List<string> _permissions;

		public DateTime CreatedAt => ParseDate(_createdAt);
		public DateTime UpdatedAt => ParseDate(_updatedAt);

		private DateTime ParseDate(string date)
		{
			return string.IsNullOrWhiteSpace(date) ? DateTime.Now : DateTime.Parse(date);
		}
	}
}