using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    private Rigidbody2D rb;
    private PlayerLives playerLives;
    private Delay delay;
    // Start is called before the first frame updates

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        delay = GameObject.Find("LevelManager").GetComponent<Delay>();
        playerLives = GameObject.Find("LevelManager").GetComponent<PlayerLives>();
    }
    private void FixedUpdate()
    {
        rb.velocity = -transform.right * bulletSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            playerLives.Lives();
            if (delay.delayTime == true)
            {
                delay.DelayStart();
            }
        }
    }

}