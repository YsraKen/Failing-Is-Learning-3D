using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public PlayerController_Input _input;
	public PlayerController_Settings _settings;
	
	#region Shortcuts
		
		// static holder
			protected static PlayerController_Input input;
			public static PlayerController_Settings settings;
		
		protected static float moveSpeed{ get{ return settings.moveSpeed; }}
		protected static float moveSmooth{ get{ return settings.moveSmooth; }}
		
		// protected float jumpForce{ get{ return settings.jumpForce }}
		// protected ForceMode forceMode{ get{ return settings.forceMode }}
		
		protected static float duration{ get{ return settings.duration; }}
		protected static float velocity{ get{ return settings.velocity; }}
			
		protected static AnimationCurve curve{ get{ return settings.curve; }}
	
		protected static Vector3 cubeSize{ get{ return settings.cubeSize; }}
		protected static LayerMask groundLayers{ get{ return settings.groundLayers; }}
		
		protected bool isGrounded{ get{ return gndCheck.isGrounded; }}
		
	#endregion
	
	protected Rigidbody rb;
	protected GroundCheck gndCheck;
	
	protected virtual void Awake(){
		// static holders
			if(!input) input = _input;
			if(!settings) settings = _settings;
		
		rb = GetComponent<Rigidbody>();
		gndCheck = GetComponentInChildren<GroundCheck>();
	}
}