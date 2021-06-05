using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
	public static LevelManager instance{ get; private set; }
	void Awake(){ instance = this; }

	public int levelId; // for data management, this will be used to target the data to modified for the current level
	LevelData levelData; // loaded level data
		
		// Data Update from other Scripts
			public int numberOfDeaths{ // LevelGoals
				get{ return levelData.numberOfDeaths; }
				set{ levelData.numberOfDeaths = value; }
			}
			
			public float timer{ // LevelGoals
				get{ return levelData.time; }
				set{ levelData.time = value; }
			}
	
	void Start(){
		var userData = DataManager.instance.currentData;
			userData.currentLevelIndex = levelId;
			
		levelData = LevelData.Load(levelId);
	}
	
	#region Events
	
		[System.Serializable]
		public class EventWrapper{
			public UnityEvent
				onLevelSuccess = new UnityEvent(); // target listener: UI Popup
				
			public void OnLevelSuccess(){ onLevelSuccess?.Invoke(); }
		}
		
		public EventWrapper events = new EventWrapper();
	
	#endregion
	
	public void Success(){
		// Debug.Log("Level Success!!!");
		
		// Popup window
		events.OnLevelSuccess();
	}
	
	public void OnLevelFinished(){
		// Update data
		levelData.isFinished = true;
		
		var userData = DataManager.instance.currentData;
			userData.currentLevelIndex ++;
			userData.currentLevelIndex = Mathf.Clamp(userData.currentLevelIndex, 0, userData.levels.Length);
			
			var userDataWrapper = new UserData_Wrapper(userData); // this will prevent us saving all levelData at once
			
		// Save Data
		levelData.Save(levelId);
		userDataWrapper.Save();
	}
}