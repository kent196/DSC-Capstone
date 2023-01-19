using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_Hit : StateMachineBehaviour
{
    private Spider spider;
    [SerializeField] private int playerLayer = 10;
    [SerializeField] private float multiplyLookrange = 3;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        spider = animator.GetComponent<Spider>();
        spider.currentLookRange.x = spider.lookRange.x * multiplyLookrange;

        Physics2D.IgnoreLayerCollision(playerLayer, animator.gameObject.layer, true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        spider.FlipSpiderTo(spider.playerPos);
        if(spider.isPlayerInAttackZone())
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
        Physics2D.IgnoreLayerCollision(playerLayer, animator.gameObject.layer, false);

    }
}
