using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppwriteSDK
{
	public class Client
	{
		private string _endpoint;
		private string _project;

		public Database.Database Database;

		private Dictionary<string, string> headers;

		/// <summary>
		///     Create an instance of the client
		/// </summary>
		/// <include file="./comments.xml" path='Appwrite/CommonClientParams/*' />
		public Client(string endpoint, string projectId)
		{
			Setup(endpoint, projectId);
		}

		/// <summary>
		///     Create an instance of the client
		/// </summary>
		public Client(AppwriteSettings settings)
		{
			Setup(settings.endpoint, settings.projectID);

			if (!string.IsNullOrEmpty(settings.key))
				AddKey(settings.key);
		}

		/// <summary>
		///     Create an instance of the client that has an api key
		/// </summary>
		/// <include file="./comments.xml" path='Appwrite/CommonClientParams/*' />
		/// <param name="apiKey">The api key to access the endpoint</param>
		public Client(string endpoint, string projectId, string apiKey)
		{
			Setup(endpoint, projectId);
			AddKey(apiKey);
		}

		/// <summary>
		///     Current version of the SDK
		/// </summary>
		public string Version => "0.1.0";

		/// <summary>
		///     Creates a standard GET request
		/// </summary>
		/// <param name="path"></param>
		/// <param name="queries"></param>
		/// <returns></returns>
		public async Task<Request> CreateGetRequest(string path, string[] queries = null)
		{
			return await StartRequest(CreateRequest(path, Request.RequestMethod.GET, "", queries));
		}

		/// <summary>
		///     Creates a standard PATCH request
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public async Task<Request> CreatePatchRequest(string path, Dictionary<string, object> data)
		{
			return await StartRequest(CreateRequest(path, Request.RequestMethod.PATCH, data));
		}

		/// <summary>
		///     Creates a standard POST request
		/// </summary>
		/// <param name="path"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		public async Task<Request> CreatePostRequest(string path, Dictionary<string, object> data)
		{
			return await StartRequest(CreateRequest(path, Request.RequestMethod.POST, data));
		}

		/// <inheritdoc cref="AppwriteSDK.Client.CreatePostRequest(string, Dictionary{string, object})" />
		public async Task<Request> CreatePostRequest(string path, string data)
		{
			return await StartRequest(CreateRequest(path, Request.RequestMethod.POST, data));
		}

		public async Task<Request> CreateDeleteRequest(string path)
		{
			return await StartRequest(CreateRequest(path, Request.RequestMethod.DELETE));
		}

		private void AddKey(string key)
		{
			headers.Add("x-appwrite-key", key);
		}

		private async Task<Request> StartRequest(Request request)
		{
			request.Start();

			while (!request.IsDone) await Task.Yield();

			request.Dispose();

			return request;
		}

		//TODO: Settings that include built in logging that has options for disabled, error, info
		private Request CreateRequest(string path, Request.RequestMethod method, Dictionary<string, object> data, string[] queries = null)
		{
			return CreateRequest(path, method, Request.FormToJson(data), queries);
		}

		private Request CreateRequest(string path, Request.RequestMethod method, string data = null, string[] queries = null)
		{
			var url = $"{_endpoint}/{path}";

			if (queries != null)
			{
				url += "?";
				for (var i = 0; i < queries.Length; i++)
				{
					url += $"queries[{i}]={queries[i]}";
					if (i != queries.Length - 1)
						url += "&";
				}
			}

			var request = string.IsNullOrEmpty(data)
				? new Request(url, method)
				: new Request(url, method, new UTF8Encoding().GetBytes(data));

			foreach (var header in headers) request.SetHeader(header.Key, header.Value);

			return request;
		}

		private void Setup(string endpoint, string project)
		{
			_endpoint = endpoint;
			_project = project;
			Database = new Database.Database(this);

			headers = new Dictionary<string, string>
			{
				{ "x-sdk-version", $"appwrite:unity:{Version}" },
				{ "content-type", "application/json" },
				{ "x-appwrite-project", _project }
			};
		}
	}
}