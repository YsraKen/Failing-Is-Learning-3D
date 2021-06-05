using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelGoals : MonoBehaviour
{
	public Text timerText, deathsText;
	
	public float timer{ get; private set; }
	public int deaths{ get; private set; }
	
	// Event Listeners
		public void OnLevelStart(){
			StartTimer();
		}
		
		public void OnLevelFinished(){
			var lvlMgr = LevelManager.instance;
			
				lvlMgr.numberOfDeaths += deaths;
				lvlMgr.timer += timer;
		}

		public void OnDeath(){ // On Damaged
			deaths ++;
			deathsText.text = deaths.ToString();
			
			// design
			if(!deathsText.gameObject.activeSelf)
				deathsText.gameObject.SetActive(true);
		}
	
	#region Timer
	
		void StartTimer(){ // ui button
			timerRoutine = NewTimerRoutine();
			StartCoroutine(timerRoutine);
		}
		
		void StopTimer(){
			StopCoroutine(timerRoutine);
		}
		
		IEnumerator timerRoutine;
		
		IEnumerator NewTimerRoutine(){
			while(true){
				timer += Time.deltaTime;
				yield return null;
			}
		}
	
	#endregion
	
	void LateUpdate(){
		// ui
			float timerRounded = Mathf.Round(timer * 10f) / 10f;
			timerText.text = timerRounded.ToString();
	}
}