using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;

    private void Update()
    {
        scoreText.text = ScoreManager.instance.GetScoreText();
        highScoreText.text = ScoreManager.instance.GetHighScoreText();

    }
    public void Menu()
    {
        ScoreManager.score = 0;
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        ScoreManager.score = 0;
        SceneManager.LoadScene(1);

    }


}
