using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppwriteSDK
{
	public class Client
	{
		private string _endpoint;
		private string _project;
		public Database.Database Database;
		private Dictionary<string, string> headers;

		public Client(string endpoint, string project)
		{
			Setup(endpoint, project);
		}

		public Client(string endpoint, string project, string key)
		{
			Setup(endpoint, project);
			headers.Add("x-appwrite-key", key);
		}

		public string Version => "0.0.1";

		public async Task<Request> CreateGetRequest(string path)
		{
			return await StartRequest(CreateRequest(path, Request.RequestMethod.GET));
		}

		public async Task<Request> CreatePatchRequest(string path, Dictionary<string, object> data)
		{
			return await StartRequest(CreateRequest(path, Request.RequestMethod.PATCH, data));
		}

		private async Task<Request> StartRequest(Request request)
		{
			request.Start();

			while (!request.IsDone) await Task.Yield();

			request.Dispose();

			return request;
		}

		private Request CreateRequest(string path, Request.RequestMethod method, Dictionary<string, object> data = null)
		{
			var request = new Request($"{_endpoint}/{path}", method, data);

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