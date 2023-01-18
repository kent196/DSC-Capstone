using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_Unactive : StateMachineBehaviour
{
    private Spider spider;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        spider = animator.GetComponent<Spider>();
        spider.currentLookRange = spider.lookRange;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(spider.isPlayerInLookZone())
        {
            spider.FlipSpiderTo(spider.playerPos);
            animator.SetTrigger("active");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
