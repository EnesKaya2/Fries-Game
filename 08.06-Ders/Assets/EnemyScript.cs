using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float enemySpeed;
    [SerializeField] private float leftBoundry;
    private LevelManager levelManager;
    private Delay delay;
    private UiManager uiManager;
    private PlayerLives playerLives;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        delay = GameObject.Find("LevelManager").GetComponent<Delay>();
        uiManager = GameObject.Find("UiManager").GetComponent<UiManager>();
        playerLives = GameObject.Find("LevelManager").GetComponent<PlayerLives>();

    }
    // Update is called once per frame
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
        //if (collision.gameObject.CompareTag("Player"))
        //{
        //    Debug.Log("Game Over...");

        //}
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.instance.PlaySound(3);
            Destroy(collision.gameObject);
            //Direk Canvas 
            //uiManager.GetComponent<Canvas>().enabled = true;
            playerLives.Lives();
            if (delay.delayTime==true)
            {
                delay.DelayStart();
            }
        }
        
    }
}