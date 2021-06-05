using UnityEngine;
using UnityEngine.UI;

public class MainMenu_LevelButton : MonoBehaviour
{
	public Text
		idText,
		deathCountText,
		timeLengthText;
	
	public Button button;
	public GameObject lockIcon;
	public Animator anim;
	
	#region Setup
	
		public void SetActive(bool activeSelf){ // shortcut
			gameObject.SetActive(activeSelf);
		}
		
		int _levelIndex;
		public int levelIndex{
			get{ return _levelIndex; }
			set{
				// cache for later use
					_levelIndex = value;
				
				// text UI update
					int arrayOffset = 1;
					int id = _levelIndex + arrayOffset;
						
						idText.text = id.ToString();
			}
		}
		
		public int deathCount{
			set{
				deathCountText.text = value.ToString();
				deathCountText.gameObject.SetActive(value != 0);
			}
		}
		
		public float timeLength{
			set{
				// little modification
					float roundValue = 100f;
					float finalValue = Mathf.Round(value * roundValue) / roundValue;
				
				// ui update
					timeLengthText.text = finalValue.ToString();
					timeLengthText.gameObject.SetActive(true);
			}
		}
		
		// Design
			public void Lock(){				
				button.interactable = false;
				lockIcon.SetActive(true);
			}
			
			public void Unlock(){
				button.interactable = true;
				anim.SetTrigger("unlock");
			}
			
	#endregion
	
	public void OnButtonClick(){
		LevelLoader.instance.Load(levelIndex);
	}
}