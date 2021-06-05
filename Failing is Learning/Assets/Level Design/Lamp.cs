using UnityEngine;

public class Lamp : Toggleables
{
	public GameObject redLight;
	
	public override void Toggle(bool toggle){
		base.Toggle(toggle);
		
		redLight.SetActive(toggle);
	}
}