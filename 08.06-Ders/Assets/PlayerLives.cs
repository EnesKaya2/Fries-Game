using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class PlayerLives : MonoBehaviour
{
    private Delay delay;
    private UiManager uiManager;
    private int playerLives = 3;
    [SerializeField] Image[] playerLiveImage;
    private GameObject player;
    [SerializeField] ParticleSystem playerParticle;

    // Start is called before the first frame update
    void Start()
    {
        delay = GameObject.Find("LevelManager").GetComponent<Delay>();
        uiManager = GameObject.Find("UiManager").GetComponent<UiManager>();
    }
    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");


    }
    public void Lives()
    {
        playerLives--;
        Destroy(playerLiveImage[playerLives]);
        Instantiate(playerParticle, player.gameObject.transform.position, Quaternion.identity);
        if (playerLives < 1)
        {
            delay.delayTime = false;
            uiManager.GetComponent<Canvas>().enabled = true;
        }
    }

}
