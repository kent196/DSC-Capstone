using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_Unactive : StateMachineBehaviour
{
    private Spider spider;
    private float healTime = .1f;
    private float currentHealTime;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        spider = animator.GetComponent<Spider>();
        currentHealTime = healTime;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(spider.Health<spider.MaxHealth)
        {
            if(currentHealTime<=0)
            {
                currentHealTime = healTime;
                spider.Heal(1);
            }
            else
            {
                currentHealTime -= Time.deltaTime;
            }
        }
        else
        {
            spider.Health = spider.MaxHealth;
        }
        if(spider.isPlayerInLookBox(spider.currentLookRange))
        {
            if(spider.isRaycastHit(spider.transform.position, spider.playerPos, "Player"))
            {
                spider.FlipEnemyTo(spider.playerPos);
                animator.SetTrigger("active");
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
