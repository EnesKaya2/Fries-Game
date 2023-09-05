using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    [SerializeField] TMP_InputField nameInput;
    [SerializeField] TextMeshProUGUI infoText;
    [SerializeField] Toggle check;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Check"))
        {
            check.isOn = PlayerPrefs.GetInt("Check") == 1;
        }
    }
    public void Save()
    {
        PlayerPrefs.SetString("PlayerName", nameInput.text);
        PlayerPrefs.SetInt("Check", check.isOn ? 1 : 0);
        infoText.text = "Your Name Data " + PlayerPrefs.GetString("PlayerName") + " Successfully Saved";
    }

    public void NextButton()
    {
        SceneManager.LoadScene(1);
    }

    public void DefaultButton()
    {
        PlayerPrefs.DeleteAll();
    }

}
