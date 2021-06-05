using UnityEngine;
using UnityEngine.EventSystems;

public class TouchInput :
	MonoBehaviour,
    IDragHandler,
    IEndDragHandler
{
	#region Singleton
	
		static TouchInput instance;
		void Awake(){
			if(instance){
				Destroy(this);
				return;
			}
			
			instance = this;
		}
	
	#endregion
	
	const float sensitivity = 0.1f; // mouse axis default sensitivity settings on Unity's InputManager
	
	public static Vector2 DragDelta{ get; private set; }
	
	public void OnDrag(PointerEventData eventData){
		DragDelta = eventData.delta * sensitivity;
	}
	
	public void OnEndDrag(PointerEventData eventData){
		DragDelta = Vector2.zero;
	}
}