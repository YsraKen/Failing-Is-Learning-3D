using UnityEngine;

public class Traps : Interactable
{
	public override void Interact(){
		base.Interact();
		
		playerMgr.Damage();
	}
}