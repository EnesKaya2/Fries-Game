using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavePlayerPosition : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] TextMeshProUGUI infoText;
    [SerializeField] TextMeshProUGUI playerNameText;
    

    void Start()
    {
        if (PlayerPrefs.HasKey("PositionX") || PlayerPrefs.HasKey("PositionY"))
        {
            player.transform.position = new Vector2(PlayerPrefs.GetFloat("PositionX"), PlayerPrefs.GetFloat("PositionY"));
        }
        else
        {
            player.transform.position = Vector2.zero;
        }
        playerNameText.text = PlayerPrefs.GetString("PlayerName");
    }

    public void SavePosition()
    {
        PlayerPrefs.SetFloat("PositionX",player.transform.position.x);
        PlayerPrefs.SetFloat("PositionY",player.transform.position.y);
        infoText.text = "Your position successfully saved";
    }
    public void ResetPosition()
    {
        PlayerPrefs.DeleteKey("PositionX");
        PlayerPrefs.DeleteKey("PositionY");
    }
    public void ReloadGame()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }
}
