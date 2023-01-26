using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBehaviour : MonoBehaviour
{
    HealthStats flowerHealth;
    Animator flowerAnim;
    bool _isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        flowerHealth = new HealthStats(50, 50);
        flowerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isDead)
        {
            Die();
        }

    }

    void TakeDamage(int dmg)
    {
        flowerHealth.DamageUnit(dmg);
    }

    bool IsDeadCheck()
    {
        if (flowerHealth.Health <= 0)
        {
            return true;
        }

        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fireball"))
        {
            TakeDamage(20);
            flowerAnim.SetTrigger("isHit");
            _isDead = IsDeadCheck();
            Debug.Log(flowerHealth.Health);
        }
    }

    void Die()
    {
        flowerAnim.SetBool("isDead", true);
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
