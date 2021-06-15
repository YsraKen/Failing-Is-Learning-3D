using UnityEngine;

public class CameraController : MonoBehaviour
{
	public CameraController_Settings _settings;
	
	protected static CameraController_Settings settings;
	protected static Player player;
	
	Transform follow;
	Smoother smoother;
	
	void Start(){
		player = Player.instance;
		if(!settings) settings = _settings;
		
		// Setup Camera Rig
			follow = new GameObject("Camera Follow").transform;
			transform.parent = follow;
			
			transform.localPosition = settings.offset;
			follow.eulerAngles = settings.onStartUpRotation;
		
		smoother = new Smoother(settings.smoothSpeed);
	}
	
	void FixedUpdate(){
		var targetPosition = smoother.Smoothen(player.position);
		follow.position = targetPosition;
	}
	
/* 	
	
	Player player;
	
	void Start(){
		player = Player.instance;
		
		transform.eulerAngles = Vector3.right * settings.onStartUpAngle;
	}
	
	void LateUpdate(){
		transform.position = player.position + settings.offset;
	} */
	
/* 	#region Settings
	
		public CameraController_Settings settings;
		
		Vector3 offset{ get{ return settings.offset; }}
		float smoothSpeed{ get{ return settings.smoothSpeed; }}
		
		public Vector2 pitchMinMax{ get{ return settings.pitchMinMax; }}
		public Vector2 yawMinMax{ get{ return settings.yawMinMax; }}
		
		float sensitivity{ get{ return settings.sensitivity; }}
		float onStartUpAngle{ get{ return settings.onStartUpAngle; }}
		
	#endregion
	
	#region Components
	
		Player player;
		Transform cameraFollow; // to be created on start
		
		public GroundCheck groundCheck;
		
	#endregion
	
	#region Unity Methods
	
		void Start(){
			player = Player.instance;
			
			// create a camera rig
				cameraFollow = new GameObject("camFollow").transform;
					transform.parent = cameraFollow;
					transform.localPosition = offset;
				
				// reset orientation
					targetPosition = player.position; // actual variable to be reset
						currentPosition = targetPosition; // extra variables from smoothing
						smoothenPosition = currentPosition; // extra variables from smoothing
						
						cameraFollow.position = smoothenPosition;
					
					pitch = onStartUpAngle;
					targetRotation = new Vector3(pitch, yaw); // actual variable
						currentPosition = targetPosition; // extra variables from smoothing
						smoothenRotation = currentPosition; // extra variables from smoothing
				
						cameraFollow.eulerAngles = smoothenRotation;
		}
		
		// Input
		void Update(){
			var input = TouchInput.DragDelta * sensitivity;
			
			CameraPanning(input);
			CollisionDetect();
		}
		
		// Motor
		void FixedUpdate(){
			// focus on the center between player and floor
		
			float midPoint = 0.5f; // magic number (for readable purpose).
		
				var focusPoint = Vector3.Lerp(player.position, floorPosition, midPoint);
				targetPosition = focusPoint;
			
			CameraSmoothing();
			
			cameraFollow.position = smoothenPosition;
			cameraFollow.eulerAngles = smoothenRotation;
		}
		
	#endregion
	
	#region Logic
	
		Vector3 floorPosition{
			get{
				var position = Vector3.zero;
				
				if(groundCheck && groundCheck.getGroundInfo)
					position = groundCheck.groundInfo.point;
				
				else
					position = new Vector3(player.position.x, 0f, player.position.z);
				
				return position;
			}
		}
			
		float
			pitch, // tango
			yaw; // lingon
		
		void CameraPanning(Vector2 input){
			yaw += input.x;
			pitch -= input.y;
			
				yaw = Mathf.Clamp(yaw, yawMinMax.x, yawMinMax.y);
				pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);
			
			targetRotation = new Vector3(pitch, yaw);
		}
	
	#endregion
	
	#region Smoothing
	
		Vector3
			currentPosition,
			targetPosition,
			positionVelocity,
			
			currentRotation,
			targetRotation,
			rotationVelocity,
			
		// Output
			smoothenPosition,
			smoothenRotation;
			
		void CameraSmoothing(){
			currentPosition = Vector3.SmoothDamp(
				currentPosition,
				targetPosition,
				ref positionVelocity,
				smoothSpeed
			);
			
			currentRotation = Vector3.SmoothDamp(
				currentRotation,
				targetRotation,
				ref rotationVelocity,
				smoothSpeed
			);
			
			smoothenPosition = currentPosition;
			smoothenRotation = currentRotation;
		}
	
	#endregion
	
	#region CollisionDetect
	
		void CollisionDetect(){
			if(!settings.doCollisionDetect) return;
			
			var origin = cameraFollow.position;
			var direction = -transform.forward;
			float maxDistance = Mathf.Abs(offset.z);
			float bubbleRadius = settings.bubbleRadius;
			var collisionLayer = settings.collisionLayer;
			
			RaycastHit hit;
			
			bool raycast = Physics.Raycast(
				origin,
				direction,
				out hit,
				maxDistance,
				collisionLayer
			);
			
			if(raycast)
				transform.localPosition = Vector3.back * (hit.distance - bubbleRadius);
			else
				transform.localPosition = offset;
		}
	
	#endregion */
}