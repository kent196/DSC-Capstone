using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun_Walk : StateMachineBehaviour
{
     private Shotgun shotgun;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      shotgun = animator.GetComponent<Shotgun>();
      animator.transform.position = Vector3.MoveTowards(animator.transform.position, shotgun.destination, shotgun.moveSpeed * Time.deltaTime);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      if(shotgun.isPlayerInAttackBox(shotgun.attackRantge))
      {
        shotgun.FlipEnemyTo(shotgun.playerPos);
        animator.SetTrigger("attack");
      }
      if(shotgun.isReachDestination())
      {
        animator.SetTrigger("idle");
      }
      else
      {
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, new Vector3(shotgun.destination.x, animator.transform.position.y, 0), shotgun.moveSpeed * Time.deltaTime);
      }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
