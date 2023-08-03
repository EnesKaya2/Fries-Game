using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;

    public void Menu()
    {
        SceneManager.LoadScene(0);
        ScoreManager.score = 0;
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
        ScoreManager.score = 0;
    }
    private void Update()
    {
        scoreText.text = ScoreManager.instance.GetScoreText();
        highScoreText.text = ScoreManager.instance.GetHighScoreText();


    }
}
