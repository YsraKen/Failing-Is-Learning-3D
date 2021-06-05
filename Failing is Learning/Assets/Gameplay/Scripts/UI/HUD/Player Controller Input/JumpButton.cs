using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class JumpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	#region Variables and Properties
	
		bool onButton, onButtonDown, onButtonUp;
		
		static readonly string jumpInput = "Jump";
			
		public bool OnButton{
			get{
				return
					onButton ? onButton:
					Input.GetButton(jumpInput);
			}
		}
		
		public bool OnButtonDown{
			get{
				return
					onButtonDown ? onButtonDown:
					Input.GetButtonDown(jumpInput);
			}
		}
		
		public bool OnButtonUp{
			get{
				return
					onButtonUp ? onButtonUp:
					Input.GetButtonUp(jumpInput);
			}
		}
	
	#endregion
	
	public void OnPointerDown(PointerEventData eventData){
		onButton = true;
		StartCoroutine(OnButtonDown_Pulse());
	}
	
	public void OnPointerUp(PointerEventData eventData){
		onButton = false;
		StartCoroutine(OnButtonUp_Pulse());
	}
	
	#region Pulse Logic
		
		IEnumerator OnButtonDown_Pulse(){
			onButtonDown = true;
			yield return null;
			onButtonDown = false;
		}
		
		IEnumerator OnButtonUp_Pulse(){
			onButtonUp = true;
			yield return null;
			onButtonUp = false;
		}
		
	#endregion
}