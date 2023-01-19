using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObeliskController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Fireball"))

        {
            anim.SetTrigger("isActivated");
            anim.SetBool("isOperating", true);
        }
    }
}
