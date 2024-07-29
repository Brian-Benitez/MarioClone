using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Info")]
    public int PlayersLives = 3;

    [Header("Transform")]
    public Transform SpawnPoint;

    private float Horizontal;

    private bool isFacingRight = true;
    [Header("Player Movement")]
    [SerializeField] public float jumpingPower = 16f;
    [SerializeField] float speed = 8f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundLayer;

    private void Start()
    {
        GetComponent<OutOfBoundsController>().OutOfBoundEvent = () => this.transform.position = SpawnPoint.transform.position;
        GetComponent<OutOfBoundsController>().OutOfBoundEvent += CheckOnPlayersHealth;
    }
    //When the player hits a box, see if it has the component of power up, if you do play the function.
    private void OnCollisonEnter2D(Collider2D collision)
    {
        Debug.Log("hahaha");
        if (collision.gameObject.TryGetComponent<IPowerUp>(out IPowerUp powerUp))
            powerUp.PowerUp();//Need to test this
    }

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

    private void CheckOnPlayersHealth()
    {
        if(PlayersLives <= 0)
            this.gameObject.SetActive(false);
        return;

    }
}
