using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_Attack : StateMachineBehaviour
{
    private Spider spider;
    private PlayerBehaviour playerBehaviour;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       spider = animator.GetComponent<Spider>();

       spider.attackEffect.SetActive(true);
       playerBehaviour = spider.player.GetComponent<PlayerBehaviour>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        spider.FlipSpiderTo(spider.playerPos);
        
        spider.attackEffect.transform.position = spider.playerPos - new Vector3(0,0.1f,0);

        if(animator.GetCurrentAnimatorClipInfo(0)[0].clip.length - stateInfo.normalizedTime <= 0.01f)
        {
            DealDamage();
        }

        if(!spider.isPlayerInAttackZone())
        {
            animator.SetTrigger("walk");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        spider.attackEffect.SetActive(false);
    }

    private void DealDamage()
    {
        playerBehaviour.TakeDamage(spider.damage);
    }
}
