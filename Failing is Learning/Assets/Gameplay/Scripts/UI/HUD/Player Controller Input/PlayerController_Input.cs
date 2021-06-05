using UnityEngine;

public class PlayerController_Input : MonoBehaviour
{
	public Thumbstick thumbstick;
	public JumpButton jumpButton;
	
	public Vector2 axis{ get{ return thumbstick.value; }}
	public float Horizontal{ get{ return thumbstick.Horizontal; }}
	public float Vertical{ get{ return thumbstick.Vertical; }}
	
	public bool OnJumpButton{ get{ return jumpButton.OnButton; }}
	public bool OnJumpButtonDown{ get{ return jumpButton.OnButtonDown; }}
	public bool OnJumpButtonUp{ get{ return jumpButton.OnButtonUp; }}
}