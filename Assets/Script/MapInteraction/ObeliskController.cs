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

//     private void OnCollsionEnter2D(Collision2D collision)
//     {
// Debug.Log("day la loi cua bao");
//         if (collision.gameObject.CompareTag("Fireball"))

//         {
            
//             anim.SetTrigger("isActivated");
//             anim.SetBool("isOperating", true);
//             obeliskOperating = true;
//         }
//     }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fireball"))

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
