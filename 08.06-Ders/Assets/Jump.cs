using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float jumpPower;
    [SerializeField] Transform feetPos;
    [SerializeField] float radius;
    [SerializeField] int fallGravityScale;
    [SerializeField] LayerMask layerMask;
    private SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(IsGrounded());

        if (Input.GetButtonDown("Jump") && IsGrounded()&&!PauseMenu.isPause)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            soundManager.JumpSound();
        }
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
}
