using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Dooropen : MonoBehaviour
{
    public Animator ani;
    
    public GameObject MAINPanel;
    public bool pressed;
   
    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(pressed == true )
        {
            if (collision.CompareTag("Player"))
            {
                ani.SetBool("dooropen", true);
                FindObjectOfType<AudioManager>().Play("door");
                //WinPanel.SetActive(true);
                //MAINPanel.SetActive(false);
                //Time.timeScale = 0;
            }
            else
            {
                ani.SetBool("dooropen", false);
            }
        }
    }
    
}
