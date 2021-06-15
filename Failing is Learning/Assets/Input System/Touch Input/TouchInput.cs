using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class TouchInput :
	MonoBehaviour,
	IPointerDownHandler,
	IPointerUpHandler,
    IDragHandler
{
	#region Singleton
	
		static TouchInput instance; // not used in other classes. The purpose is to insure that it only exist wiht one instace
		
		void Awake(){
			if(instance){
				Destroy(this);
				return;
			}
			
			instance = this;
		}
	
	#endregion
	
	public float sensitivity = 0.1f;
	
	#region Delegate
	
		public delegate void OnTouchUpdate();
		public static OnTouchUpdate onTouchDown, onTouchUp;
		
		public delegate void OnDragUpdate(Vector2 delta);
		public static OnDragUpdate onDrag;
		
	#endregion
	
	#region Unity Methods
		
		void Start(){
			onDragCheckFinished = OnPointerDown;
		}
		
		public void OnPointerDown(PointerEventData data){
			DragCheck();
		}
		
			void OnPointerDown(){ // called after checking the Drag
				onTouchDown?.Invoke();
			}
		
		public void OnPointerUp(PointerEventData data){
			onTouchUp?.Invoke();
		}
		
		public void OnDrag(PointerEventData data){
			onDrag?.Invoke(data.delta * sensitivity);
		}
	
	#endregion
	
	#region Drag Check
		
		public float dragCheckDuration = 0.2f;
		
		public delegate void OnDragCheckCalls();
		public OnDragCheckCalls onDragCheckFinished;
		
		void DragCheck(){
			StopDragCheck_Routine();
			
			dragCheck_Routine = NewDragCheck_Routine();
			StartCoroutine(dragCheck_Routine);
		}
		
		#region Coroutine
		
			IEnumerator dragCheck_Routine;
			
			void StopDragCheck_Routine(){
				if(dragCheck_Routine != null)
					StopCoroutine(dragCheck_Routine);
				
				dragCheck_Routine = null;
			}
			
			IEnumerator NewDragCheck_Routine(){
				yield return new WaitForSeconds(dragCheckDuration);
				onDragCheckFinished?.Invoke();
			}
		
		#endregion
	
	#endregion
}