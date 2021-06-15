using UnityEngine;

public class WindowUI_Behaviour : StateMachineBehaviour
{
    override public void OnStateExit(
		Animator animator,
		AnimatorStateInfo stateInfo,
		int layerIndex
	){
		animator.gameObject.SetActive(false);
	}
}