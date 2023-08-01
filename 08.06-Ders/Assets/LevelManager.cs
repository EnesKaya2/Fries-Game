using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject door;
    [SerializeField] Transform playerSpawnerPos;
    [SerializeField] GameObject friesPrefab;
    // Start is called before the first frame update

    public int count;
    [SerializeField]public int countForWin;
    private bool canWin;
    private void Awake()
    {
        PlayerSpawnerPos();
        spawnFries();
      
    }
    private void Update()
    {
        OpenDoor();
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
    private void OpenDoor()
    {
        if (count == countForWin)
        {
            door.gameObject.SetActive(true);

        }
    }
}
