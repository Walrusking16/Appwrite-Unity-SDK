using System;
using AppwriteSDK.Database;
using UnityEngine;
using UnityEngine.UIElements;

namespace AppwriteSDK.Example
{
	public class TodoExample : MonoBehaviour
	{
		[SerializeField] private UIDocument document;

		[SerializeField] private AppwriteSettings clientSettings;

		private Client client;
		private ScrollView todoList;
		private int totalItems;
		private Label totalLabel;

		private async void Start()
		{
			client = new Client(clientSettings);

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
			todoList = root.Q<ScrollView>();

			// Create a new item when the button is clicked
			root.Q<Button>("new-item").clicked += async () =>
			{
				var newItem = new Todo
				{
					title = "New Item",
					completed = true
				};

				// Create the document on the server
				var res = await client.Database.CreateDocument("game", "items", ID.Unique, newItem);

				if (!res.Success)
				{
					Debug.LogError($"Appwrite: {res.Status.message}");
					Debug.Log($"Code: {res.Status.code}");
					Debug.Log($"Type: {res.Status.type}");
					Debug.Log($"Appwrite Version: {res.Status.version}");

					return;
				}

				newItem = res.Data;

				// Create the todo item in the UI and update the count
				CreateTodoItem(newItem);
				UpdateTotal(totalItems + 1);
			};

			UpdateTotal(data.total);

			if (data.total == 0) return;

			// Create all the items in the UI
			foreach (var todo in data.documents) CreateTodoItem(todo);
		}

		private void UpdateTotal(int total)
		{
			totalItems = total;
			totalLabel.text = $"Total: {total}";
		}

		private void CreateTodoItem(Todo todo)
		{
			var elem = new VisualElement { name = todo._id };
			elem.AddToClassList("todo-item");
			elem.EnableInClassList("active", todo.completed);

			elem.Add(new Label
			{
				text = todo.title
			});

			var toggle = new Toggle { value = todo.completed };

			toggle.RegisterValueChangedCallback(evt => OnToggleValueChanged(evt, todo));

			elem.Add(toggle);

			var deleteButton = new Button { text = "Delete" };
			deleteButton.clicked += () => OnDeleteButtonClicked(todo);
			elem.Add(deleteButton);

			todoList.Add(elem);
		}

		private async void OnToggleValueChanged(ChangeEvent<bool> evt, Todo todo)
		{
			document.rootVisualElement.Q<VisualElement>(todo._id).EnableInClassList("active", evt.newValue);

			// Update the todo item on the server
			var res = await client.Database.UpdateDocument<Todo>("game", "items", todo._id, new
			{
				completed = evt.newValue
			});

			Debug.Log(res.Success ? res.Data.completed : res.Status.message);
		}

		private async void OnDeleteButtonClicked(Todo todo)
		{
			// Delete the todo item on the server
			var res = await client.Database.DeleteDocument("game", "items", todo._id);

			if (!res.Success)
			{
				Debug.LogError($"Appwrite: {res.Status.message}");
				Debug.Log($"Code: {res.Status.code}");
				Debug.Log($"Type: {res.Status.type}");
				Debug.Log($"Appwrite Version: {res.Status.version}");

				return;
			}

			// Remove the todo item from the UI and update the count
			todoList.Q<VisualElement>(todo._id).RemoveFromHierarchy();
			UpdateTotal(totalItems - 1);
		}

		[Serializable]
		public class Todo : BaseDatabaseResponse
		{
			public bool completed;
			public string title;
		}
	}
}