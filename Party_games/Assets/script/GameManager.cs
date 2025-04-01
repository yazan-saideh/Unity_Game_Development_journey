using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public float time = 10;
    public Slider slider;
    public int highscore;
    public Text highscoretext;
    public float Timebtwscene;
    public int life = 3;
    [Header("Betweenscene")]
    public GameObject[] heart;
    public CutLevelManger cutLevelManger;
    public int i = 0;
    public Sprite heartlose;
    public float num;
    public bool ad;
    public bool pressedno;
    public GameObject ads;
    public GameObject ads2;
    public float rounds;
    public int highscore2;
    public float num2;
    // Start is called before the first frame update
    void Awake()
    {
        
    }
    public void Start()
    {
        
        Application.targetFrameRate = 60;
        highscore2 = PlayerPrefs.GetInt("highscore2");
        time = PlayerPrefs.GetFloat("time");
        slider.maxValue = time;
        //time = PlayerPrefs.GetFloat("time");
        rounds = PlayerPrefs.GetFloat("rounds");
        FindObjectOfType<AudioManager>().Play("Theme");
        num++;
        PlayerPrefs.SetFloat("num", num);
        num=PlayerPrefs.GetFloat("num");
        i = PlayerPrefs.GetInt("lose");
        highscore = PlayerPrefs.GetInt("highscore");
        life = PlayerPrefs.GetInt("life");
        
        if (SceneManager.GetActiveScene().name == "Between Levels")
        {
            rounds++;
            PlayerPrefs.SetFloat("rounds", rounds);
            Invoke("lose2", 1.16f);
            Invoke("lose", .1f);
            Invoke("lose3", 1.17f);
            Invoke("lose4", 2f);
        }
        if(SceneManager.GetActiveScene().name == "Start")
        {
            if (life < 3)
            {
                PlayerPrefs.DeleteKey("life");
                life = 3;
                PlayerPrefs.SetInt("life", life);
                life = PlayerPrefs.GetInt("life");
            }
            ads2.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        slider.value = time;
        highscoretext.text = highscore.ToString();
        if (time >= 0)
        {
            time -= Time.deltaTime;
        }

        if (SceneManager.GetActiveScene().name == "Between Levels")
        {
            if(life >= 1)
            {
                if (Timebtwscene >= 3)
                {
                    SceneManager.LoadScene(Random.Range(3, 9));
                }
                else
                {
                    Timebtwscene += Time.deltaTime;
                }
            }
            if (life <= 0)
            {
                ads.SetActive(true);
                if (pressedno == true)
                {
                    ad = false;
                    //highscore2 = highscore;
                    //PlayerPrefs.SetInt("highscore2", highscore2);
                    PlayerPrefs.DeleteKey("life");
                    PlayerPrefs.DeleteKey("time");
                    
                    PlayerPrefs.DeleteKey("rounds");
                    PlayerPrefs.DeleteKey("lose");
                    life = 3;
                    i = 0;
                    time = 10;
                    PlayerPrefs.SetFloat("time", time);
                    PlayerPrefs.SetInt("life", life);
                    PlayerPrefs.SetInt("lose", i);
                    time = PlayerPrefs.GetFloat("time");
                    life = PlayerPrefs.GetInt("life");
                    life = PlayerPrefs.GetInt("lose");
                    SceneManager.LoadScene("Lose");
                }

            }
            else
            {
                life = PlayerPrefs.GetInt("life");
            }
        }
    }

    void lose()
    {
        if (life == 2)
        {
            heart[0].GetComponent<Animator>().SetBool("lose" , true);
        }
        if (life == 1)
        {
            heart[0].GetComponent<Animator>().SetBool("lose", true);
            heart[1].GetComponent<Animator>().SetBool("lose", true); 
        }
        if (life == 0)
        {
            heart[0].GetComponent<Animator>().SetBool("lose", true);
            heart[1].GetComponent<Animator>().SetBool("lose", true);
            heart[2].GetComponent<Animator>().SetBool("lose", true);
        }
    }
    void lose2()
    {
        if (life == 2)
        {
            heart[0].GetComponent<SpriteRenderer>().sprite = heartlose;
        }
         if (life == 1)
        {
            heart[0 ].GetComponent<SpriteRenderer>().sprite = heartlose;
            heart[1 ].GetComponent<SpriteRenderer>().sprite = heartlose;
        }
         if (life == 0)
        {
            heart[0].GetComponent<SpriteRenderer>().sprite = heartlose;
            heart[1].GetComponent<SpriteRenderer>().sprite = heartlose;
            heart[2].GetComponent<SpriteRenderer>().sprite = heartlose;
        }
    }
    void lose3()
    {
        if (life == 3)
        {
            i = 0;
            PlayerPrefs.SetInt("lose", i);
        }
        if(life == 0)
        {
            if (ad == false)
            {
                SceneManager.LoadScene("Lose");
            }
        }
    }
    void lose4()
    {
        
        
        
    }
    public void restart()
    {
        PlayerPrefs.DeleteKey("highscore");
        SceneManager.LoadScene("Start");
    }
    public void no()
    {
        pressedno = true;
    }
    public void yes()
    {
        ad = true;
    }
    public void openlinkGame()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.YazanDev.portals");
    }
    public void openlinkInsta()
    {
        Application.OpenURL("https://www.instagram.com/yazandev/");
    }public void openlink()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=comYazanDev.TheMightyDungeon");
    }
    public void cancel()
    {
        ads2.SetActive(false);
    }
    public void start()
    {
        time = 10;
        PlayerPrefs.SetFloat("time", time);
        SceneManager.LoadScene(Random.Range(3, 9));
    }
}


