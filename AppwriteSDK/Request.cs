using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace AppwriteSDK
{
	public class ResponseStatus
	{
		/// <summary>
		///     Response code
		/// </summary>
		/// <see href="https://appwrite.io/docs/response-codes">Appwrite Documentation</see>
		public int code;

		/// <summary>
		///     Error message
		/// </summary>
		public string message;

		/// <summary>
		///     ErrorType
		/// </summary>
		/// <see href="https://appwrite.io/docs/response-codes#errorTypes">Appwrite Documentation</see>
		public string type;

		/// <summary>
		///     Appwrite Version
		/// </summary>
		public string version;

		/// <summary>
		///     Converts the "type" to an enum
		/// </summary>
		/// <see cref="AppwriteSDK.ResponseStatus.type" />
		public ErrorType ErrorType => GetErrorType();

		private ErrorType GetErrorType()
		{
			var errorType = type.Replace("_", "");

			return (ErrorType)Enum.Parse(typeof(ErrorType), errorType);
		}
	}

	public class Request
	{
		/// <summary>
		///     HTTP Method
		/// </summary>
		public enum RequestMethod
		{
			GET,
			POST,
			PUT,
			DELETE,
			CREATE,
			PATCH
		}

		private static readonly string[] AppwriteKeys =
		{
			"$id",
			"$createdAt",
			"$updatedAt",
			"$permissions",
			"$collectionId",
			"$databaseId"
		};

		public string Error;

		public string ResponseText;
		public UnityWebRequest.Result Result;

		private UnityWebRequest webRequest;

		public Request(string url, RequestMethod method, Dictionary<string, object> data = null)
		{
			webRequest = new UnityWebRequest(url, GetMethod(method));
			webRequest.timeout = 60;
			if (data != null)
			{
				Debug.Log(FormToJson(data));
				var encodedPayload = new UTF8Encoding().GetBytes(FormToJson(data));
				webRequest.uploadHandler = new UploadHandlerRaw(encodedPayload);
			}

			webRequest.downloadHandler = new DownloadHandlerBuffer();
		}

		public bool IsDone => webRequest.isDone;

		public void Dispose()
		{
			Error = webRequest.error;
			Result = webRequest.result;
			ResponseText = webRequest.downloadHandler.text;

			webRequest.Dispose();
		}

		private string FormToJson(Dictionary<string, object> data)
		{
			var json = "{ \"data\": {";

			var num = 0;
			foreach (var kv in data)
			{
				json += $"\"{kv.Key}\": {ParseValue(kv.Value)}";

				if (data.Count - 1 < num) json += ",";
				else json += "}";

				num++;
			}

			return $"{json}}}";
		}

		private string ParseValue(object value)
		{
			return value switch
			{
				string => $"\"{value}\"",
				bool => value.ToString().ToLower(),
				_ => value.ToString()
			};
		}

		public void SetHeader(string key, string value)
		{
			webRequest.SetRequestHeader(key, value);
		}

		public UnityWebRequestAsyncOperation Start()
		{
			return webRequest.SendWebRequest();
		}

		public string GetText()
		{
			return ParseJson(ResponseText);
		}

		private string ParseJson(string json)
		{
			return AppwriteKeys.Aggregate(json, (current, key) => current.Replace(key, key.Replace('$', '_')));
		}

		private string GetMethod(RequestMethod method)
		{
			return method switch
			{
				RequestMethod.GET => UnityWebRequest.kHttpVerbGET,
				RequestMethod.POST => UnityWebRequest.kHttpVerbPOST,
				RequestMethod.PUT => UnityWebRequest.kHttpVerbPUT,
				RequestMethod.DELETE => UnityWebRequest.kHttpVerbDELETE,
				RequestMethod.CREATE => UnityWebRequest.kHttpVerbCREATE,
				RequestMethod.PATCH => "PATCH",
				_ => UnityWebRequest.kHttpVerbGET
			};
		}
	}
}