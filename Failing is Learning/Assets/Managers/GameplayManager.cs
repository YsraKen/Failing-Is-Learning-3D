using UnityEngine;
using UnityEngine.Events;

public class GameplayManager : MonoBehaviour
{
	public static GameplayManager instance{ get; private set; }
	void Awake(){ instance = this; }
	
	#region Events
	
		[System.Serializable]
		public class EventWrapper
		{
			// Delegates (scripting listeners assignment)
				public delegate void OnGameUpdateCallback();
				
				public OnGameUpdateCallback
					onGameFinished;
					
			// UnityEvents (Editor-inspector listeners assignment)
				public UnityEvent
					_onGameFinished = new UnityEvent();
				
			// Methods
				public void OnGameFinished(){
					onGameFinished?.Invoke();
					_onGameFinished?.Invoke();
				}
		}
		
		public EventWrapper events = new EventWrapper();
	
	#endregion
	
	#region On Game Start
	
		public GameObject[] startupToggleObjects;
		
		void Start(){
			Pause(true);
			ToggleObjects(false);
		}
		
			public void OnTapToStart_Button(){
				Pause(false);
				ToggleObjects(true);
			}
			
			void ToggleObjects(bool toggle){
				foreach(var t in startupToggleObjects)
					t.SetActive(toggle);
			}
	
	#endregion
	
	#region Pause
	
		public WindowUI pauseWindow;
	
		public void Pause(bool isPaused){
			if(isPaused) Time.timeScale = 0f;
			else Time.timeScale = 1f;
		}
		
		void Update(){
			if(Input.GetButtonDown("Cancel"))
				pauseWindow.Open();
		}
		
	#endregion
	
	public void FinishGame(){ // called from: Success Popup UI
		events.OnGameFinished();
	}
}