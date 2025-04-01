using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class pOURWATER : MonoBehaviour
{
    public Slider slider;
    
    float random;
    public GameObject limit;
    GameObject gamemanager;
    bool start;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.FindGameObjectWithTag("GameManager");
        random = Random.Range(-1.79f, 1.37f);
        limit.transform.position = new Vector2(0,random);
        start = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonUp(0) || gamemanager.GetComponent<GameManager>().time <= 0)
        {
            start = false;
            
             if (slider.value >= random - .3f && slider.value <= random + .3f)
            {
                win();
            }
            else
            {
                life();
            }
        }
        
        if (Input.GetMouseButton(0))
        {
            if(start == true)
            {
                slider.value += 6 * Time.deltaTime;
            }
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
        PlayerPrefs.SetInt("highscore", gamemanager.GetComponent<GameManager>().highscore);
        SceneManager.LoadScene("Between Levels");
    }
}
