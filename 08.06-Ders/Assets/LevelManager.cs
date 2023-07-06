using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform playerSpawnerPos;
    // Start is called before the first frame update
    private void Awake()
    {
        PlayerSpawnerPos();
    }
    void PlayerSpawnerPos()
    {
        Instantiate(player, playerSpawnerPos.position, Quaternion.identity);
    }
    public void PlayerRespawner()
    {
        Instantiate(player, playerSpawnerPos.position, Quaternion.identity);
    }
}
