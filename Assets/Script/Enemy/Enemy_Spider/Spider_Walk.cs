using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_Walk : StateMachineBehaviour
{
    private Spider spider;
    private Vector3 walkDestination;
    private bool isGoToHome = false;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       spider = animator.GetComponent<Spider>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float homeDistance = Mathf.Abs(spider.homePos.x - animator.transform.position.x);

        if(homeDistance >= spider.homeMaxDistance)
        {
            isGoToHome = true;
            walkDestination = spider.homePos;
        }
        if(spider.isPlayerInLookZone() && !isGoToHome)
        {
            walkDestination = spider.playerPos;
        }
        else 
        {
            walkDestination = spider.homePos;
            if(homeDistance <= 0.1f)
            {
                isGoToHome = false;
                animator.SetTrigger("unactive");
            }
        }

        if(spider.isPlayerInAttackZone())
        {
            animator.SetTrigger("attack");
        }

        spider.FlipSpiderTo(walkDestination);
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, walkDestination, spider.moveSpeed * Time.deltaTime);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        spider.Rb.velocity = new Vector2(0, spider.Rb.velocity.y);
    }
}