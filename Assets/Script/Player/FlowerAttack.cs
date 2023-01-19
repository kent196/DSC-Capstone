using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerAttack : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject rotatePoint;
    [SerializeField] private GameObject firePoint;

    float projectileForce = 10f;
    private float attackCooldown = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        attackCooldown -= Time.deltaTime;
        AimAndAttack();
    }
    void AimAndAttack()
    {
        Vector2 Vo = CalculateVelocity(player.transform.position, transform.position, 1f);

        //float angle = Mathf.Atan2(Vo.y, Vo.x) * Mathf.Rad2Deg;
        //angle = Mathf.Clamp(angle, 0, 90);
        rotatePoint.transform.rotation = Quaternion.LookRotation(Vector3.forward, Vo);
        //rotatePoint.transform.rotation = Quaternion.Euler(0, 0, angle);

        if (attackCooldown < .1f)
        {
            LaunchProjectile();
            attackCooldown = 1f;
        }
    }
    Vector2 CalculateVelocity(Vector2 target, Vector2 origin, float force)
    {
        //get distance 
        Vector2 distance = target - origin;

        //get distance value in x and y
        float Sy = distance.y;
        distance.y = 0f;
        float Sx = distance.magnitude;

        float t = Sx / force;
        float v = Sy / t + 0.5f * Mathf.Abs(Physics2D.gravity.y) * t;

        //get the result vector;

        return distance.normalized * force + Vector2.up * v;
    }
    void LaunchProjectile()
    {
        GameObject newProjectile = Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
        newProjectile.GetComponent<Rigidbody2D>().AddForce(CalculateVelocity(player.transform.position, firePoint.transform.position, projectileForce), ForceMode2D.Impulse);
    }
}
