using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public float time;
    public float time2;
    public Text timetext;
    public float timerestart;
    public float videorewardtime;
    public int sencelevel;
    // Start is called before the first frame update
    void Awake()
    {
        time = time2;
        sencelevel = PlayerPrefs.GetInt("LevelAt");
        timerestart = PlayerPrefs.GetFloat("timerestart");
        videorewardtime = PlayerPrefs.GetFloat("videorestart");
    }
    private void Start()
    {
        Application.targetFrameRate = 60;
    }
    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timetext.text = Mathf.Round(time).ToString();
        if(time <= 0)
        {
            restart();
        }
       
    }
    public void loadlevel(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void restart()
    {
        if (timerestart >= 5)
        {
            timerestart = 0;
            PlayerPrefs.SetFloat("timerestart", timerestart);
        }
        if (videorewardtime >= 2)
        {
            videorewardtime = 0;
            PlayerPrefs.SetFloat("videorestart", videorewardtime);
        }
        timerestart += 1;
        videorewardtime+= 1;
        PlayerPrefs.SetFloat("timerestart", timerestart);
        PlayerPrefs.SetFloat("videorestart", videorewardtime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void savelevel()
    {
        sencelevel = SceneManager.GetActiveScene().buildIndex + 1;

        if (sencelevel > PlayerPrefs.GetInt("LevelAt"))
        {
            PlayerPrefs.SetInt("LevelAt", sencelevel);
        }
    }
}
