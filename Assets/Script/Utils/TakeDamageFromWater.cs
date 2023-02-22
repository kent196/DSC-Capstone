using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageFromWater : MonoBehaviour
{
    bool isTouchingWater = false;
    private PlayerBehaviour playerBehaviour;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerBehaviour = other.GetComponent<PlayerBehaviour>();
            isTouchingWater = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Water");
            playerBehaviour = other.GetComponent<PlayerBehaviour>();
            isTouchingWater = false;
        }
    }

    void Update()
    {
        if (isTouchingWater)
        {       
            StartCoroutine(TakeDamageCO());
        }
    }

    IEnumerator TakeDamageCO()
    {
        if (playerBehaviour != null)
        {
            playerBehaviour.TakeDamage(10);
            yield return new WaitForSeconds(1f);
        }

    }
}
