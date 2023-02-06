using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_Knockback : MonoBehaviour
{
    [SerializeField] private float force = 10f;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 10)
        {
            Rigidbody2D playerRb = other.gameObject.GetComponent<Rigidbody2D>();
            float direction = (playerRb.transform.position.x - this.transform.position.x) > 0 ? 1 : -1;

            playerRb.AddForce(Vector2.left * force * direction, ForceMode2D.Impulse);
        }
    }

}
