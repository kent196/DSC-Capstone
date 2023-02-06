using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Component
    private Rigidbody2D playerRb;

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float acceleration = 7f;
    [SerializeField] float deceleration = 7f;
    [SerializeField] float velPower = 0.9f;
    [SerializeField] float frictionAmount = 0.2f;
    private float moveX;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float dashSpeed = 20f;
    [SerializeField] private float dashTime = 1f;
    private float currentDashTime;
    [SerializeField] private Vector3 checkGroundRaySize = new Vector3(2, 1, 0);

    [SerializeField] private Vector3 offset;

    private CircleCollider2D coll;
    private bool canDash = true;
    [SerializeField] private GameObject dashHit;
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CircleCollider2D>();

        canDash = true;
    }
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            Jump();
        }

        if(canDash && Input.GetMouseButtonDown(1))
        {
            StartCoroutine(Dash());
        }
        
    }

    void FixedUpdate()
    {
        if(!isGrounded())
        {
            return;
        }
        #region Run
        float targetSpeed = moveX * moveSpeed;
        float speedDif = targetSpeed - playerRb.velocity.x;
        float accelerate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : deceleration;
        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelerate, velPower) * Mathf.Sign(speedDif);
        playerRb.AddForce(movement * Vector2.right);
        #endregion

        #region Friction
        float amount = Mathf.Min(Mathf.Abs(playerRb.velocity.x), Mathf.Abs(frictionAmount));
        amount *= Mathf.Sign(playerRb.velocity.x);
        playerRb.AddForce(Vector2.right * -amount, ForceMode2D.Impulse);
        #endregion
    }

    bool isGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.CircleCast(coll.bounds.center, coll.radius, Vector2.down, coll.radius);

        if(hitInfo)
        {
            if(hitInfo.transform.position.y <= transform.position.y)
            {
                return true;
            } 
        }

        return false;
    }

    private void Jump()
    {
        playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private IEnumerator Dash()
    {
        GetComponent<PlayerBehaviour>().TakeDamage(100);

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dashDirection = transform.position.x - mousePos.x >= 0 ? Vector2.left : Vector2.right;
    
        playerRb.velocity = dashDirection * dashSpeed;
        Physics2D.IgnoreLayerCollision(10, 11, true);
        dashHit.SetActive(true);
        canDash = false;

        
        yield return new WaitForSeconds(dashTime/2);

        Physics2D.IgnoreLayerCollision(10, 11, false);
        dashHit.SetActive(false);

        yield return new WaitForSeconds(dashTime/2);
        canDash = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Spider>().TakeDamage(50);
        }
    }
}
