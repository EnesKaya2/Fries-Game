using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private float speed;
    [SerializeField] private float horizontalMove;
    [SerializeField] private float playerYBoundry;
    private SoundManager soundManager;
    private Delay delay;
    private UiManager uiManager;
    private PlayerLives playerLive;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
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
    }
    void PlayerMovement()
    {
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
            soundManager.DeadSound();
            if (delay.delayTime==true)
            {
                delay.DelayStart();
            }
           
        }
    }
}
