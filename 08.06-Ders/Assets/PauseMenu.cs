using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPause;
    [SerializeField] Canvas pauseCanvas;

    private void Awake()
    {
        pauseCanvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

   

    public void ResumeGame()
    {
        pauseCanvas.enabled = false;
        Time.timeScale = 1;
        isPause = false;
    }

    public void PauseGame()
    {
        pauseCanvas.enabled = true;
        Time.timeScale = 0;
        isPause = true;

    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        isPause=false;
    }
}
