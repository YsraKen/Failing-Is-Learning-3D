using UnityEngine;

public class PlayerController_Move : PlayerController
{
	public float inputDir{ get; private set; } // public access: PlayerLocomotion
	public Vector3 moveVelocity{ get; private set; } // public access: PlayerLocomotion
	
	Smoother
		sideVelocitySmoother,
		forwardVelocitySmoother;
	
	void Start(){
		sideVelocitySmoother = new Smoother();
		forwardVelocitySmoother = new Smoother(moveSmoothTime);
	}
	
	#region Movement
		
		// Input
			void Update(){
				inputDir = input.direction;
				
				var sideVelocity = Vector3.right * inputDir;
				var forwardVelocity = (isColliding)? Vector3.zero: Vector3.forward;
				
				var sideVelocity_Smooth = sideVelocitySmoother.Smoothen(sideVelocity, SmoothTime());
				var forwardVelocity_Smooth = forwardVelocitySmoother.Smoothen(forwardVelocity);
				
					moveVelocity = (sideVelocity_Smooth + forwardVelocity_Smooth) * moveSpeed;
					
				// CollisonCheck
					CollisonCheck();
			}
		
		// Motor
			void FixedUpdate(){
				var targetVelocity = new Vector3(
					moveVelocity.x,
					rb.velocity.y,
					moveVelocity.z
				);
				
				rb.velocity = targetVelocity;
			}
	
	#endregion
	
	// Character Creation (E09: collisions and jumping) by Sebastian Lague
	// https://www.youtube.com/watch?v=qITXjT9s9do&list=PLFt_AvWsXl0djuNM22htmz3BUtHHtOh7v&index=9
	float SmoothTime(){
		return
			(groundCheck.isGrounded)? moveSmoothTime:
			(airControlPercent == 0f)? float.MaxValue:
			moveSmoothTime / airControlPercent;
	}
	
	#region CollisionCheck
	
		public Transform collisionCheckPoint;
		
		float collisionCheckRadius{ get{ return settings.collisionCheckRadius; }}
		LayerMask collisionLayers{ get{ return settings.collisionLayers; }}
		
		bool isColliding;
		
		void CollisonCheck(){
			// Collision Check
				var colliders = Physics.OverlapSphere(
					collisionCheckPoint.position,
					collisionCheckRadius,
					collisionLayers
				);
					
				isColliding = colliders.Length != 0;
		}
		
		void OnDrawGizmosSelected(){
			if(!collisionCheckPoint) return;
			if(!settings) settings = _settings;
			
			Gizmos.DrawWireSphere(
				collisionCheckPoint.position,
				collisionCheckRadius
			);
		}
	
	#endregion
}