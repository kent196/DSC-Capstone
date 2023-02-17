using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun_Walk : StateMachineBehaviour
{
    private Shotgun shotgun;
    private float attackCooldown;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        shotgun = animator.GetComponent<Shotgun>();
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, shotgun.destination, shotgun.moveSpeed * Time.deltaTime);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!shotgun.isPlayerInLookBox(shotgun.lookRange))
        {
            shotgun.Patrol();
        }
        else
        {
            if (!shotgun.isPlayerInAttackBox(shotgun.attackRange))
            {
                shotgun.ChasePlayer();
            }
            else if (shotgun.isRaycastHit(animator.transform.position, shotgun.playerPos, "Player"))
            {
                shotgun.FlipEnemyTo(shotgun.destination);
                if (attackCooldown > 0)
                {
                    attackCooldown -= Time.deltaTime;
                }
                if (attackCooldown <= 0)
                {
                    animator.SetTrigger("attack");
                    attackCooldown = shotgun.attackCooldown;
                }

            }
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
