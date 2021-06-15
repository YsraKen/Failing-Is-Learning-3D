using UnityEngine;

public class MechanicalSpike : Toggleables
{
	public Collider col;
	public Animator anim;
	
	static readonly string
		extend_clip = "extend",
		retract_clip = "retract";
	
	protected override void OnToggle(bool toggle){
		if(toggle) Extend();
		else Retract();
	}
		
	void Extend(){
		col.enabled = true;
		anim.Play(extend_clip);
	}
	
	void Retract(){
		col.enabled = false;
		anim.Play(retract_clip);
	}
}