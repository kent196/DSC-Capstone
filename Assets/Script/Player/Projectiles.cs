using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool hasHit;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        TrackDirection();
    }
    void TrackDirection()
    {
        if (hasHit == false)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != 9 && this.CompareTag("Fireball"))
        {
            hasHit = true;

            anim.Play("Explode");

            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
            this.GetComponent<Collider2D>().isTrigger = true;
            Destroy(gameObject, 1f);
        }
        else if (collision.gameObject.layer != 9)
        {
            hasHit = true;
            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
            this.GetComponent<Collider2D>().isTrigger = true;
            Destroy(gameObject, 1f);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Spider>().TakeDamage(10);
        }
    }



}
