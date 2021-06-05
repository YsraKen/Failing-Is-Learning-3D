using UnityEngine;

[CreateAssetMenu]
public class PlayerController_Settings : ScriptableObject
{
	[Header("Movement")]
		public float moveSpeed = 5f;
		public float moveSmooth = 0.2f;
		
	[Header("Jump and Gravity")]
		// public float jumpForce = 7f;
		// public ForceMode forceMode;
		
		public float duration = 0.65f;
		public float velocity = 5f;
			
		public AnimationCurve curve;
	
	[Header("Ground Check")]
		public Vector3 cubeSize = new Vector3(0.45f, 0.25f, 0.45f);
		public LayerMask groundLayers;
}