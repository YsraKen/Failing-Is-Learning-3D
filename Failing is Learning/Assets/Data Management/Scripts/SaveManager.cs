using System.IO;
using UnityEngine;

public static class SaveManager
{
	static string path{
		get{ return Application.persistentDataPath + "/"; }
	}
	
	const bool prettyPrint = true;
	
	public static void Save<T>(T data, string fileName){
		string newPath = path + fileName + ".json";
		string newJson = JsonUtility.ToJson(data, prettyPrint);
		
		File.WriteAllText(newPath, newJson);
	}
	
	public static T Load<T>(string fileName){
		string loadPath = path + fileName + ".json";
		
		if(File.Exists(loadPath)){
			string json = File.ReadAllText(loadPath);
			return JsonUtility.FromJson<T>(json);
		}
		else return default(T);
	}
}