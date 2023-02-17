using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : EnemyBehavior
{
    [SerializeField] public float attackRadius;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
