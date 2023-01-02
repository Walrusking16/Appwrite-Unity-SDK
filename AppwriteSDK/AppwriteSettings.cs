using UnityEngine;

namespace AppwriteSDK
{
	[CreateAssetMenu(fileName = "AppwriteSettings", menuName = "Appwrite/Settings", order = 1)]
	public class AppwriteSettings : ScriptableObject
	{
		public string endpoint = "http://localhost/v1";
		public string projectID = "";
		public string key = "";
	}
}