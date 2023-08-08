using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public float duration;

    public Image coolDownImage;

    void Start()
    {
        duration = Movement.dashCoolDown;

    }

    // Update is called once per frame
    void Update()
    {
        Timer();

    }
    private void Timer()
    {
        if (Movement.dashed)
        {
            duration -= Time.deltaTime;
            coolDownImage.fillAmount = Mathf.InverseLerp(Movement.dashCoolDown, 0, duration);
        }
        else
        {
            coolDownImage.fillAmount = 1f;
            duration = Movement.dashCoolDown;
        }
    }

}
