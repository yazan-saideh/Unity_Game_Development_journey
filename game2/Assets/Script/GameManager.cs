using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [Header("Numbers")]
    public float leveltime = 160;
    public float losenum;
    [Header("Text")]
    public Text leveltimeText;
    [Header("GameObject")]
    public GameObject PostProsesing;
    public GameObject OverPanel;
    public GameObject maincanvas;
    
    int sencelevel;
     public GameObject player;
    [Header("Settings")]
    public GameObject canvas;
    public GameObject qualitypanel;
    GameManager instance;
    LevelSelect level;
    // Start is called before the first frame update
    private void Awake()
    {
        Application.targetFrameRate = 60;

    }
    void Start()
    {
        level = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelSelect>();
        maincanvas.SetActive(true);
        Time.timeScale = 1;
        OverPanel.SetActive(false);
        PostProsesing.SetActive(false);

        if (level.GetComponent<LevelSelect>().enabled == false)
        {
            level.GetComponent<LevelSelect>().enabled = true;
        }
        losenum = PlayerPrefs.GetFloat("lose");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player.transform.position.y <= -20)
        {
            Restart();
        }
        
        if (0 >= leveltime)
        {
            lose();
            Restart();
        }
        else
        {
            
            leveltime -= Time.deltaTime;
            leveltimeText.text = leveltime.ToString("0");
        }
    }
    public void Restart ()
    {
        losenum += 1;
        PlayerPrefs.SetFloat("lose", losenum);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PlayerPrefs.DeleteKey("portal");
    }
    public void lose()
    {
        OverPanel.SetActive(true);
        PostProsesing.SetActive(true);
        maincanvas.SetActive(false);
        Time.timeScale = 0;
    }
    
    public void opensettingspanel()
    {
        qualitypanel.SetActive(true);
        canvas.SetActive(false);
    }
    public void switchtolevelselect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void quality(int qualityindex)
    {
        QualitySettings.SetQualityLevel(qualityindex);
    }
    public void exitsettingspanel()
    {
        qualitypanel.SetActive(false);
        canvas.SetActive(true);
    }
}
