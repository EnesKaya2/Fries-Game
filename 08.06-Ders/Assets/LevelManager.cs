using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform playerSpawnerPos;
    [SerializeField] GameObject friesPrefab;
    // Start is called before the first frame update
    private void Awake()
    {
        PlayerSpawnerPos();
        spawnFries();
    }
    void PlayerSpawnerPos()
    {
        Instantiate(player, playerSpawnerPos.position, Quaternion.identity);
    }
    public void PlayerRespawner()
    {
        Instantiate(player, playerSpawnerPos.position, Quaternion.identity);
    }
    public void spawnFries()
    {
        Vector3 spamPos = new Vector3(Random.Range(-8, 8), Random.Range(-3.5f, 3.5f), 0);
        if (!Physics2D.OverlapCircle(spamPos, 0.2f))
        {
            Instantiate(friesPrefab, spamPos, Quaternion.identity);
        }
        else
        {
            spawnFries();
        }
    }
}
