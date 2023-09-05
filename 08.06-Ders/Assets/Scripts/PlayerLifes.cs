using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class PlayerLifes : MonoBehaviour
{
    private UiManager uiManager;
    private int playerLifes = 3;
    [SerializeField] Image[] playerLifeImage;
    private Delay delay;
    private GameObject player;
    [SerializeField] ParticleSystem playerParticle;


    private void Start()
    {
        
        uiManager = GameObject.Find("UiManager").GetComponent<UiManager>();
        delay = GameObject.Find("LevelManager").GetComponent<Delay>();
    }
    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }
    public void Lifes()
    {
        playerLifes--;
        Instantiate(playerParticle, player.gameObject.transform.position,Quaternion.identity);
        Destroy(playerLifeImage[playerLifes]);
        if (playerLifes < 1)
        {
            delay.delayTime = false;
            uiManager.GetComponent<Canvas>().enabled = true;
        }
    }
}
