using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController_TouchInput :
	MonoBehaviour,
	IPointerDownHandler,
	IPointerUpHandler
{
	public bool isPressed{ get; private set; }
	
	public void OnPointerDown(PointerEventData data){
		isPressed = true;
	}
	
	public void OnPointerUp(PointerEventData data){
		isPressed = false;
	}
}