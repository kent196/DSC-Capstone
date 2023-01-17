using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerHealController : MonoBehaviour
{
    private Animator anim;
    public ParticleSystem smoke;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        smoke = GetComponent<ParticleSystem>();
        smoke = FindObjectOfType<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("isUsed", true);
            if (!smoke.isPlaying)
                smoke.Play();
            Destroy(gameObject, 1f);

        }
    }

}
