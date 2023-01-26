using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun_Shoot : MonoBehaviour
{
    public GameObject shotgunPrefab;
    public float chargeTime = 1f;
    [SerializeField] private int numberOfBullets = 5;
    [SerializeField] private float spreadAngle = 10f;
    private float currentChargeTime = 0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();

        }
    }

    public void Shoot()
    {
        currentChargeTime += Time.deltaTime;

        if (currentChargeTime >= chargeTime)
        {
            currentChargeTime = 0f;
            for (int i = 0; i < numberOfBullets; i++)
            {
                GameObject bullet = Instantiate(shotgunPrefab, transform.position, transform.rotation);
                float randomAngle = Random.Range(-spreadAngle / 2f, spreadAngle / 2f);
                bullet.transform.Rotate(0f, 0f, randomAngle);
            }
        }
    }
}
