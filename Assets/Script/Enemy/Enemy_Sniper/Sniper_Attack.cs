using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper_Attack : StateMachineBehaviour
{
    private Sniper sniper;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        sniper = animator.GetComponent<Sniper>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        sniper.FlipEnemyTo(sniper.playerPos);
        if(!sniper.isPlayerInAttackCircle(sniper.attackRadius) || !sniper.isRaycastHit(sniper.transform.position, sniper.playerPos, "Player"))
        {
            animator.SetTrigger("unactive");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}