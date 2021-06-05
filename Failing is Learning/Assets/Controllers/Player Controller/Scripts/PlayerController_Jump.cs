using UnityEngine;
using UnityEngine.Events;
using System.Collections;

// Detect a pulse input
	// start a jump routine
		// keep track on input hold
			// run a timer
				// get a curve value, lerped by timer and store it for later use
		
		// on input release
			// stop jump routine
			
	// on physics update: set rb's vertical velocity by "velocity" variable (but modified with curve value)
	
public class PlayerController_Jump : PlayerController
{
	public bool isJumping{ get; private set; } // gate
	
	#region Events
	
		[System.Serializable]
		public class EventWrapper{
			public UnityEvent
				onJumpEnter = new UnityEvent(),
				onJumpUpdate = new UnityEvent(),
				onJumpExit = new UnityEvent();
				
			public void OnJumpEnter(){
				onJumpEnter?.Invoke();
			}
			
			public void OnJumpUpdate(){
				onJumpUpdate?.Invoke();
			}
			
			public void OnJumpExit(){
				onJumpExit?.Invoke();
			}
		}
		
		public EventWrapper events = new EventWrapper();
	
	#endregion
	
	#region Unity Methods
		
		#region Updates
		
			// Input
			void Update(){
				if(input.OnJumpButtonDown && isGrounded)
					StartJumpRoutine();
			}
			
			// Motor
			void FixedUpdate(){
				if(!isJumping) return;
				
				var velocityY = velocity * curveValue;
				
				var targetVelocity = new Vector3(
					rb.velocity.x,
					velocityY,
					rb.velocity.z
				);
					
				rb.velocity = targetVelocity;
			}
			
		#endregion
		
	#endregion
	
	#region Jump
		
		#region Calls
		
			void StartJumpRoutine(){
				events.OnJumpEnter();
				
				StopJumpRoutine();
				
				jumpRoutine = NewJump_Routine();
				StartCoroutine(jumpRoutine);
			}
			
			public void StopJumpRoutine(){ // public modifier: on player damaged, respawn
				if(jumpRoutine != null)
					StopCoroutine(jumpRoutine);
				
				jumpRoutine = null;
				isJumping = false;
			}
		
		#endregion
		
		#region Main Logic
		
			float timer, curveValue;
			
			void GetCurveByTime(){
				timer += Time.deltaTime;
					
				float timeLerp = timer / duration;
				curveValue = curve.Evaluate(timeLerp);
			}
		
		#endregion
		
		#region Coroutine
			
			IEnumerator jumpRoutine;
			
			IEnumerator NewJump_Routine(){
				timer = 0;
				isJumping = true;
				
				
				
				while(
					timer <= duration &&
					input.OnJumpButton // is button held
				){
					GetCurveByTime();
					events.OnJumpUpdate();
					
					yield return null;
				}
			
				StopJumpRoutine();
				events.OnJumpExit();
			}
			
		#endregion
	
	#endregion
}