using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {

        scoreText.text = ScoreManager.instance.GetScoreText();
    }

    void Update()
    {
        scoreText.text = ScoreManager.instance.GetScoreText();
    }
}
