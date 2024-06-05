using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //TO: Make player movement, jump and have a collider.

    private float Horizontal;

    private bool isFacingRight = true;



    [SerializeField] float jumpingPower = 16f;
    [SerializeField] float speed = 8f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundLayer;

    //I wanna make some of the vars public so when I use power ups, they will be accessable and changed.
    private void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        Vector2 dir = new Vector2(Horizontal * speed, rb.velocity.y);

        rb.AddForce(dir, ForceMode2D.Force);

        Vector2 curVel = rb.velocity;
        curVel.x = Mathf.Clamp(curVel.x, -7, 7);

        rb.velocity = curVel;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.2f, GroundLayer);
    }

    private void Flip()
    {
        if(isFacingRight && Horizontal < 0f || !isFacingRight && Horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
