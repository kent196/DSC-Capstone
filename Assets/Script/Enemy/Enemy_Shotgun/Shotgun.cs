using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : EnemyBehavior
{
    [SerializeField] public float moveSpeed = 10f;
    [HideInInspector] public Vector3 destination;
    [HideInInspector] public float homePos;
    [SerializeField] private Transform patrolPointRight;
    [SerializeField] private Transform patrolPointLeft;
    private Vector3 patrolPointRightPos;
    private Vector3 patrolPointLeftPos;
    [SerializeField] public Vector2 attackRange;
    [SerializeField] public Vector2 lookRange;
    [SerializeField] public float attackCooldown;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        homePos = transform.position.x;

        patrolPointRightPos = patrolPointRight.position;
        patrolPointLeftPos = patrolPointLeft.position;
    }

    public float distanceToHomePos()
    {
        return transform.position.x - homePos;
    }

    public void ChasePlayer()
    {
        destination.x = playerPos.x;
        
        FlipEnemyTo(destination);
        MoveTo(destination);
    }

    public void Patrol()
    {
        if(transform.position.x >= patrolPointRightPos.x)
        {
            animator.SetTrigger("idle");
            destination.x = patrolPointLeftPos.x;
        }
        else if(transform.position.x <= patrolPointLeftPos.x)
        {
            animator.SetTrigger("idle");
            destination.x = patrolPointRightPos.x;
        }

        MoveTo(destination);
    }

    public void MoveTo(Vector3 destination)
    {
        transform.position = Vector3.MoveTowards(animator.transform.position, new Vector3(destination.x, animator.transform.position.y, 0), moveSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, attackRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, lookRange);
    }
}
