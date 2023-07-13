using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    private Delay delay;
    private UiManager uiManager;
    private int playerLives = 3;
    [SerializeField] Image[] playerLiveImage;

    // Start is called before the first frame update
    void Start()
    {
        delay = GameObject.Find("LevelManager").GetComponent<Delay>();
        uiManager = GameObject.Find("UiManager").GetComponent<UiManager>();
    }
    public void Lives()
    {
        playerLives--;
        Destroy(playerLiveImage[playerLives]);
        if (playerLives < 1)
        {
            delay.delayTime = false;
            uiManager.GetComponent<Canvas>().enabled = true;
        }
    }
}
