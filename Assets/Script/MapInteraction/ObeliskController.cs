using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObeliskController : MonoBehaviour
{
    private Animator anim;



    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Fireball"))

        {
            anim.SetTrigger("isActivated");
            anim.SetBool("isOperating", true);
        }
    }
}
