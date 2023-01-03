using System;
using System.Collections.Generic;

namespace AppwriteSDK.Database
{
	[Serializable]
	public class BaseDatabaseRequest<T>
	{
		public T data;
		public List<string> permissions;
	}
}