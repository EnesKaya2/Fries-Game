using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float jumpPower;
    [SerializeField] Transform feetPos;
    [SerializeField] float radius;
    [SerializeField] public static int fallGravityScale;
    [SerializeField] LayerMask layerMask;

    [SerializeField] float startJumpTime;
    [SerializeField] private float jumpTime;
    [SerializeField] private bool isJumping;
    [SerializeField] float secondJumpPower;
    [SerializeField] bool isDoubleJump;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(IsGrounded());
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
        if (Input.GetButtonDown("Jump") && IsGrounded() && !PauseMenu.isPause && !Movement.isDashing)
        {
            SoundManager.instance.PlaySound(10);
            isDoubleJump = true;
            isJumping = true;
            jumpTime = startJumpTime;
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
        else if (Input.GetButtonDown("Jump") && isDoubleJump)
        {
            SoundManager.instance.PlaySound(10);
            rb.AddForce(Vector2.up * jumpPower*3, ForceMode2D.Impulse);
            isDoubleJump=false;
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

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
    }
}
