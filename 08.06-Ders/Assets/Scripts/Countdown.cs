using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public float duration;
    public Image cooldownImage;

    void Start()
    {
        duration = Player.dashCooldown;
    }
    void Update()
    {
        Timer();
    }
    private void Timer()
    {
        if (Player.dashed)
        {
            duration -= Time.deltaTime;
            cooldownImage.fillAmount = Mathf.InverseLerp(Player.dashCooldown, 0, duration);
        }
        else
        {
            cooldownImage.fillAmount = 1f;
            duration = Player.dashCooldown;
        }
    }
}
