using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Shoot : MonoBehaviour
{
    public GameObject shoot;
    public GameObject[] shootplace;
    public Vector2 fingerpos;
    float instansitatetime;
    GameObject shoot2;
    bool created;
    GameObject gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.FindGameObjectWithTag("GameManager");
        shoot2 = null;
        InvokeRepeating("bee", 0.6f, 0.6f);
    }

    // Update is called once per frame
    void Update()
    {
        fingerpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(gamemanager.GetComponent<GameManager>().time <= 0)
        {
            if(GameObject.FindGameObjectWithTag("Target") != null)
            {
                life();
            }
            else
            {
                win();
            }
        }
    }
    void bee()
    {
        int i = Random.Range(0, shootplace.Length);

         //i++;
            shoot2 = Instantiate(shoot, shootplace[i].transform.position, Quaternion.identity);
            created = true;
            instansitatetime = 0;
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
