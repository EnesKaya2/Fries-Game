using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fries : MonoBehaviour
{
    private LevelManager levelManager;
    private int friesValue;

    private void Start()
    {
        SoundManager.instance.PlaySound(8);
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        friesValue = Random.Range(1, 30);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.AddPoint(friesValue);
            SoundManager.instance.PlaySound(7);
            Destroy(gameObject);
            levelManager.count++;
            levelManager.FriesSpawner();


        }
    }
}
