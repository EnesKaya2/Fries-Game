using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Knife : MonoBehaviour
{

    private PlayerLifes playerLifes;
    private Delay delay;
    private LevelManager levelManager;

    [SerializeField] private float turnSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float destroyLimit;
    private float difficultyValue = 3f;

    [SerializeField] ParticleSystem knifeParticle;

    private Rigidbody2D rb;

    private void Awake()
    {
        playerLifes = GameObject.Find("LevelManager").GetComponent<PlayerLifes>();
        delay = GameObject.Find("LevelManager").GetComponent<Delay>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        HardenedLevel();
    }
    private void Update()
    {
        if (transform.position.x < destroyLimit || levelManager.win)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        transform.Rotate(-transform.right * turnSpeed);
        rb.velocity = Vector2.left * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.instance.PlaySound(11);
            collision.gameObject.GetComponent<Player>().DieAnimation();
            Instantiate(knifeParticle, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }

    private void HardenedLevel()
    {
        if (PlayerPrefs.HasKey("Easy Mode"))
        {
            moveSpeed -= difficultyValue;
        }
        if (PlayerPrefs.HasKey("Normal Mode"))
        {
            moveSpeed = moveSpeed;
        }
        if (PlayerPrefs.HasKey("Hard Mode"))
        {
            moveSpeed += difficultyValue;
        }
    }
}
