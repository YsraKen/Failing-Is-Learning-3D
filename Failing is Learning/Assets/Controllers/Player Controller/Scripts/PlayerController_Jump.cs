using UnityEngine;
using UnityEngine.Events;

public class PlayerController_Jump : PlayerController
{
	Monostable monostable;
		
	// shortcut
		ForceMode forceMode{ get{ return settings.jumpForceMode; }}
	
	public UnityEvent onJump = new UnityEvent();
	
	void Start(){
		monostable = new Monostable();
			monostable.events.onRise += Jump;
			monostable.events.onFall += CancelVelocityY;
	}
	
	void Update(){
		monostable.Update(input.OnJumpInput);
	}
	
	public void Jump(){
		if(!isGrounded) return;
		
		CancelVelocityY();
		rb.AddForce(jumpVelocity, forceMode);
		
		onJump?.Invoke();
	}
	
	void CancelVelocityY(){
		bool isFalling = rb.velocity.y < 0f;
		
			if(isFalling) return;
		
		rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
	}
}