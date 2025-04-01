using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendoor : MonoBehaviour
{
    public Animator ani;
   public bool true1;
       public bool true2;
    public GameObject winpanel;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("red") )
        {
            true1 = true;
           
        }
        if ( collision.CompareTag("blue"))
        {
            true2 = true;
        }
        
    }
    private void Update()
    {
        if (true1 == true && true2 == true)
        {
            ani.SetBool("open", true);
            FindObjectOfType<AudioManager1>().Play("door");
            winpanel.SetActive(true);
             
        }
        else
        {
            ani.SetBool("open", false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("red"))
        {
            true1 = false;
        }
        if (collision.CompareTag("blue"))
        {
            true2 = false;
        }
    }

}
