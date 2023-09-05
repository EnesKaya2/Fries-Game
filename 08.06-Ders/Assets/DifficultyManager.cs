using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [HideInInspector]
    public bool easyMode, normalMode, hardMode;


    void Start()
    {
        PlayerPrefs.DeleteKey("Easy Mode");
        PlayerPrefs.DeleteKey("Normal Mode");
        PlayerPrefs.DeleteKey("Hard Mode");
        easyMode = false;
        normalMode = false;
        hardMode = false;
    }

    public void EasyButton()
    {
        easyMode = true;
        PlayerPrefs.SetInt("Easy Mode", easyMode ? 1 : 0);
    }
    public void NormalButton()
    {
        normalMode = true;
        PlayerPrefs.SetInt("Normal Mode", normalMode ? 1 : 0);
    }
    public void HardButton()
    {
        hardMode = true;
        PlayerPrefs.SetInt("Hard Mode", hardMode ? 1 : 0);
    }
}
