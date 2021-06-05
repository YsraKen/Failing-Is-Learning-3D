using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelLoad_Manager))]
public class LevelLoad_Manager_Editor : Editor
{
	public override void OnInspectorGUI(){
		DrawDefaultInspector();
		var llm = (LevelLoad_Manager) target;
		
		if(GUILayout.Button("Convert To String")){
			int length = llm.levelScenes.Length;
			llm.levelNames = new string[length];
			
			for(int i = 0; i < length; i++)
				llm.levelNames[i] = llm.levelScenes[i].name;
		}
	}
}