using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Appwrite.Example
{
	public class TodoExample : MonoBehaviour
	{
		[SerializeField] private UIDocument document;

		[SerializeField] private AppwriteSettings clientSettings;

		private async void Start()
		{
			var client = new Client(clientSettings.endpoint, clientSettings.projectID, clientSettings.key);

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

			root.Q<Label>("total").text = $"Total: {data.total}";

			if (data.total == 0) return;

			var elem = new VisualElement
			{
				style =
				{
					flexDirection = FlexDirection.Column,
					paddingBottom = 10
				}
			};

			foreach (var todo in data.documents)
			{
				var todoElem = new VisualElement
				{
					style =
					{
						flexDirection = FlexDirection.Row
					}
				};
				todoElem.Add(new Label
				{
					text = todo.title, style =
					{
						paddingRight = 5
					}
				});

				var toggle = new Toggle { value = todo.completed };

				toggle.RegisterValueChangedCallback(async evt =>
				{
					var form = new Dictionary<string, object> { { "completed", evt.newValue } };
					var res = await client.Database.UpdateDocument<Todo>("game", "items", todo._id, form);

					Debug.Log(res.Success ? res.Data.completed : res.Status.message);
				});

				todoElem.Add(toggle);
				elem.Add(todoElem);
			}

			root.Q<ScrollView>().Add(elem);
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