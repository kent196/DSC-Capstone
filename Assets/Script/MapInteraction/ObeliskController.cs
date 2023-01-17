using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObeliskController : MonoBehaviour
{
    private Animator anim;

    [SerializeField] private bool obeliskOperating = false;

    private void Start()
    {
        anim = GetComponent<Animator>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("isActivated");
            anim.SetBool("isOperating", true);
            obeliskOperating = true;
        }
    }

    public bool getObeliskState()
    {
        return obeliskOperating;
    }
}
