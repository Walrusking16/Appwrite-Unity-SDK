using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace AppwriteSDK.Database
{
	/// <summary>
	///     Contains all the database methods
	/// </summary>
	public class Database
	{
		private Client _client;

		/// <summary>
		///     Creates an instance of the database
		/// </summary>
		/// <param name="client"></param>
		public Database(Client client)
		{
			_client = client;
		}

		private string BuildUrl(string databaseId, string collectionId)
		{
			return $"databases/{databaseId}/collections/{collectionId}/documents";
		}

		private string BuildUrl(string databaseId, string collectionId, string documentId)
		{
			return $"{BuildUrl(databaseId, collectionId)}/{documentId}";
		}

		/// <summary>
		///     Get a document by its unique ID
		/// </summary>
		/// <see href="https://appwrite.io/docs/client/databases?sdk=web-default#databasesGetDocument">Appwrite Documentation</see>
		/// <include file="../comments.xml" path="Appwrite/CommonParams/*" />
		/// <include file="../comments.xml" path="Appwrite/DocumentParam/*" />
		public async Task<DatabaseResponse<T>> GetDocument<T>(string databaseId, string collectionId, string documentId)
		{
			var request = await _client.CreateGetRequest(BuildUrl(databaseId, collectionId, documentId));

			return new DatabaseResponse<T>(request.GetText(), request.Result, request.Error);
		}

		/// <summary>
		///     Get a list of all the user's documents in a given collection. You can use the query params to filter your
		///     results
		/// </summary>
		/// <see href="https://appwrite.io/docs/client/databases?sdk=web-default#databasesListDocuments">Appwrite Documentation</see>
		/// <include file="../comments.xml" path="Appwrite/CommonParams/*" />
		// TODO: Support filters
		public async Task<DatabaseResponseList<T>> ListDocuments<T>(string databaseId, string collectionId)
		{
			var request = await _client.CreateGetRequest(BuildUrl(databaseId, collectionId));

			return new DatabaseResponseList<T>(request.GetText(), request.Result, request.Error);
		}

		/// <summary>
		///     Update a document by its unique ID. Using the patch method you can pass only specific fields that will get updated
		/// </summary>
		/// <see href="https://appwrite.io/docs/client/databases?sdk=web-default#databasesUpdateDocument">Appwrite Documentation</see>
		/// <include file="../comments.xml" path="Appwrite/CommonParams/*" />
		/// <include file="../comments.xml" path="Appwrite/DocumentParam/*" />
		// TODO: Support permissions
		public async Task<DatabaseResponse<T>> UpdateDocument<T>(string databaseId, string collectionId, string documentId,
			Dictionary<string, object> data)
		{
			var request = await _client.CreatePatchRequest(BuildUrl(databaseId, collectionId, documentId), data);

			return new DatabaseResponse<T>(request.GetText(), request.Result, request.Error);
		}

		/// <summary>
		///     Create a new Document
		/// </summary>
		/// <see href="https://appwrite.io/docs/client/databases?sdk=web-default#databasesCreateDocument">Appwrite Documentation</see>
		/// <include file="../comments.xml" path="Appwrite/CommonParams/*" />
		public async Task<DatabaseResponse<T>> CreateDocument<T>(string databaseId, string collectionId, string documentId,
			T data)
		{
			var jsonData = JsonUtility.ToJson(data);
			var request = await _client.CreatePostRequest(BuildUrl(databaseId, collectionId), Request.CreateObject(documentId, jsonData));

			return new DatabaseResponse<T>(request.GetText(), request.Result, request.Error);
		}

		public async Task<BaseResponse> DeleteDocument(string databaseId, string collectionId, string documentId)
		{
			var request = await _client.CreateDeleteRequest(BuildUrl(databaseId, collectionId, documentId));

			return new BaseResponse(request.GetText(), request.Result, request.Error);
		}

		public class DatabaseResponseList<T> : BaseResponse
		{
			public ListResponse<T> Data;

			public DatabaseResponseList(string data, UnityWebRequest.Result result, string error) : base(data, result, error)
			{
				Data = JsonUtility.FromJson<ListResponse<T>>(data);
			}
		}

		public class DatabaseResponse<T> : BaseResponse
		{
			public readonly T Data;

			public DatabaseResponse(string data, UnityWebRequest.Result result, string error) : base(data, result, error)
			{
				Data = JsonUtility.FromJson<T>(_data);
			}
		}

		[Serializable]
		public class ListResponse<T>
		{
			public List<T> documents;
			public int total;
		}

		public class BaseResponse
		{
			public readonly UnityWebRequest.Result Result;
			public readonly ResponseStatus Status;

			internal string _data;
			internal string _error;

			public BaseResponse(string data, UnityWebRequest.Result result, string error)
			{
				_data = data;
				Result = result;
				_error = error;
				Status = JsonUtility.FromJson<ResponseStatus>(_data);
			}

			public bool Success => Result == UnityWebRequest.Result.Success && string.IsNullOrEmpty(_error);
		}
	}
}