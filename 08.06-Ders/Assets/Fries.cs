using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fries : MonoBehaviour
{
    public LevelManager levelManager;
    private int friesValue;
    private void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        friesValue = Random.Range(1, 30);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ScoreManager.score += friesValue;
            Destroy(gameObject);
            levelManager.count++;
            levelManager.spawnFries();
        }
    }
}
