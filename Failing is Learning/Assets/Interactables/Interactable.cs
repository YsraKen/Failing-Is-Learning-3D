using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
	protected static PlayerManager playerMgr;
	protected static GameObject player;
	
	protected bool hasInteracted; // no specific use yet
	
	public bool uninteractOnExit = false;
	
	#region Components
	
		InteractableManager mgr;
	
	#endregion
	
	#region Events
	
		public UnityEvent
			onInteraction = new UnityEvent(),
			onUnteraction = new UnityEvent();
	
	#endregion
	
	#region Unity Methods
	
		protected virtual void Start(){
			playerMgr = PlayerManager.instance;
			player = Player.instance.gameObject;

			mgr = InteractableManager.instance;
		}
		
		void OnTriggerEnter(Collider col){
			if(col.gameObject == player)
				Interact();
		}
		
		void OnTriggerExit(Collider col){
			if(!uninteractOnExit) return;
			
			if(col.gameObject == player)
				Uninteract();
		}
	
	#endregion
	
	public virtual void Interact(){
		hasInteracted = true;
		
		mgr.OnInteractionEnter(this);
		onInteraction?.Invoke();
	}
	
	public virtual void Uninteract(){
		hasInteracted = false;
		
		mgr.OnInteractionExit(this);
		onUnteraction?.Invoke();
	}
}