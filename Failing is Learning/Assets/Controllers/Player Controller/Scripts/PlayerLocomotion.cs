using UnityEngine;
using UnityEngine.Events;

public class PlayerLocomotion : MonoBehaviour
{
	PlayerController_Move moveController;
	
	public Transform graphics;
	public Animator anim;
	
	static readonly string speed_param = "speed";
	
	void Awake(){
		moveController = GetComponent<PlayerController_Move>();
	}
	
	void Update(){
		float inputDir = moveController.inputDir;
			anim.SetFloat(speed_param, Mathf.Abs(inputDir));
			
		var lookDir = moveController.moveVelocity;
		var localDir = lookDir + graphics.position;
			
			graphics.LookAt(localDir);
	}
}