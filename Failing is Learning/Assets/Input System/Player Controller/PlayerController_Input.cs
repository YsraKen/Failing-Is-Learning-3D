using UnityEngine;

public class PlayerController_Input : MonoBehaviour
{
	public PlayerController_TouchInput
		leftInput,
		midInput,
		rightInput;
	
	static readonly string
		horizontal_Input = "Horizontal",
		jump_Input = "Jump";
	
	public float direction{
		get{
			return
				(leftInput.isPressed)? -1f:
				(rightInput.isPressed)? 1f:
				Input.GetAxis(horizontal_Input);
		}
	}
	
	public bool OnJumpInput{
		get{
			return
				(midInput.isPressed)? true:
				Input.GetButton(jump_Input);
		}
	}
}