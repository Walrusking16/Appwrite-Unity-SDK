using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Appwrite.Database
{
	public class Database
	{
		private Client _client;

		public Database(Client client)
		{
			_client = client;
		}

		public async Task<DatabaseResponse<T>> GetDocument<T>(string databaseId, string collectionId, string documentId)
		{
			var request = await _client.CreateGetRequest($"databases/{databaseId}/collections/{collectionId}/documents/{documentId}");

			return new DatabaseResponse<T>(request.GetText(), request.Result, request.Error);
		}

		public async Task<DatabaseResponseList<T>> ListDocuments<T>(string databaseId, string collectionId)
		{
			var request = await _client.CreateGetRequest($"databases/{databaseId}/collections/{collectionId}/documents");

			return new DatabaseResponseList<T>(request.GetText(), request.Result, request.Error);
		}

		public async Task<DatabaseResponse<T>> UpdateDocument<T>(string databaseId, string collectionId, string documentId,
			Dictionary<string, object> data)
		{
			var request = await _client.CreatePatchRequest($"databases/{databaseId}/collections/{collectionId}/documents/{documentId}",
				data);

			return new DatabaseResponse<T>(request.GetText(), request.Result, request.Error);
		}

		public class DatabaseResponseList<T> : BaseResponse<T>
		{
			public ListResponse<T> Data;

			public DatabaseResponseList(string data, UnityWebRequest.Result result, string error) : base(data, result, error)
			{
				Data = JsonUtility.FromJson<ListResponse<T>>(data);
			}
		}

		public class DatabaseResponse<T> : BaseResponse<T>
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

		public class BaseResponse<T>
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