using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Island))]
public class Island_Editor : Editor
{
	public override void OnInspectorGUI(){
		DrawDefaultInspector();
		var il = (Island) target;
		
		if(GUILayout.Button("Get Vertices")){
			il.myVertices = il.myMesh.vertices;
		}
	}
}