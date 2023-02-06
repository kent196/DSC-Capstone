using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : EnemyBehavior
{
    [SerializeField] public float moveSpeed = 10f;
    [SerializeField] public LayerMask playerLayer;
    [SerializeField] public Vector3 lookRange = new Vector3(10f, 2f, 1f);
    [HideInInspector] public Vector3 currentLookRange;
    [SerializeField] private Vector3 attackRange = new Vector3(5f, 2f, 1f);
    [SerializeField] public float homeMaxDistance = 20f;
    private Vector3 spiderPos;
    [HideInInspector] public Vector3 homePos;
    [HideInInspector] public Vector3 playerPos;
    [HideInInspector] public GameObject player;
    public GameObject attackEffect;

    // Start is called before the first frame update
    void Start()
    {
        currentLookRange = lookRange;
        homePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        spiderPos = transform.position;
    }

    public bool isPlayerInLookZone()
    {
        Collider2D hitInfo = Physics2D.OverlapBox(spiderPos, currentLookRange, 0f, playerLayer);
        if(hitInfo)
        {
            player = hitInfo.transform.gameObject;
            playerPos = player.transform.position;
            return true;
        }
        else 
        {
            player = null;
            return false;
        }
    }

    public bool isPlayerInAttackZone()
    {
        Collider2D hitInfo = Physics2D.OverlapBox(spiderPos, attackRange, 0f, playerLayer);
        if(hitInfo)
        {
            player = hitInfo.transform.gameObject;
            playerPos = player.transform.position;
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
        Gizmos.DrawWireCube(spiderPos, currentLookRange);

        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(spiderPos, attackRange);
    }

    public void FlipSpiderTo(Vector3 destination)
    {
        if(spiderPos.x <= destination.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
    }
}