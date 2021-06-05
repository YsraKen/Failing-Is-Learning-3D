using UnityEngine;
using UnityEngine.Events;

// Managing ingame popups, arranging it's sibling hierarchy order

public class InGamePopups_Manager : MonoBehaviour
{
	public static InGamePopups_Manager instance{ get; private set; }
	void Awake(){ instance = this; }
	
	#region Events
	
		[System.Serializable]
		public class EventWrapper{
			public UnityEvent
				onPopupOpen = new UnityEvent(),
				onPopupClose = new UnityEvent();
				
			public void OnPopupOpen(){ onPopupOpen?.Invoke(); }
			public void OnPopupClose(){ onPopupClose?.Invoke(); }
		}
	
		public EventWrapper events = new EventWrapper();
		
	#endregion
	
	public void OnPopupOpen(InGamePopups popup){
		popup.transform.SetAsLastSibling();
		events.OnPopupOpen();
	}
	
	public void OnPopupClose(InGamePopups popup){
		events.OnPopupClose();
	}
}