using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class WinPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
   public void NextLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        ScoreManager.score = 0;
        Application.Quit();
    }

    //Canvas Aktif Oldugunda içindeki Fonksiyon Çalýsýr.
    private void OnEnable()
    {
        scoreText.text = ScoreManager.instance.GetScoreText();
        highScoreText.text = ScoreManager.instance.GetHighScoreText();
    }
}
