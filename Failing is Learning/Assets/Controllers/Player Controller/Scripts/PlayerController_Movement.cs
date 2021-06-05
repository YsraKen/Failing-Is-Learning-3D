using UnityEngine;

public class PlayerController_Movement : PlayerController
{
	public Vector3 inputDir;
	Vector3 moveVelocity;
		
	// Inputs
	void Update(){
		// Setup Move Input
			inputDir = new Vector3(
				input.Horizontal,
				0f, 
				input.Vertical
			);
			
			inputDir = Vector3.ClampMagnitude(inputDir, 1f);
			
			moveVelocity = inputDir * moveSpeed; // multiply the input direction to desired speed
			SmoothenMoveVelocity();
			
/* 		// Setup Jump Input
			if(input.OnJumpButtonDown && gndCheck.isGrounded){
				// Reset Vertical Velocity
				rb.velocity = new Vector3(
					rb.velocity.x,
					0f,
					rb.velocity.z
				);
				
				// Modify Vertical Velocity
				var jumpVelocity = Vector3.up * jumpForce;
				rb.AddForce(jumpVelocity, jumpForceMode);
			} */
	}
	
	#region Move Smooth
	
		Vector3
			smoothVelocity,
			targetVelocity,
			velocityRef;
			
		void SmoothenMoveVelocity(){
			targetVelocity = moveVelocity;
			
			smoothVelocity = Vector3.SmoothDamp(
				smoothVelocity,
				targetVelocity,
				ref velocityRef,
				moveSmooth
			);
		}
	
	#endregion
	
	// Motor
	void FixedUpdate(){
		var velocity = new Vector3(
			smoothVelocity.x,
			rb.velocity.y,
			smoothVelocity.z
		);
		
		rb.velocity = velocity;
	}
}