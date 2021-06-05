using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Thumbstick :
	MonoBehaviour,
	IDragHandler,
	IPointerUpHandler,
	IPointerDownHandler
{
	public bool autoReset = true;
	public Image threshold, touch;
	
	Vector2 inputVector;
	
	static readonly string
		horizontal = "Horizontal",
		vertical = "Vertical";

	public virtual void OnDrag(PointerEventData eventData){
		// "Unity 5 Virtual Joystick [Tutorial][C#] - Unity 3d" by N3K EN. https://www.youtube.com/watch?v=uSnZuBhOA2U
			// only works with rectTransform pivot: (1, 0)
		
		Vector2 pos;
		
		if(RectTransformUtility.ScreenPointToLocalPointInRectangle(
			threshold.rectTransform,
			eventData.position,
			eventData.pressEventCamera,
			out pos
		)){
			pos.x = (pos.x / threshold.rectTransform.sizeDelta.x);
			pos.y = (pos.y / threshold.rectTransform.sizeDelta.y);
			
			inputVector = new Vector2(pos.x * 2 + 1, pos.y * 2 - 1);
			
			inputVector = (inputVector.magnitude > 1.0f)?
				inputVector.normalized:
				inputVector;
			
			touch.rectTransform.anchoredPosition = 
				new Vector2(
					inputVector.x * (threshold.rectTransform.sizeDelta.x / 3),
					inputVector.y * (threshold.rectTransform.sizeDelta.y / 3)
				);
		} 
	}
	
	public virtual void OnPointerDown(PointerEventData eventData){ OnDrag(eventData); }
	
	public virtual void OnPointerUp(PointerEventData eventData){
		if(autoReset){
			inputVector = Vector3.zero;
			touch.rectTransform.anchoredPosition = Vector3.zero;
		}
	}
	
	public Vector2 value{
		get{
			var output = new Vector2(Horizontal, Vertical);
			return output;
		}
	}
	
	public float Horizontal{
		get{
			return (inputVector.x != 0)? inputVector.x: Input.GetAxis(horizontal);
		}
	}
	
	public float Vertical{
		get{
			return (inputVector.y != 0)? inputVector.y: Input.GetAxis(vertical);
		}
	}
}