using UnityEngine;

public class Flag : Interactable, IClickable
{
	static LevelManager levelMgr;
	
	protected override void Start(){
		base.Start();
		
		levelMgr = LevelManager.instance;
	}
	
	public override void Interact(){
		base.Interact();
		
		levelMgr.Success();
	}
	
	public void OnClick(){ // in case of the popup window was closed, we can reopen it again by clicking on the flag
		if(!hasInteracted) return;
		
		levelMgr.Success();
	}
}