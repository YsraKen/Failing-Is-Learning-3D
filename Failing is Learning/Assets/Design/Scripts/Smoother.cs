using UnityEngine;

public class Smoother
{
	private Vector3
		current,
		velocity;
	
	private float smoothTime;
		
	#region Constructors
		
		public Smoother(){}
		
		public Smoother(float smoothTime){
			this.smoothTime = smoothTime;
		}
	
	#endregion
	
	public Vector3 Smoothen(Vector3 target){
		current = Vector3.SmoothDamp(
			current,
			target,
			ref velocity,
			smoothTime
		);
		
		return current;
	}
	
	public Vector3 Smoothen(Vector3 target, float newSmoothTime){
		current = Vector3.SmoothDamp(
			current,
			target,
			ref velocity,
			newSmoothTime
		);
		
		smoothTime = newSmoothTime;
		
		return current;
	}
}