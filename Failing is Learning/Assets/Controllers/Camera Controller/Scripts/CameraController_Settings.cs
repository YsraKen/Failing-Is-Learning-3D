using UnityEngine;

[CreateAssetMenu]
public class CameraController_Settings : ScriptableObject
{
	public float
		smoothSpeed = 0.12f;
	
	public Vector3 offset = new Vector3(-1f, 3f, -15f);
	
	[Space(10)]
		public Vector3 onStartUpRotation = new Vector3(20f, 10f, 0f);
}