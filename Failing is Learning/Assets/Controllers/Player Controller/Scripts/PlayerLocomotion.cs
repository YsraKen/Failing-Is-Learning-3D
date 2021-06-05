using UnityEngine;
using UnityEngine.Events;

public class PlayerLocomotion : MonoBehaviour
{
	public PlayerController_Movement moveController;
	
	public Transform graphics;
	public Animator anim;
	
	static readonly string speed_param = "speed";
	
	void Update(){
		var inputDir = moveController.inputDir;
		float moveMagnitude = inputDir.magnitude;
			anim.SetFloat(speed_param, moveMagnitude);
			
		var localDir = inputDir.normalized + graphics.position;
			graphics.LookAt(localDir);
	}
}