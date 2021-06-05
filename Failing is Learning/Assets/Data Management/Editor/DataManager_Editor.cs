using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DataManager))]
public class DataManager_Editor : Editor
{
	public override void OnInspectorGUI(){
		DrawDefaultInspector();
		var dm = (DataManager) target;
		
		if(GUILayout.Button("Persistent Data Path"))
			Debug.Log(Application.persistentDataPath);
	}
}