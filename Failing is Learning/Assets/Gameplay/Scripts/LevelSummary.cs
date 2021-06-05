using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class LevelSummary : MonoBehaviour
{
	public Text
		timeText,
		deathText,
		lifeText;
		
	public LevelGoals levelGoals;
	
	public float showIconDelay = 0.75f;
	public UnityEvent onSummaryFinished = new UnityEvent();
	
	IEnumerator Start(){
	
	#region Original Code
/*
		// Update UI
			float timer = Mathf.Round(levelGoals.timer * 100f) / 100f;
				timeText.text = timer.ToString();
			
			float deaths = levelGoals.deaths;
		
				if(deaths > 0){
					var parent = deathText.transform.parent;
						parent.gameObject.SetActive(true);
						
					deathText.text = "+" + deaths.ToString(); // + means the old value is added to a new value
				}
			
			int lives = Player.instance.life;
				lifeText.text = lives.ToString(); */
	
	#endregion
	
	#region Designed Code
		
		var delay = new WaitForSecondsRealtime(showIconDelay);
		
		// Time Summary
			yield return delay;
			
				float timer = Mathf.Round(levelGoals.timer * 100f) / 100f;
					timeText.text = timer.ToString();
					
				var parent = timeText.transform.parent;
					parent.gameObject.SetActive(true);
		
		// Deaths Summary
			float deaths = levelGoals.deaths;
			
			if(deaths > 0){
				yield return delay;
			
				deathText.text = "+" + deaths.ToString(); // + means the old value is added to a new value
					
					parent = deathText.transform.parent;
					parent.gameObject.SetActive(true);
			}
		
		// Life Summary
			yield return delay;
			
				int lives = Player.instance.life;
					lifeText.text = lives.ToString();
					
					parent = lifeText.transform.parent;
					parent.gameObject.SetActive(true);
					
		#endregion
		
		yield return delay;
		onSummaryFinished?.Invoke(); // particles, cheers
	}
}