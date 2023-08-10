using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private TrailRenderer trailRenderer;

    [SerializeField] private float speed;
    [SerializeField] private float horizontalMove;
    [SerializeField] private float playerYBoundry;

    private Delay delay;
    private UiManager uiManager;
    private PlayerLives playerLive;

    #region DashRegion
    public static bool canDash = true;
    public static bool isDashing;
    public static bool dashed;
    [SerializeField] float dashAmount = 20f;
    [SerializeField] float dashTime = 0.3f;
    public static float dashCoolDown = 1f;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        trailRenderer = GetComponent<TrailRenderer>();
        Cancel();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        delay = GameObject.Find("LevelManager").GetComponent<Delay>();
        uiManager = GameObject.Find("UiManager").GetComponent<UiManager>();
        playerLive = GameObject.Find("LevelManager").GetComponent<PlayerLives>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        CharacterFlip();
        PlayerDeath();

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && horizontalMove != 0)
        {
            StartCoroutine(Dash());
        }
    }
    void PlayerMovement()
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
            //uiManager.GetComponent<Canvas>().enabled = true;
            playerLive.Lives();
            SoundManager.instance.PlaySound(4);
            if (delay.delayTime == true)
            {
                delay.DelayStart();
            }

        }
    }
    private IEnumerator Dash()
    {
        Debug.Log("Dashing...");
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
        yield return new WaitForSeconds(dashCoolDown);
        dashed = false;
        Debug.Log("Can Dash");
        canDash = true;
    }
    private void Cancel()
    {
        isDashing = false;
        canDash = true;
        dashed=false;
        rb.gravityScale = 5f;
        Jump.fallGravityScale = 15;
    }
}
