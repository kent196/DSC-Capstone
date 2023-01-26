using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Destroy : MonoBehaviour
{

    [SerializeField] private float speed = 50f;
    [SerializeField] private float maxRange = 2f;
    private float distanceTraveled = 0f;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }

    void Update()
    {
        DestroyOnShoot();
    }

    public void DestroyOnShoot()
    {
        distanceTraveled += Time.deltaTime * speed;

        if (distanceTraveled >= maxRange)
        {
            Destroy(gameObject);
        }
    }
}
