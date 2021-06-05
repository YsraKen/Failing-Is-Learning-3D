using UnityEngine;
using UnityEngine.Events;

public class WindowUI : MonoBehaviour
{
	public UnityEvent
		onOpen = new UnityEvent(),
		onClose = new UnityEvent();
	
	public Animator animator;
	
	static readonly string
		closeParam = "close";
		
	public virtual void Open(){ // instead of calling WindowUI.Open(), "gameObject.SetActive(true)" will still work
		gameObject.SetActive(true);
	}
		void OnEnable(){ onOpen?.Invoke(); }
	
	public virtual void Close(){
		animator?.SetTrigger(closeParam); // actual deactivation of object is inside of animation behaviour script
		onClose?.Invoke();
	}
}