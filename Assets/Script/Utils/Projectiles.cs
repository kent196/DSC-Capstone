using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool hasHit;
    public Animator anim;
    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
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
        if (this.CompareTag("Fireball"))
        {
            anim.Play("Explode");
        }

        audioManager.Play("Bullet Explode");
        hasHit = true;          
        DestroyAnimation();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy();
        hasHit = true;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void DestroyAnimation()
    {
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
        this.GetComponent<Collider2D>().isTrigger = true;
    }

}
