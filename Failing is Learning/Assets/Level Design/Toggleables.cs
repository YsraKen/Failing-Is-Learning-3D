using UnityEngine;
using UnityEngine.Events;

public class Toggleables : MonoBehaviour
{
	protected bool state;
	
	public UnityEvent
		onRise = new UnityEvent(),
		onFall = new UnityEvent();
	
	public void Toggle(bool toggle){
		if(state == toggle) return;
		
			if(toggle) onRise?.Invoke();
			else onFall?.Invoke();
		
		OnToggle(toggle);
		state = toggle;
	}
	
	protected virtual void OnToggle(bool toggle){
		// for inheritance
	}
}