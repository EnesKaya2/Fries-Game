using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject door;
    [SerializeField] Transform playerSpawnPos;
    [SerializeField] GameObject friesPrefab;

    public int count;
    [SerializeField] int countForWin;
    public bool win;

    [Header("Knife Spawner")]
    [SerializeField] private GameObject knifePrefab;
    [SerializeField] private Vector2 spawnValues;
    [SerializeField] private float startSpawn;
    [SerializeField] private float minSpawn;
    [SerializeField] private float maxSpawn;
    [SerializeField] private float startWait;
    [SerializeField] bool knifeStop;


    private void Awake()
    {
        PlayerSpawner();
    }

    private void Start()
    {
        FriesSpawner();
        StartCoroutine(CreateKnife());
    }
    private void Update()
    {
        OpenDoor();

        startSpawn = Random.Range(minSpawn, maxSpawn);
    }

    void PlayerSpawner()
    {
        Instantiate(player, playerSpawnPos.position, Quaternion.identity);
    }
    public void PlayerRespawner()
    {
        Instantiate(player, playerSpawnPos.position, Quaternion.identity);
    }

    public void FriesSpawner()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-8, 8), Random.Range(-3.5f, 2f), 0);

        if (count < countForWin)
        {

            if (!Physics2D.OverlapCircle(spawnPos, 0.2f))
            {
                Instantiate(friesPrefab, spawnPos, Quaternion.identity);
            }
            else
            {
                FriesSpawner();
            }
        }
    }

    private void OpenDoor()
    {
        if (count == countForWin)
        {
            door.gameObject.SetActive(true);
            win = true;
            knifeStop = true;
        }
    }

    private IEnumerator CreateKnife()
    {
        yield return new WaitForSeconds(startWait);

        while (!knifeStop)
        {
            Vector2 spawnPos = new Vector2(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y));
            Instantiate(knifePrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(startSpawn);
        }

    }

}
