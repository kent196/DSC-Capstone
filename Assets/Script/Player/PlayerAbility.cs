using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform rotatePoint;
    private PlayerBehaviour playerBehaviour;

    private Vector2 aimLineStart;
    private Vector2 aimLineEnd;
    private Vector2 rotatePosition;
    private Vector2 mousePosition;
    private Vector2 fireDirection;

    private float angle;
    private float launchForce = 10f;
    private float attackTimer;

    private LineRenderer lr;


    // Start is called before the first frame update
    void Start()
    {
        playerBehaviour = FindObjectOfType<PlayerBehaviour>();
        lr = GetComponent<LineRenderer>();
        attackTimer = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {

        attackTimer -= Time.deltaTime;
        GetDirection();
        if (attackTimer < .1f)
        {
            RangeAttack();

        }
    }
    void GetDirection()
    {

        rotatePosition = rotatePoint.position;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        fireDirection = mousePosition - rotatePosition;
        fireDirection.Normalize();

        angle = Mathf.Atan2(fireDirection.y, fireDirection.x) * Mathf.Rad2Deg;
        rotatePoint.rotation = Quaternion.Euler(0, 0, angle);
    }
    void RangeAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lr.enabled = true;
        }
        if (Input.GetMouseButton(0))
        {
            lr.enabled = true;
            aimLineStart = rotatePoint.position;
            lr.SetPosition(0, aimLineStart);
            aimLineEnd = rotatePoint.Find("Fire point").position;
            lr.SetPosition(1, aimLineEnd);
        }

        if (Input.GetMouseButtonUp(0))
        {
            //Mouse up, launch
            LaunchProjectile();
            lr.enabled = false;
        }
    }
    void LaunchProjectile()
    {
        if (attackTimer < .1f)
        {
            playerBehaviour.TakeDamage(5);
            GameObject newProjectile = Instantiate(projectile, rotatePoint.Find("Fire point").position, rotatePoint.rotation);
            newProjectile.GetComponent<Rigidbody2D>().velocity = rotatePoint.Find("Fire point").right * launchForce;
            attackTimer = 1f;
        }
    }
}
