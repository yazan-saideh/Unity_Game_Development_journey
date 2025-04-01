using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightclose : MonoBehaviour
{
    public Animator ani;
    public bool pressed;
    [Header("Door")]
    public GameObject light;
    
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
            ani.SetBool("pressed", true);
        }
        else
        {
            ani.SetBool("pressed", false);
            light.SetActive(true);
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            ani.SetBool("pressed", true);
            pressed = true;
            FindObjectOfType<AudioManager>().Play("button");
            light.SetActive(false);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            ani.SetBool("pressed", false);
            pressed = false;
            light.SetActive(true);
        }
    }
}
