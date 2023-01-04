using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpiderState
{
    unactive,
    active,
    idle,
    walk,
    attack,
    death,
    hit, 
    crawl
}

public class Spider : Enemy
{
    //Component
    private Animator animator;
    private Rigidbody2D rb;

    //Public parameter
    [SerializeField] private float enemyZoneRange = 20f;
    [SerializeField] private float lookRange = 10f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float rayHeight = -0.7f;
    [SerializeField] private LayerMask colliderLayer;
    [SerializeField] private GameObject attackEffect;

    //Private parameter
    private SpiderState state;
    private Vector3 homePos;
    private Vector3 rayEnemyZoneOffset;
    private Vector3 rayLookOffset;
    private Vector3 rayAttackOffset;

    //Debugging purpose

    private float distanceToDestination;

    void Awake()
    {
        //Get Component
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        //Set Active
        attackEffect.SetActive(false);

        //Debugging purpose
        rayLookOffset = new Vector3(lookRange/2, rayHeight, 0);
        rayAttackOffset = new Vector3(attackRange/2, rayHeight, 0);

        //Initiation value
        state = SpiderState.unactive;
        homePos = transform.position;

        //Initiation Animator Parameter
        animator.SetBool("isActive", false);
        
        //Get Component
        rb = GetComponent<Rigidbody2D>();
    }

    bool isPlayerInEnemyZone()
    {
        //Create a Raycast
        RaycastHit2D lookInfo = Physics2D.Raycast(homePos + rayLookOffset, Vector3.left * lookRange , lookRange, colliderLayer);

        //If raycast hit player
        if(lookInfo)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool isPlayerInLookZone()
    {
        //Create a Raycast
        RaycastHit2D lookInfo = Physics2D.Raycast(transform.position + rayLookOffset, Vector3.left * lookRange , lookRange, colliderLayer);

        //If raycast hit player
        if(lookInfo)
        {
            return true;
        }
        //If ray cast not hit player
        else
        {
            return false;
        }
    }

    bool isPlayerInAttackZone()
    {
        //Create a Raycast
        RaycastHit2D attackInfo = Physics2D.Raycast(transform.position + rayAttackOffset, Vector3.left * attackRange , attackRange, colliderLayer);

        if(attackInfo)
        {
            //Stop spider's movement
            rb.velocity = Vector2.zero;

            //Change state
            state = SpiderState.attack;

            //Set animation
            animator.SetBool("isAttacking", true);

            return true;
        }
        else
        {
            return false;
        }
    }

    void DebugRays()
    {
        //Display the Raycast on Scene when play
        Debug.DrawRay(transform.position + rayLookOffset, Vector3.left * lookRange, Color.white);

        //Display the attack Range
        Debug.DrawRay(transform.position + rayAttackOffset, Vector3.left * attackRange, Color.yellow);
    }

    public void SetStateTo(SpiderState stateToSet)
    {
        state = stateToSet;
    }

    public void EndOfActiveAnimation()
    {
        //Use as animation's event
        //At the end of active animation, decide the state should be walk or attack base on distance to player
        if(Mathf.Abs(distanceToDestination) >= attackRange/2)
        {
            state = SpiderState.walk;
        }
        else 
        {
            state = SpiderState.attack;
        }
    }
}
