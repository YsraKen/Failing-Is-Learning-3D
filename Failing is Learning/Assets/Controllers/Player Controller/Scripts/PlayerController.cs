using UnityEngine;

// Automatic forward Movement
// Left and Right controllable movement

public class PlayerController : MonoBehaviour
{
	protected static Rigidbody rb;
	protected static GroundCheck groundCheck;
	
	protected static PlayerController_Input input;
	
	#region Shortcuts
		
		public PlayerController_Settings _settings;
		protected static PlayerController_Settings settings; // static holder
		
		protected static float moveSpeed{
			get{ return settings.moveSpeed; }
		}
		
		protected static float moveSmoothTime{
			get{ return settings.moveSmoothTime; }
		}
		
		protected static float airControlPercent{
			get{ return settings.airControlPercent; }
		}
		
		protected static Vector3 jumpVelocity{
			get{ return Vector3.up * settings.jumpForce; }
		}
		
		protected static bool isGrounded{
			get{ return groundCheck.isGrounded; }
		}
	
	#endregion
	
	void Awake(){
		if(!settings) settings = _settings; // static holder
		
		rb = GetComponent<Rigidbody>();
		groundCheck = GetComponentInChildren<GroundCheck>();
				
		input = FindObjectOfType<PlayerController_Input>();
	}
}