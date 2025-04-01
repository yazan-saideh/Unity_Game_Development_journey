using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{
    public GameObject optionpanel;
    public GameObject panel;
   public void start()
    {
        SceneManager.LoadScene("Game");
    }
    public void option()
    {
        optionpanel.SetActive(true);
        panel.SetActive(false);
    }public void exut()
    {
        optionpanel.SetActive(false);
        panel.SetActive(true);
    }
    public void quit()
    {
        Application.Quit();
    }
    public void qualitysettings(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }
}
