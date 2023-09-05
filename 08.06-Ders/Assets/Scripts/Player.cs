using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private TrailRenderer trailRenderer;

    private LevelManager levelManager;
    private PlayerLifes playerLifes;
    private Delay delay;
    [SerializeField] private float horizontalMove;
    [SerializeField] private float speed;
    [SerializeField] private float playerYBoundry;



    #region DashRegion
    public static bool canDash = true;
    public static bool isDashing;
    public static bool dashed;

    [SerializeField] float dashAmount = 20f;
    [SerializeField] float dashTime = 0.3f;
    public static float dashCooldown = 1f;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        trailRenderer = GetComponent<TrailRenderer>();
        Cancel();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        playerLifes = GameObject.Find("LevelManager").GetComponent<PlayerLifes>();
        delay = GameObject.Find("LevelManager").GetComponent<Delay>();
    }

    void Update()
    {

        Movement();

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && horizontalMove != 0)
        {
            StartCoroutine(Dash());
        }

        CharacterFlip();
        PlayerDeath();
    }

    private void Movement()
    {
        if (isDashing)
        {
            return;
        }
        horizontalMove = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
    }
    void CharacterFlip()
    {
        if (horizontalMove > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontalMove < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    void PlayerDeath()
    {
        if (transform.position.y < playerYBoundry)
        {
            Destroy(gameObject);
            playerLifes.Lifes();
            SoundManager.instance.PlaySound(4);

            if (delay.delayTime == true)
            {
                delay.DelayStart();

            }
        }
    }

    private IEnumerator Dash()
    {
        SoundManager.instance.PlaySound(2);
        trailRenderer.emitting = true;
        canDash = false;
        isDashing = true;
        rb.gravityScale = 0;
        Jump.fallGravityScale = 0;
        rb.velocity = new Vector2(horizontalMove * dashAmount, 0f);
        yield return new WaitForSeconds(dashTime);
        rb.gravityScale = 5f;
        Jump.fallGravityScale = 15;
        isDashing = false;
        trailRenderer.emitting = false;
        dashed = true;
        yield return new WaitForSeconds(dashCooldown);
        dashed = false;
        canDash = true;
    }

    private void Cancel()
    {
        isDashing = false;
        canDash = true;
        dashed = false;
        rb.gravityScale = 5f;
        Jump.fallGravityScale = 15;
    }


}
