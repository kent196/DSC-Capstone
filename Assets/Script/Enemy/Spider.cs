using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Vector3 lookRange = new Vector3(10f, 2f, 1f);
    [SerializeField] private Vector3 attackRange = new Vector3(5f, 2f, 1f);
    private Vector3 spiderPos;
    private Vector3 homePos;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        homePos = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        spiderPos = transform.position;

        if(isPlayerInLookZone())
        {
            animator.SetTrigger("active");
        }
        else 
        {
            animator.SetTrigger("unactive");
        }
    }

    public bool isPlayerInLookZone()
    {
        RaycastHit2D hitInfo = Physics2D.BoxCast(homePos, lookRange, 0 , Vector2.left, 10f, playerLayer);
        if(hitInfo)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }

    public bool isPlayerInAttackZone()
    {
        RaycastHit2D hitInfo = Physics2D.BoxCast(spiderPos, attackRange, 0 , Vector2.left, 10f, playerLayer);
        if(hitInfo)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(homePos, lookRange);

        
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(spiderPos, attackRange);
    }
    
}
