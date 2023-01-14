using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_Walk : StateMachineBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Vector3 rayCastBoxSize = new Vector3(5f,2f,0f);
    private Vector3 enemyPos;
    private Rigidbody2D spiderRb;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       spiderRb = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyPos = animator.transform.position;
        RaycastHit2D hitInfo = Physics2D.BoxCast(enemyPos, rayCastBoxSize, 0 , Vector2.left, 10f, playerLayer);
        if(hitInfo)
        {
            Debug.Log(hitInfo.transform.name);
            animator.SetFloat("moveSpeed", spiderRb.velocity.x);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    private void MoveTowardsPlayer()
    {
        
    }
}
