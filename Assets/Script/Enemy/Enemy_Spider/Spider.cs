using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : EnemyBehavior
{
    [SerializeField] public float moveSpeed = 10f;
    [SerializeField] public Vector3 lookRange = new Vector3(10f, 2f, 1f);
    [HideInInspector] public Vector3 currentLookRange;
    [SerializeField] public Vector3 attackRange = new Vector3(5f, 2f, 1f);
    [SerializeField] public float homeMaxDistance = 20f;
    [HideInInspector] public Vector3 homePos;

    // Start is called before the first frame update
    void Start()
    {
        currentLookRange = lookRange;
        homePos = transform.position;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, currentLookRange);

        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(transform.position, attackRange);
    }
}