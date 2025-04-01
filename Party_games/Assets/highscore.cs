using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class highscore : MonoBehaviour
{
    public Text text;
    GameManager gameManager;
    float Highscore;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gameManager.highscore2 = PlayerPrefs.GetInt("highscore2");
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.highscore > gameManager.highscore2)
        {
            gameManager.highscore2 = gameManager.highscore;
            PlayerPrefs.SetInt("highscore2", gameManager.highscore2);
            text.text = PlayerPrefs.GetInt("highscore2").ToString();
        }
        else
        {
            text.text = PlayerPrefs.GetInt("highscore2").ToString();
        }
    }
}
