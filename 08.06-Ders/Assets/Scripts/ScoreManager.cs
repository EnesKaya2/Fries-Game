using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public static int score = 0;
    public static int highScore;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
    }
    private void Update()
    {
        int scoreValue = Mathf.Clamp(score, 0, 15);
        score = scoreValue;

    }

    public void AddPoint(int value)
    {
        

        score += value;

        if (highScore < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore");
    }

    public string GetHighScoreText()
    {
        return "High Score : " + PlayerPrefs.GetInt("HighScore").ToString();
    }

    public int GetScore()
    {
        return score;
    }

    public string GetScoreText()
    {
        return "Score : " + score.ToString();
    }
}
