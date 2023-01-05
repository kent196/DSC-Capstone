using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerAttack : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject rotatePoint;
    [SerializeField] private GameObject firePoint;

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

        float angle = Mathf.Atan2(Vo.y, Vo.x) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, 0, 90);
        rotatePoint.transform.rotation = Quaternion.LookRotation(Vector3.forward, Vo);
        rotatePoint.transform.rotation = Quaternion.Euler(0, 0, angle);

        if (attackCooldown < .1f)
        {
            LaunchProjectile(Vo);
            attackCooldown = 1f;
        }
    }
    Vector2 CalculateVelocity(Vector2 target, Vector2 origin, float time)
    {
        //get distance 
        Vector2 distance = target - origin ;
        Vector2 distance_x = distance;
        distance_x.Normalize();
        distance_x.y = 0f;

        //get distance value in x and y
        float Sy = distance.y;
        float Sx = distance.magnitude;

        float Vx = Sx / time;
        float Vy = Sy / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        //get the result vector;
        Vector2 result = distance_x * Vx;
        result.y = Vy;

        return result;
    }
    void LaunchProjectile(Vector2 Vo)
    {
        GameObject newProjectile = Instantiate(projectile, firePoint.transform.position, Quaternion.identity);
        newProjectile.GetComponent<Rigidbody2D>().velocity = Vo ;
    }
}
