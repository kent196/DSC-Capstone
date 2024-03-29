using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper_Hit : StateMachineBehaviour
{
    private Sniper sniper;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       sniper = animator.GetComponent<Sniper>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(sniper.Health<=0)
        {
            animator.SetTrigger("dead");
        }
    }
}
