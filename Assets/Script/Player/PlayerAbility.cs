using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    [SerializeField] private Transform meeleAttackPoint;
    [SerializeField] private GameObject projectile;
    [SerializeField] private LayerMask enemyLayers;

    private Collider2D[] hitEnemies;
    private float meeleAttackRange;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

/*    void MeeleAttack()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            hitEnemies = Physics2D.OverlapCircleAll(meeleAttackPoint.position,meeleAttackRange,enemyLayers);
            foreach(Collider2D enemy in hitEnemies)
            {
                Debug.Log("enemy take damage method");
            }
        }
    }*/

    void RangeAttack()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Instantiate(projectile,transform.position,transform.rotation);
        }
    }
}
