using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunMeleePatrol : MonoBehaviour
{

    public AudioSource atkSFX;
    [SerializeField] private Transform[] patrolPoints;

    [SerializeField] private GameObject viewPoint;
    [SerializeField] private Transform playerTransform;

    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private LayerMask visibilityLayer;

    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float detectionRange = 10f;

    PlayerBehaviour playerBehaviour;
    Rigidbody2D rb;
    Animator anim;

    private float attackRange = 3f;
    private int patrolDestination = 0;
    private float attackCooldown;
    private Vector2 lookDirection;
    private Vector2 attackDirection;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerBehaviour = FindObjectOfType<PlayerBehaviour>();
        attackCooldown = 0f;
        lookDirection = transform.right.normalized;
        atkSFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!PlayerDetection())
        {
            anim.SetBool("isAttacking", false);
            anim.SetBool("isPatrol", true);
            Patrol();
        }
        else
        {
            attackDirection = (playerTransform.position - transform.position).normalized;
            if (!PlayerInRange())
            {
                anim.SetBool("isAttacking", false);
                anim.SetBool("isPatrol", true);
                ChasePlayer();
            }
            else
            {
                rb.velocity = Vector2.zero;
                anim.SetBool("isPatrol", false);
                if (attackCooldown > 0)
                {
                    anim.SetBool("isAttacking", false);
                    attackCooldown -= Time.deltaTime;
                }
                if (attackCooldown <= 0)
                {
                    anim.SetBool("isAttacking", true);

                    attackCooldown = 2f;
                }

            }
        }
    }
    private void Moving()
    {
        if (IsFacingRight())
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
    }

    private bool PlayerDetection()
    {
        RaycastHit2D hit = Physics2D.Raycast(viewPoint.transform.position, lookDirection, detectionRange, visibilityLayer);
        if (hit.collider != null)
        {
            return (playerLayer & (1 << hit.collider.gameObject.layer)) != 0;
        }
        return false;
    }

    private bool PlayerInRange()
    {
        return Physics2D.Raycast(viewPoint.transform.position, attackDirection, attackRange, visibilityLayer);
    }

    private void ChasePlayer()
    {
        FindDestination(playerTransform.position.x);
        Moving();
    }

    private void Patrol()
    {
        FindDestination(patrolPoints[patrolDestination].position.x);

        if (Vector2.Distance(transform.position, patrolPoints[patrolDestination].transform.position) < .2f)
        {
            patrolDestination++;
            if (patrolDestination >= patrolPoints.Length)
            {
                patrolDestination = 0;
            }
        }

        Moving();
    }

    private void FindDestination(float destination)
    {
        if (destination > transform.position.x)
        {
            if (IsFacingRight() == false)
            {
                ChangeDirection();
            }
        }

        if (destination < transform.position.x)
        {
            if (IsFacingRight() == true)
            {
                ChangeDirection();
            }
        }
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void ChangeDirection()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(transform.localScale.x)), transform.localScale.y);
        lookDirection = -lookDirection;
    }

    private void DealDamage()
    {
        atkSFX.Play();
        playerBehaviour.TakeDamage(50);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

    }
}