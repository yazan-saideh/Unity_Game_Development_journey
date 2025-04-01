using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CutLevelManger : MonoBehaviour
{
    public GameObject[] Options;
    int i = 0;
    GameObject gamemanager;
    bool end;
    cut cut;
    public float Life;
    // Start is called before the first frame update
    void Start()
    {
        end = false;
        gamemanager = GameObject.FindGameObjectWithTag("GameManager");
        Life = gamemanager.GetComponent<GameManager>().life ;
        i = Random.Range(0, Options.Length);
        Instantiate(Options[i], Options[i].transform.position, Quaternion.identity);
        InvokeRepeating("cuted", 0.1f, 0.1f);
        //Invoke("life", gamemanager.GetComponent<GameManager>().time - 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gamemanager.GetComponent<GameManager>().time <= 0 || cut.check == true)
        {
                if (cut.check == true)
                {
                gamemanager.GetComponent<GameManager>().highscore += 100;
                PlayerPrefs.SetInt("highscore" , gamemanager.GetComponent<GameManager>().highscore);
                SceneManager.LoadScene("Between Levels");
                    Debug.Log("hoooo");
                }
            else
            {
                life();
            }
        }
        
    }
    void life()
    { 
            if (cut.check == false)
            {
                end = false;
                gamemanager.GetComponent<GameManager>().i++;
                PlayerPrefs.SetInt("lose", gamemanager.GetComponent<GameManager>().i);
                gamemanager.GetComponent<GameManager>().life -= 1;
                PlayerPrefs.SetInt("life", gamemanager.GetComponent<GameManager>().life);
                SceneManager.LoadScene("Between Levels");
            }
    }
    void cuted()
    {
        cut = GameObject.FindGameObjectWithTag("Line").GetComponent<cut>();
    }
}
