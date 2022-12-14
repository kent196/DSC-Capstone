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
        #region Run
        float targetSpeed = moveX * moveSpeed;
        float speedDif = targetSpeed - playerRb.velocity.x;
        float accelerate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration: deceleration;
        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelerate, velPower) * Mathf.Sign(speedDif);
        playerRb.AddForce(movement * Vector2.right);
        #endregion

        #region Friction
        float amount = Mathf.Min(Mathf.Abs(playerRb.velocity.x), Mathf.Abs(frictionAmount));
        amount *= Mathf.Sign(playerRb.velocity.x);
        playerRb.AddForce(Vector2.right * -amount, ForceMode2D.Impulse);
        #endregion
    }

}
