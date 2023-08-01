using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;

    public static int score = 0;
    public static int highScore;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        scoreText.text ="Score : " + score.ToString();
        
    }

    void Update()
    {
        scoreText.text = "Score : " + score.ToString();
    }
}
