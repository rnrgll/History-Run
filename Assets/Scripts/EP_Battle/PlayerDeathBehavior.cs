using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathBehavior : StateMachineBehaviour
{
 
	private PlayerMoveButton player;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		player = animator.GetComponent<PlayerMoveButton>();
		player.isDead = true;
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}
}
