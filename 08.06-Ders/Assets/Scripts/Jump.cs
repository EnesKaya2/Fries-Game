using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    [SerializeField] private float jumpPower;
    [SerializeField] Transform feetPos;
    [SerializeField] float radius;
    public static int fallGravityScale;
    [SerializeField] private LayerMask layerMask;

    [SerializeField] float startJumpTime;
    [SerializeField] private float jumpTime;
    [SerializeField] private float secondJumpPower;
    [SerializeField] private bool isJumping;
    [SerializeField] private bool isDoubleJump;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        JumpAction();
        Gravity();
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(feetPos.position, radius, layerMask);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(feetPos.position, radius);
    }

    void Gravity()
    {
        if (rb.velocity.y > 0)
        {
            rb.gravityScale = 1;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallGravityScale;
        }
    }
    private void JumpAction()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded() && !PauseMenu.isPause && !Player.isDashing && !Player.isDead)
        {
            SoundManager.instance.PlaySound(10);
            animator.SetBool("Jump",true);
            isJumping = true;
            isDoubleJump = true;
            jumpTime = startJumpTime;
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
        else if (Input.GetButtonDown("Jump")&& isDoubleJump && !Player.isDead)
        {
            SoundManager.instance.PlaySound(10);
            rb.AddForce(Vector2.up * jumpPower*1.5f, ForceMode2D.Impulse);
            isDoubleJump = false;
        }

        if (Input.GetButton("Jump") && isJumping)
        {
            if (jumpTime > 0)
            {
                rb.AddForce(Vector2.up * secondJumpPower, ForceMode2D.Force);
                jumpTime -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Mathf.Approximately(rb.velocity.y,0) && animator.GetBool("Jump"))
        {
            animator.SetBool("Jump", false);
        }
                

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
    }


}
