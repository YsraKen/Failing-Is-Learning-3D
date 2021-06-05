using UnityEngine;
using UnityEngine.UI;

public class AudioTrigger_ButtonUI : AudioTrigger
{
	protected override void Start(){
		base.Start();
		
		var button = GetComponent<Button>();
			button.onClick.AddListener(OnButtonClick);
	}
	
	void OnButtonClick(){
		Play("buttonUI");
	}
}
