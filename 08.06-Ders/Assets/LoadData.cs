using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadData : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI infoText;
    [SerializeField] TextMeshProUGUI loadText;

    
    void Update()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            loadText.text = "Your Name is " + PlayerPrefs.GetString("PlayerName");
        }
        else
        {
            loadText.text = "There is no registered player";
        }
    }

    public void DeleteButton()
    {
        PlayerPrefs.DeleteKey("PlayerName");
        infoText.text = "Your data has been successfully deleted";
    }
    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }
    public void GameButton()
    {
        SceneManager.LoadScene(2);

    }
}
