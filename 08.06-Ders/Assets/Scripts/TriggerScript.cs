using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    [SerializeField] bool moveEnemy;
    [SerializeField] GameObject enemy;
    [SerializeField] Transform spawnPos;

    private void MoveEnemy()
    {
        Instantiate(enemy, spawnPos.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MoveEnemy();
            SoundManager.instance.PlaySound(0);
        }
    }
}
