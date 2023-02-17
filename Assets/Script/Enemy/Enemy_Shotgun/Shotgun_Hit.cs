using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun_Hit : StateMachineBehaviour
{
    private Shotgun shotgun;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       shotgun = animator.GetComponent<Shotgun>();
       shotgun.IgnorePlayerCollsion(true);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        shotgun.IgnorePlayerCollsion(false);

        if(shotgun.Health <= 0)
        {
            animator.SetTrigger("dead");
        }
        if(shotgun.isPlayerInAttackBox(shotgun.attackRantge))
        {
         animator.SetTrigger("attack");
        }
        else
        {
            animator.SetTrigger("walk");
        }
    }
}
