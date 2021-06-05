using UnityEngine;
using UnityEngine.Events;

// Tracking the interactions, what object interacted etc
// Managing events for interactions

public class InteractableManager : MonoBehaviour
{
	public static InteractableManager instance{ get; private set; }
	void Awake(){ instance = this; }
	
	#region Events
	
		[System.Serializable]
		public class EventsWrapper
		{
			public UnityEvent<Interactable>
				onInteractionEnter = new UnityEvent<Interactable>(),
				onInteractionExit = new UnityEvent<Interactable>();
				
			public void OnInteractionEnter(Interactable interactable){
				onInteractionEnter?.Invoke(interactable);
			}
			
			public void OnInteractionExit(Interactable interactable){
				onInteractionExit?.Invoke(interactable);
			}
		}
		
		public EventsWrapper events = new EventsWrapper();
	
	#endregion
	
	public void OnInteractionEnter(Interactable current){
		// Debug.Log("Interacted with " + current);
		events.OnInteractionEnter(current);
	}
	
	public void OnInteractionExit(Interactable current){
		// Debug.Log("Uninteracted with " + current);
		events.OnInteractionExit(current);
	}
}