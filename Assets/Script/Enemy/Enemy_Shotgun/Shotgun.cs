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
    [SerializeField] public Vector2 attackRantge;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        homePos = transform.position.x;

        patrolPointRightPos = patrolPointRight.position;
        patrolPointLeftPos = patrolPointLeft.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float distanceToHomePos()
    {
        return transform.position.x - homePos;
    }

    public bool isReachDestination()
    {
        if(transform.position.x >= patrolPointRightPos.x)
        {
            destination.x = patrolPointLeftPos.x;
            return true;
        }
        else if(transform.position.x <= patrolPointLeftPos.x)
        {
            destination.x = patrolPointRightPos.x;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, attackRantge);
    }
}
