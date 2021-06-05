using UnityEngine;
using UnityEngine.Events;

public class Toggleables : MonoBehaviour
{
	public UnityEvent
		onRise = new UnityEvent(),
		onFall = new UnityEvent();
		
	public virtual void Toggle(bool toggle){
		if(toggle) onRise?.Invoke();
		else onFall?.Invoke();
	}
}