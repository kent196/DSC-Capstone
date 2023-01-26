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

    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Vector3 checkGroundRaySize = new Vector3(2, 1, 0);

    [SerializeField] private Vector3 offset;
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        moveX = Input.GetAxisRaw("Horizontal");

    }

    void FixedUpdate()
    {
        if (!isGrounded())
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
        RaycastHit2D hitInfo = Physics2D.BoxCast(transform.position + offset, checkGroundRaySize, 0f, Vector2.left, 0f, playerLayer);

        if (hitInfo)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(transform.position + offset, checkGroundRaySize);

    }
}
