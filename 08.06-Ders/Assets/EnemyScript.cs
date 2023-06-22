using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float enemySpeed;
    [SerializeField] private float leftBoundry;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over...");

        }
    }
}
