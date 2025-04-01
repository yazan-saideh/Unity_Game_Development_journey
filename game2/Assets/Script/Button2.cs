using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2 : MonoBehaviour
{
    public Animator ani;
    public bool pressed;
    [Header("Door")]
    public Animator doorani;
    
    // Start is called before the first frame update
    void Start()
    {
        pressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(pressed == true)
        {
            doorani.SetBool("dooropen", true);
            FindObjectOfType<AudioManager>().Play("door2");
        }
        else
        {
            doorani.SetBool("dooropen", false);
            ani.SetBool("pressed", false);
            //FindObjectOfType<AudioManager>().Play("door2");
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            ani.SetBool("pressed", true);
            pressed = true;
            FindObjectOfType<AudioManager>().Play("button");
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            ani.SetBool("pressed", false);
            pressed = false;
        }
    }
}
