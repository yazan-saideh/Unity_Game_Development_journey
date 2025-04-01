using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject[] spawns;
    public float wave = 1;
    float waittime;
    float waittime2 = 2f;
   public float enemynum;
    public float enemymax;
    public GameObject enemy;
   public bool started = true;
    public Animator ani;
    public Text wavetext;
    public GameObject canvas;
    float wait;
    GameObject player;
    public Text coins;
    public GameObject MAINCANVAS;
    public GameObject GameOversCANVAS;
    [Header("Upgrade")]
    public GameObject UpgradesCanvas;
    float healthcost;
    float weaponcost = 350 ;
    public Text healthText;
    //public Text healthcostText;
    public Text healthcostText2;
    public Text weaponcostText;
    public Text coinsText;
    public shoot shoot;
   public float int1 = 0;
    [Header("Audio")]
    public Button muteB;
    public Sprite muteS;
    public Sprite unmuteS;
    public bool ismuted;
    // Start is called before the first frame update
    void Start()
    {
       // FindObjectOfType<AudioManager>().Play("Theme");
        int1 = PlayerPrefs.GetFloat("int");
        if (PlayerPrefs.GetFloat("int") == 1)
        {
            shoot.transform.parent.GetComponent<SpriteRenderer>().sprite = shoot.assult;
            weaponcostText.text = "Equipped";
        }
        healthcost =PlayerPrefs.GetFloat("Healthcost");
        player = GameObject.FindGameObjectWithTag("Player");
         //wave = 1;
        wavetext.text = "WAVE" + " " + wave.ToString();
        enemy.GetComponent<Enemy>().MaxHealth = 20;
        enemy.GetComponent<Enemy>().damage = 2;
        player.GetComponent<player>().coinsBouns = 1;
        player.GetComponent<player>().points = 1;
        ani.SetBool("win", true);
        started = true;
        waittime = waittime2;
        player.GetComponent<player>().coins = PlayerPrefs.GetFloat("coins", player.GetComponent<player>().coins);
        InvokeRepeating("NextWave", 2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        coins.text = player.GetComponent<player>().coins.ToString();
        if (started)
        {
            wait -= Time.deltaTime;
            if(wait <= -2f)
            {
                wait = 0;
                canvas.SetActive(false);
                ani.SetBool("win", false);
            }
            if (waittime <= 0)
            {
                if( enemynum < enemymax)
                {
                    int i = Random.Range(0, 3);
                    Instantiate(enemy, spawns[i].transform.position, Quaternion.identity);
                     waittime = waittime2;
                    enemynum++;
                }
            }
        }
        if(enemynum == enemymax)
        {
            started = false;
            canvas.SetActive(false);
        }
        
        waittime -= Time.deltaTime;
    }
    void NextWave()
    {
        if(GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            player.GetComponent<player>().coinsBouns = player.GetComponent<player>().coinsBouns * 2;
            canvas.SetActive(true);
            wavetext.text = "WAVE" + " " + wave.ToString();
            ani.SetBool("win", true);
            enemy.GetComponent<Enemy>().MaxHealth += 2;
            enemy.GetComponent<Enemy>().damage = enemy.GetComponent<Enemy>().damage + 3;
            started = true;
            enemynum = 0;
            enemymax = enemymax + 1;
            waittime2 = waittime2 * 0.7f;
            wave++;
        }
    }
    public void lose()
    {
        MAINCANVAS.SetActive(false);
        GameOversCANVAS.SetActive(true);
    }
    public void Restart()
    {
        PlayerPrefs.SetFloat("coins", player.GetComponent<player>().coins);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void upgrade()
    {
        
        PlayerPrefs.SetFloat("coins", player.GetComponent<player>().coins);
        player.GetComponent<player>().coins = PlayerPrefs.GetFloat("coins", player.GetComponent<player>().coins);
        UpgradesCanvas.SetActive(true);
        healthText.text ="Health" + ":" + player.GetComponent<player>().maxhealth.ToString();
        coinsText.text = "Damage" + ":" + player.GetComponent<player>().coins.ToString();
        //healthcostText.text = "Health" + ":" + player.GetComponent<player>().maxhealth.ToString();
        healthcostText2.text = "BUY" + " " + healthcost.ToString();
        weaponcostText.text = "BUY" + " " + "300";
        MAINCANVAS.SetActive(false);
    }
    public void upgradeHealth()
    {
        if(player.GetComponent<player>().coins >= healthcost)
        {
            player.GetComponent<player>().coins -= healthcost;
            player.GetComponent<player>().maxhealth = player.GetComponent<player>().maxhealth + 10;
            healthText.text = "Health" + ":" + player.GetComponent<player>().maxhealth.ToString();
            coinsText.text = player.GetComponent<player>().coins.ToString();
            PlayerPrefs.SetFloat("Health", player.GetComponent<player>().maxhealth);
            healthcost = healthcost + 20;
            //healthcostText.text = player.GetComponent<player>().maxhealth.ToString();
            healthcostText2.text ="BUY" + " " + healthcost.ToString();
            PlayerPrefs.SetFloat("Healthcost", healthcost);
            FindObjectOfType<AudioManager>().Play("Upgrade");
        }
    }
    public void weapon()
    {
        if (player.GetComponent<player>().coins >= weaponcost)
        {
            shoot.transform.parent.GetComponent<SpriteRenderer>().sprite = shoot.assult;
            int1 = 1;
            PlayerPrefs.SetFloat("int", int1);
            player.GetComponent<player>().coins -= healthcost;
        }
    }
    public void EXitupgrade()
    {
        UpgradesCanvas.SetActive(false);
        MAINCANVAS.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void mute()
    {
        
        if (!ismuted)
        {
            muteB.GetComponent<Image>().sprite = muteS;
            FindObjectOfType<AudioManager>().Stop("Theme");
            ismuted = true;
        }
        else
        {
            muteB.GetComponent<Image>().sprite = unmuteS;
            FindObjectOfType<AudioManager>().Play("Theme");
            ismuted = false;
        }
    }
   
}
