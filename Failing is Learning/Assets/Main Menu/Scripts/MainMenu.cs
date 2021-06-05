using UnityEngine;

public class MainMenu : MonoBehaviour
{
	public GameObject[] resumeObjects;
	
	DataManager dataMgr;
	public UserData currentData{ get; private set; }
	
	void Start(){
		dataMgr = DataManager.instance;
		currentData = dataMgr.currentData;
		
		hasLoadedData = currentData != null;
		
		foreach(var rO in resumeObjects)
			rO.SetActive(hasLoadedData);
	}
	
	#region New Game
	
		public WindowUI dataOverwriteWarning_Popup;
		
		bool hasLoadedData;
		
		public void OnNewGame_Button(){
			// check for existing data
			// warn for data overwriting
				if(hasLoadedData)
					dataOverwriteWarning_Popup.Open();
				
			// Create new data
				else OnNewGame_Confirm();
				
			// Load Level
		}
		
		public void OnNewGame_Confirm(){ // also called from dataOverwriteWarning_Popup "overwrite confirmation" butotn
			dataMgr.CreateNew();
			
			// load level
				LevelLoader.instance.GoToLevel();
		}
		
	#endregion
	
	public void OnRseume_Button(){
		int levelIndex = currentData.currentLevelIndex;
		LevelLoader.instance.Load(levelIndex);
	}
}