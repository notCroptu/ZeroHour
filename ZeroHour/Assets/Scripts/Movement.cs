using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    public Sprite idle;
    public Sprite grab;
    public BoxCollider2D groundCheckCollider;
    public BoxCollider2D wallCheckCollider;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float horizontalInput;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        isGrounded = IsGrounded();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        if (!IsWalled() && isGrounded)
        {
            sr.sprite = grab;
        }
        else
        {
            sr.sprite = idle;
        }

        if (horizontalInput < 0 && transform.right.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (horizontalInput > 0 && transform.right.x < 0)
        {
            transform.rotation = Quaternion.identity;
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    bool IsGrounded()
    {
        return Physics2D.IsTouchingLayers(groundCheckCollider, groundLayer);
    }

    bool IsWalled()
    {
        return Physics2D.IsTouchingLayers(wallCheckCollider, wallLayer);
    }

    void Move()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
