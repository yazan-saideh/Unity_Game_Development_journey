using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class reaction : MonoBehaviour
{
   GameObject gameManager;
    [SerializeField]
    bool getit;
    [SerializeField]
    float time;
    [SerializeField]
    float timestart;
    [SerializeField]
        float timeend;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        time = Random.Range(0.5f, gameManager.GetComponent<GameManager>().time);
    }

    // Update is called once per frame
    void Update()
    {
        timestart += Time.deltaTime;
        if(timestart >= time)
        {
            button.SetActive(true);
            timeend += Time.deltaTime;
            if(timeend >= 0.4f)
            {
                button.SetActive(false);
            }
        }
        if (gameManager.GetComponent<GameManager>().time <= 0)
        {
            if (getit == true)
            {
                gameManager.GetComponent<GameManager>().highscore += 100;
                PlayerPrefs.SetInt("highscore", gameManager.GetComponent<GameManager>().highscore);
                SceneManager.LoadScene("Between Levels");
            }
            else
            {
                gameManager.GetComponent<GameManager>().i++;
                PlayerPrefs.SetInt("lose", gameManager.GetComponent<GameManager>().i);
                gameManager.GetComponent<GameManager>().life -= 1;
                PlayerPrefs.SetInt("life", gameManager.GetComponent<GameManager>().life);
                SceneManager.LoadScene("Between Levels");
            }
        }
    }
   public void Reaction()
    {
        getit = true;
    }
}
