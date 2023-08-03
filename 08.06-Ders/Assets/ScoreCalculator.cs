using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreCalculator : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = ScoreManager.instance.GetScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ScoreManager.instance.GetScoreText();
    }
}
