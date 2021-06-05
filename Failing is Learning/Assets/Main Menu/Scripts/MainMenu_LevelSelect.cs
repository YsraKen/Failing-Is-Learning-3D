using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MainMenu_LevelSelect : MonoBehaviour
{
	public MainMenu_LevelButton[] buttons;
	public MainMenu mainMenu;
	
	// UI
	public Text lifeText;
	public ScrollRect scrollRect;
	
	void Start(){
		// load data
			var data = mainMenu.currentData;
		
		// collect all finished levels
			var levels = new List<LevelData>();
			
			foreach(var level in data.levels)
				if(level.isFinished)
					levels.Add(level);
			
			// these are just finished level, we still need to access the new level unlocked
			
		// make a button for levels
			for(int i = 0; i < levels.Count; i++){
				buttons[i].SetActive(true);
				
				buttons[i].levelIndex = i;
				buttons[i].deathCount = levels[i].numberOfDeaths;
				buttons[i].timeLength = levels[i].time;
			}
			
		// Unlock a new level to make it playable
			int newLevel_index = levels.Count; // already incremented (arrayOffset)
			
			if(newLevel_index <= UserData.maxLevelIndex){
				// cache
					var newLevelButton = buttons[newLevel_index];
				
				// setup
					newLevelButton.SetActive(true);
					newLevelButton.levelIndex = newLevel_index;
				
				// unlock
					newLevelButton.Lock(); // effect, just to show the lock button first then finally unlock it after updating the scrollRect ui (to show it's clearly unlocking)
					onScrollRepositioningDone = newLevelButton.Unlock;
			}
			
		// Some other UI Update
			lifeText.text = data.livesRemaining.ToString();
			StartCoroutine(RepositionScroll());
			
/* 		//
			currentIndex = data.currentLevelIndex;
			currentIndex = Mathf.Clamp(currentIndex, 0, UserData.maxLevelIndex);
				
			int arrayOffset = 1;
		
		for(int i = 0; i < currentIndex + arrayOffset; i++){
			buttons[i].gameObject.SetActive(true);
			
			buttons[i].levelIndex = i;
			buttons[i].deathCount = data.levels[i].numberOfDeaths;
			buttons[i].timeLength = data.levels[i].time;
		}
		
		// Design (UI)
			bool isCurrentLevelFinished = data.levels[currentIndex].isFinished; // these will avoid the unlocking effect (animation) on finished level (specially the very last level)
			buttons[currentIndex].Lock(isCurrentLevelFinished);
			
			lifeText.text = data.livesRemaining.ToString();
			
			StartCoroutine(RepositionScroll()); */
	}
	
	#region Scroll Repositioning
	
		public delegate void OnScrollRepositionUpdateCall();
		public OnScrollRepositionUpdateCall onScrollRepositioningDone; // target listener: LevelButton.Unlock()
		
		IEnumerator RepositionScroll(){
			scrollRect.horizontalNormalizedPosition = 0f;
			
			float timer = 0f;
			float maxTime = 1f;
			
			while(timer < maxTime){
				timer += Time.deltaTime;
				
				// float lerp = Mathf.InverseLerp(0, maxTime, timer);
				float lerp = timer / maxTime;
				scrollRect.horizontalNormalizedPosition = lerp;
				
				yield return null;
			}
			
			onScrollRepositioningDone?.Invoke();
		}
	
	#endregion
	
	#region Cheat
	
		// input field ui
		public void ChangeHealthAmount(string health){
			var data = mainMenu.currentData;
				data.livesRemaining = int.Parse(health);
		}
		
		public void SaveHealthAmount(){
			var data = mainMenu.currentData;
			
			var userDataWrapper = new UserData_Wrapper(data);
			userDataWrapper.Save();
			
			lifeText.text = data.livesRemaining.ToString();
		}
	
	#endregion
}