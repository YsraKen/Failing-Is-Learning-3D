using UnityEngine;

[System.Serializable]
public class LevelData
{
	public bool isFinished;
	
	public int numberOfDeaths; // on replay, keep the number
	public float time;
	
	const string fileName = "LevelData";
	
	public static LevelData Load(int levelIndex){
		string dataFileName = fileName + levelIndex;
		var data = SaveManager.Load<LevelData>(dataFileName);
		
		if(data == null)
			data = new LevelData();
		
		return data;
	}
	
	public void Save(int levelIndex){
		string dataFileName = fileName + levelIndex;
		SaveManager.Save(this, dataFileName);
	}
}