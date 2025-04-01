using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelect : MonoBehaviour
{
    // Start is called before the first frame update
    public int sencelevel;
    public Animator ani;
    public GameObject btw;
    public GameObject door;
   public static LevelSelect instance;
    private void Awake()
    {
        ani.SetBool("Start" , false);
        
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        
    }
    private void Start()
    {
        Invoke("nextlevel" ,2);
        door = GameObject.FindGameObjectWithTag("door");
        transform.position = door.transform.position;
        btw = GameObject.FindGameObjectWithTag("btw");
        ani = GameObject.FindGameObjectWithTag("btw").GetComponent<Animator>();
        if (gameObject.GetComponent<LevelSelect>().enabled == false)
        {
            gameObject.GetComponent<LevelSelect>().enabled = true;
        }
    }
    
    public void nextlevel()
    {
        btw.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(LoadAsync(SceneManager.GetActiveScene().buildIndex + 1));
            sencelevel = SceneManager.GetActiveScene().buildIndex + 1;
            PlayerPrefs.DeleteKey("portal");
            if (sencelevel > PlayerPrefs.GetInt("LevelAt"))
            {
                PlayerPrefs.SetInt("LevelAt", sencelevel);
            }
        }
    }
    IEnumerator LoadAsync(int levelindex)
    {
        btw.SetActive(true);
        Time.timeScale = 1;
        ani.SetTrigger("Start");
        yield return new WaitForSeconds(1.50f);

        SceneManager.LoadScene(levelindex);
        yield return new WaitForSeconds(1.50f);
        if(gameObject.GetComponent<LevelSelect>().enabled == false)
        {
            gameObject.GetComponent<LevelSelect>().enabled = true;
        }
        
        btw = GameObject.FindGameObjectWithTag("btw");
        ani = GameObject.FindGameObjectWithTag("btw").GetComponent<Animator>();
        door = GameObject.FindGameObjectWithTag("door");
        transform.position = door.transform.position;
        btw.SetActive(false);
    }
}
