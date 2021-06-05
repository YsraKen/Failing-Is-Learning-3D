using UnityEngine;

public class MechanicalSpike : Toggleables
{
	public Collider col;
	public Animator anim;
	

		
	static readonly string
		extend_clip = "extend",
		retract_clip = "retract";
	
	public override void Toggle(bool toggle){
		if(toggle) Extend();
		else Retract();
		
		base.Toggle(toggle);
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