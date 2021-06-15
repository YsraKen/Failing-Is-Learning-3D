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
	
	UserData data{ get{ return mainMenu.currentData; }}
	
	void Start(){
		// load data
		
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
	}
	
	#region Scroll Repositioning
	
		public delegate void OnScrollRepositionUpdateCall();
		public OnScrollRepositionUpdateCall onScrollRepositioningDone; // target listener: LevelButton.Unlock()
		
		[Header("Scrolling")]
			public ScrollRect scrollRect;
			public float maxTime = 1f;
			
		IEnumerator RepositionScroll(){
			scrollRect.horizontalNormalizedPosition = 0f;
			
			float timer = 0f;
			
			int currentLevelIndex = data.currentLevelIndex;
			int numberOfFinished = - 1; // "-1" arrayOffset
				
				foreach(var b in buttons)
					if(b.activeSelf) numberOfFinished ++;
			
			float targetPosition = Mathf.InverseLerp(
				0,
				numberOfFinished,
				currentLevelIndex
			);
			
			// Debug.Log(numberOfFinished);
			// Debug.Log(currentLevelIndex);
			
			while(timer < maxTime){
				timer += Time.deltaTime;
				
				float lerp = timer / maxTime;
				float position = Mathf.Lerp(0, targetPosition, lerp);
				
				scrollRect.horizontalNormalizedPosition = position;
				
				yield return null;
			}
			
			onScrollRepositioningDone?.Invoke();
		}
	
	#endregion
	
	#region Cheat
	
		// input field ui
		public void ChangeHealthAmount(string health){
			data.livesRemaining = int.Parse(health);
		}
		
		public void SaveHealthAmount(){
			var userDataWrapper = new UserData_Wrapper(data);
			userDataWrapper.Save();
			
			lifeText.text = data.livesRemaining.ToString();
		}
	
	#endregion
}