using UnityEngine;

public class Lamp : Toggleables
{
	public GameObject
		redLight,
		blackLight;
	
	public Animator anim;
	
	static readonly string 
		interact_param = "interact";
		
	protected override void OnToggle(bool toggle){
		redLight.SetActive(toggle);
		blackLight.SetActive(!toggle);
		
		anim.Play(interact_param);
	}
}