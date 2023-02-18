using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_Hit : StateMachineBehaviour
{
    private Spider spider;
    [SerializeField] private float multiplyLookrange = 3;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        spider = animator.GetComponent<Spider>();
        spider.currentLookRange.x = spider.lookRange.x * multiplyLookrange;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        spider.FlipEnemyTo(spider.playerPos);
        if(spider.isPlayerInAttackBox(spider.attackRange))
        {
            animator.SetTrigger("attack");
        }
        else
        {
            animator.SetTrigger("walk");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}