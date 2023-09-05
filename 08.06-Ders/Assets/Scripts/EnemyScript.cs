using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float enemySpeed;
    [SerializeField] private float leftBoundry;
    [SerializeField] SpriteRenderer spriteRenderer;
    private LevelManager levelManager;
    private PlayerLifes playerLifes;
    private Delay delay;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white;
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        delay = GameObject.Find("LevelManager").GetComponent<Delay>();
        playerLifes = GameObject.Find("LevelManager").GetComponent<PlayerLifes>();
    }
    
    void Update()
    {
        MoveEnemy();
        DestroyEnemy();
    }
    void MoveEnemy()
    {
        rb.velocity = Vector2.left * enemySpeed;
    }
    void DestroyEnemy()
    {
        if (transform.position.x < leftBoundry)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.instance.PlaySound(3);
            Destroy(collision.gameObject);
            playerLifes.Lifes();

            if (delay.delayTime==true)
            {
                delay.DelayStart();
            }
        }
    }
}
