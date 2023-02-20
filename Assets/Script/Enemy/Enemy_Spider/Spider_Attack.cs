using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_Attack : StateMachineBehaviour
{
    private Spider spider;
    private AudioManager audioManager;
    private PlayerBehaviour playerBehaviour;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       spider = animator.GetComponent<Spider>();
       playerBehaviour = spider.player.GetComponent<PlayerBehaviour>();
       audioManager = FindObjectOfType<AudioManager>();

       audioManager.Play("Spider Attack");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        spider.FlipEnemyTo(spider.playerPos);

        if(animator.GetCurrentAnimatorClipInfo(0)[0].clip.length - stateInfo.normalizedTime <= 0.01f)
        {
            DealDamage();
        }

        if(!spider.isPlayerInAttackBox(spider.attackRange))
        {
            animator.SetTrigger("walk");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        audioManager.Stop("Spider Attack");
    }

    private void DealDamage()
    {
        playerBehaviour.TakeDamage(spider.Damage);
    }
}