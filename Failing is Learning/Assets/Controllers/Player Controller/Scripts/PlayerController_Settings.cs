using UnityEngine;

[CreateAssetMenu]
public class PlayerController_Settings : ScriptableObject
{
	[Header("Movement")]
		public float moveSpeed = 5f;
		public float moveSmoothTime = 0.12f;
		
		[Range(0,1f)] public float airControlPercent = 0.5f;
	
	[Header("Collisions")]
	public float collisionCheckRadius;
	public LayerMask collisionLayers;
		
	[Header("Jump and Gravity")]
		public float jumpForce = 7f;
		public ForceMode jumpForceMode = ForceMode.Impulse;
	
	[Header("Ground Check")]
		public Vector3 cubeSize = new Vector3(0.45f, 0.25f, 0.45f);
		public LayerMask groundLayers;
}