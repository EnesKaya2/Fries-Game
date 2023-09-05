using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    private Rigidbody2D rb;
    private PlayerLifes playerLifes;
    private Delay delay;
    [SerializeField] ParticleSystem bulletParticle;

    [SerializeField] float leftBoundry;
    [SerializeField] float rightBoundry;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        delay = GameObject.Find("LevelManager").GetComponent<Delay>();
        playerLifes = GameObject.Find("LevelManager").GetComponent<PlayerLifes>();
    }

    private void FixedUpdate()
    {
        rb.velocity = -transform.right * bulletSpeed;
        Boundry();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);


        if (collision.gameObject.CompareTag("Ground"))
        { 
        Instantiate(bulletParticle,gameObject.transform.position,Quaternion.identity);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.instance.PlaySound(5);
            Destroy(collision.gameObject);
            playerLifes.Lifes();

            if (delay.delayTime == true)
            {
                delay.DelayStart();
            }
        }
    }

    private void Boundry()
    {
        if (transform.position.x < leftBoundry)
        {
            Destroy(gameObject);
        }

        if (transform.position.x > rightBoundry)
        {
            Destroy(gameObject);
        }
    }
}
