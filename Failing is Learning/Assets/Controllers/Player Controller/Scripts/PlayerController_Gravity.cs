using UnityEngine;

public class PlayerController_Gravity : PlayerController
{
	public bool isFalling{ get; private set; }
	
	#region Component(s)
		
		PlayerController_Jump jumpController;
		
			bool isJumping{ get{ return jumpController.isJumping; }}
			
		protected override void Awake(){
			base.Awake();
			
			jumpController = GetComponent<PlayerController_Jump>();
		}
		
	#endregion
	
	// Input
	void Update(){
		if(isJumping || isGrounded){
			ResetLogic();
			isFalling = false;
			return;
		}
		
		isFalling = true;
		GetCurveByTime();
	}
	
	// Motor
	void FixedUpdate(){
		if(!isFalling) return;
			
		var velocityY = velocity * curveValue;
		
		var targetVelocity = new Vector3(
			rb.velocity.x,
			-velocityY,
			rb.velocity.z
		);
			
		rb.velocity = targetVelocity;
	}

	#region Main Logic
	
		float timer, curveValue;
			
		void GetCurveByTime(){
			timer -= Time.deltaTime;
				
			float timeLerp = timer / duration;
			curveValue = curve.Evaluate(timeLerp);
		}
		
		void ResetLogic(){
			if(!isFalling) return;
			
			timer = duration;
			isFalling = true;
		}
	
	#endregion
}