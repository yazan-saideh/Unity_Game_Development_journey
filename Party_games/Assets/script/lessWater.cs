using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class lessWater : MonoBehaviour
{
    public Slider slider;
    GameObject gamemanager;
   //public float num = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.FindGameObjectWithTag("GameManager");
        gamemanager.GetComponent<GameManager>().num2 = PlayerPrefs.GetFloat("num2");
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            slider.value -= 8 * Time.deltaTime;
        }
        slider.value += gamemanager.GetComponent<GameManager>().num2 * Time.deltaTime;
        if(gamemanager.GetComponent<GameManager>().time <= 0 || slider.value == slider.maxValue)
        {
                life();
        }
        if(gamemanager.GetComponent<GameManager>().time <= 0 && slider.value < slider.maxValue)
        {
            win();
        }
        
    }
    void life()
    {
        gamemanager.GetComponent<GameManager>().life -= 1;
        PlayerPrefs.SetInt("life", gamemanager.GetComponent<GameManager>().life);
        SceneManager.LoadScene("Between Levels");
    }
    void win()
    {
        gamemanager.GetComponent<GameManager>().highscore += 100;
        PlayerPrefs.SetFloat("highscore", gamemanager.GetComponent<GameManager>().highscore);
        SceneManager.LoadScene("Between Levels");
    }
}
