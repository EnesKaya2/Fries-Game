using System.Collections;
using UnityEngine;

public class Delay : MonoBehaviour
{
    private LevelManager levelManager;

    public bool delayTime = true;

    void Start()
    {
        levelManager = GetComponent<LevelManager>();
    }

    public void DelayStart()
    {
        StartCoroutine(DelayTimer());
    }

    private IEnumerator DelayTimer()
    {
        yield return new WaitForSeconds(1f);
        levelManager.PlayerRespawner();
    }
}
