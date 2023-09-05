using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI scoreText;
    [SerializeField]TextMeshProUGUI highScoreText;

    private void Start()
    {
        SoundManager.instance.PlaySound(15);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        ScoreManager.score = 0;
        Application.Quit();
    }

    private void OnEnable()
    {
        scoreText.text = ScoreManager.instance.GetScoreText();
        highScoreText.text = ScoreManager.instance.GetHighScoreText();
        
    }
}
