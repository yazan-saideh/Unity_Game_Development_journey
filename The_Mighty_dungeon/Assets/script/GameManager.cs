using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Text ScoreText;
   public float score;
    int randEn;
    int randtre;
    public GameObject Enemy;
    public Text EnemyNum;
    public int i;
    public int N;
    public GameObject tresure;
    public GameObject GameOverPanel;
    public Text highscoretext;
    public playerMove playerMove;
    public static GameManager instance;
    public GameObject optionpanel;
    public float money;
    public Text moneytext;
    public GameObject upgrade;
    public GameObject MainCanves;
    bool gameover;
    public void Start()
    {
        playerMove.health = playerMove.Maxhealth;
        playerMove.armor = playerMove.Maxarmor / 3f;
        Time.timeScale = 1f;
        Invoke("check", 1f);
        Invoke("spwan", 0.3f);
        highscoretext.text ="Your Highscore is : " + PlayerPrefs.GetFloat("highscore" , 0).ToString();
        money = PlayerPrefs.GetFloat("money", 0);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        moneytext.text = money.ToString();
        if (money > PlayerPrefs.GetFloat("money", 0))
        {
            PlayerPrefs.SetFloat("money", money);
        }
        
        ScoreText.text = "Score :" + score.ToString();
        EnemyNum.text = i.ToString();
       if(score > PlayerPrefs.GetFloat("highscore",0))
        {
            PlayerPrefs.SetFloat("highscore", score);
        }
       if(playerMove.health <= 0)
        {
            PlayerPrefs.SetInt("die", playerMove.die);
            //Time.timeScale = 0;
            if(gameover == true)
            {
                GameOverPanel.SetActive(false);
            }
            else
            {
                GameOverPanel.SetActive(true);
            }
        }
        
    }
    void spwan()
    {
        for ( i = 0; i < GameObject.FindGameObjectsWithTag("Enemy").Length; i++)
        {
            randEn = Random.Range(0, GameObject.FindGameObjectsWithTag("Enemy").Length);
            Instantiate(Enemy, GameObject.FindGameObjectsWithTag("Enemy")[randEn].transform.position, Quaternion.identity);
        }
        for (N = 0; N < GameObject.FindGameObjectsWithTag("tresure").Length; N++)
        {
            randtre = Random.Range(0, GameObject.FindGameObjectsWithTag("tresure").Length);
            Instantiate(tresure, GameObject.FindGameObjectsWithTag("tresure")[randtre].transform.position, Quaternion.identity);
        }
    }
    void check()
    {
        if (GameObject.FindGameObjectsWithTag("EnemyReal").Length == 0)
        {
            score++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void Rest()
    {
        GameOverPanel.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Upgrade()
    {
        Time.timeScale = 1f;
        
        upgrade.SetActive(true);
        gameover = true;
    }
    public void option()
    {
        optionpanel.SetActive(true);
        MainCanves.SetActive(false);
    }
    public void exut()
    {
        optionpanel.SetActive(false);
        MainCanves.SetActive(true);
        
    }
}
