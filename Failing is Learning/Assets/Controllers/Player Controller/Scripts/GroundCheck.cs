using UnityEngine;

public class GroundCheck : MonoBehaviour
{
	public bool isGrounded{ get; private set; }
	
	public bool getGroundInfo;
	public RaycastHit groundInfo{ get; private set; }
	public Transform rayPoint;
	
	public Monostable monostable = new Monostable(); // oneframe call for isGrounded update
	
	PlayerController_Settings settings;
	
	void Start(){
		settings = PlayerController.settings;
	}
	
	void Update(){
		
		isGrounded = Physics.CheckBox(
			transform.position,
			settings.cubeSize,
			Quaternion.identity,
			settings.groundLayers
		);
		
		monostable.Update(isGrounded);
		
		if(getGroundInfo) GetGround();
	}
	
	void GetGround(){
		RaycastHit hit;
		
		if(Physics.Raycast(
			rayPoint.position,
			Vector3.down,
			out hit,
			100.0f,
			settings.groundLayers
		))
			groundInfo = hit;
	}
	
	void OnDrawGizmos(){
		if(!settings) return;
		Gizmos.DrawWireCube(transform.position, settings.cubeSize * 2); // half extents
	}
}