using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace AppwriteSDK.Example
{
	public class TodoExample : MonoBehaviour
	{
		[SerializeField] private UIDocument document;

		[SerializeField] private AppwriteSettings clientSettings;

		private Client client;
		private Label totalLabel;

		private async void Start()
		{
			client = new Client(clientSettings.endpoint, clientSettings.projectID, clientSettings.key);

			// Get all todo items
			var response = await client.Database.ListDocuments<Todo>("game", "items");

			if (!response.Success)
			{
				Debug.LogError($"Appwrite: {response.Status.message}");
				Debug.Log($"Code: {response.Status.code}");
				Debug.Log($"Type: {response.Status.type}");
				Debug.Log($"Appwrite Version: {response.Status.version}");

				return;
			}

			var data = response.Data;

			var root = document.rootVisualElement;

			totalLabel = root.Q<Label>("total");

			UpdateTotal(data.total);

			if (data.total == 0) return;

			var todoItem = new VisualElement();

			foreach (var todo in data.documents)
			{
				CreateTodoItem(todo, out var elem);
				todoItem.Add(elem);
			}

			root.Q<ScrollView>().Add(todoItem);
		}

		private void UpdateTotal(int total)
		{
			totalLabel.text = $"Total: {total}";
		}

		private void CreateTodoItem(Todo todo, out VisualElement elem)
		{
			elem = new VisualElement();
			elem.AddToClassList("todo-item");

			elem.Add(new Label
			{
				text = todo.title
			});

			var toggle = new Toggle { value = todo.completed };

			toggle.RegisterValueChangedCallback(evt => OnToggleValueChanged(evt, todo));

			elem.Add(toggle);
		}

		private async void OnToggleValueChanged(ChangeEvent<bool> evt, Todo todo)
		{
			var form = new Dictionary<string, object> { { "completed", evt.newValue } };
			var res = await client.Database.UpdateDocument<Todo>("game", "items", todo._id, form);

			Debug.Log(res.Success ? res.Data.completed : res.Status.message);
		}

		[Serializable]
		public class Todo : BaseDatabaseResponse
		{
			public bool completed;
			public string title;
		}

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

		[Serializable]
		public class BaseDatabaseRequest<T>
		{
			public List<string> permissions;
			public T data;
		}
	}
}