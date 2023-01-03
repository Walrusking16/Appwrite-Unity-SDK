namespace AppwriteSDK.Database
{
	/// <summary>
	///     Used to create a new document.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class DocumentRequest<T> : BaseDatabaseRequest<T>
	{
		public string documentId;
	}
}