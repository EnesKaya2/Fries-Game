using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    [SerializeField] bool moveEnemy;
    [SerializeField] GameObject enemy;
    [SerializeField] Transform spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void MoveEnemy()
    {
        Instantiate(enemy,spawnPos.position,Quaternion.identity);
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MoveEnemy();
        }
    }

}
