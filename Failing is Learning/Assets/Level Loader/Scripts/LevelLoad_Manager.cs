using UnityEngine;

[CreateAssetMenu]
public class LevelLoad_Manager : ScriptableObject
{
	public Object[] levelScenes;
	public string[] levelNames;
	
	public string GetLevel(int index){ return levelNames[index]; }
}