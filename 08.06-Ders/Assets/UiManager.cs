using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
