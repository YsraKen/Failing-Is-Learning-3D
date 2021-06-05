using UnityEngine;

[CreateAssetMenu]
public class CameraController_Settings : ScriptableObject
{
	public float
		offset = 10f,
		smoothSpeed = 0.12f;
		
	public Vector2
		pitchMinMax = new Vector2(-10f, 30f), // tango
		yawMinMax = new Vector2(-25f, 25f); // lingon
		
	public float sensitivity = 0.2f;
		
	[Header("Collision Detect")]
		public bool doCollisionDetect;
		public float bubbleRadius = 0.25f;
		public LayerMask collisionLayer;
		
	[Space(10)]
		public float onStartUpAngle = 20f;
}