using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class collectCoin : MonoBehaviour
{
    GameObject gameManger;
    int random;
    public GameObject coin;
    int coinnum;
    // Start is called before the first frame update
    private void Awake()
    {
        random = Random.Range(1, 35);
    }
    void Start()
    {
        gameManger = GameObject.FindGameObjectWithTag("GameManager");
        InvokeRepeating("check", 0.01f, 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManger.GetComponent<GameManager>().time <= 0 || GameObject.FindGameObjectWithTag("Coin") == null)
        {
            if(GameObject.FindGameObjectWithTag("Coin") != null)
            {
                gameManger.GetComponent<GameManager>().life -= 1;
                PlayerPrefs.SetInt("life", gameManger.GetComponent<GameManager>().life);
                SceneManager.LoadScene("Between Levels");
            }
            else
            {
                gameManger.GetComponent<GameManager>().highscore += 100;
                PlayerPrefs.SetInt("highscore", gameManger.GetComponent<GameManager>().highscore);
                SceneManager.LoadScene("Between Levels");
            }
        }
    }
    void check()
    {
        if (coinnum <= random)
        {
            Instantiate(coin, transform.position, Quaternion.identity);
            coinnum++;
        }
    }
}
