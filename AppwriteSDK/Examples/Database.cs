using System;
using AppwriteSDK.Database;
using UnityEngine;

namespace AppwriteSDK.Examples
{
	public class Database : MonoBehaviour
	{
		[SerializeField] private AppwriteSettings appwriteSettings;

		private Client client;

		private void Awake()
		{
			client = new Client(appwriteSettings);
		}

		/// <summary>
		///     Create a new document with a random ID
		/// </summary>
		public async void CreateDocument()
		{
			var newItem = new Todo
			{
				title = "New Item",
				completed = true
			};

			var response = await client.Database.CreateDocument("databaseId", "collectionId", ID.Unique, newItem);

			// Returns the created document
			Debug.Log(response.Data.title);
		}

		/// <summary>
		///     Create a new document with a custom id
		/// </summary>
		public async void CreateDocumentWithCustomId()
		{
			var newItem = new Todo
			{
				title = "New Item",
				completed = true
			};

			var response = await client.Database.CreateDocument("databaseId", "collectionId", "customidhere", newItem);

			// Returns the created document
			Debug.Log(response.Data.title);
		}

		/// <summary>
		///     Get all todo items without filtering
		/// </summary>
		public async void ListDocuments()
		{
			var response = await client.Database.ListDocuments<Todo>("databaseId", "collectionId");

			if (response.Success)
				foreach (var todo in response.Data.documents)
					Debug.Log($"{todo.title} - {todo.completed}");
			else
				// Something went wrong
				Debug.LogError(response.Status.message);
		}

		/// <summary>
		///     Get only completed todo items. Requires Index to have been created in the Appwrite Console for "completed"
		///     attribute
		/// </summary>
		public async void ListDocumentsWithFilter()
		{
			var response = await client.Database.ListDocuments<Todo>("databaseId", "collectionId", new[]
			{
				Query.Equal("completed", true)
			});

			if (response.Success)
				foreach (var todo in response.Data.documents)
					Debug.Log($"{todo.title} - {todo.completed}");
			else
				// Something went wrong
				Debug.LogError(response.Status.message);
		}

		/// <summary>
		///     Returns a single document with the given ID
		/// </summary>
		public async void GetDocument()
		{
			var response = await client.Database.GetDocument<Todo>("databaseId", "collectionId", "documentId");

			Debug.Log(response.Data.title);
		}

		/// <summary>
		///     Update a document with the given ID, returns the updated document
		/// </summary>
		public async void UpdateDocument()
		{
			var response = await client.Database.UpdateDocument<Todo>("databaseId", "collectionId", "documentId", new
			{
				completed = false
			});

			Debug.Log(response.Data.title);
		}

		/// <summary>
		///     Delete a document with the given ID
		/// </summary>
		public async void DeleteDocument()
		{
			var response = await client.Database.DeleteDocument("databaseId", "collectionId", "documentId");

			// Document was deleted
			Debug.Log(response.Success);
		}


		/// <summary>
		///     Appwrite collection with two attributes: completed (bool) and title (string)
		/// </summary>
		[Serializable]
		public class Todo : BaseDatabaseResponse
		{
			public bool completed;
			public string title;
		}
	}
}