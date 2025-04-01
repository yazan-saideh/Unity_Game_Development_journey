using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.name == "redplatform")
        {
            if (collision.CompareTag("red"))
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
            else
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        if (gameObject.name == "blueplatform")
        {
            if (collision.CompareTag("blue"))
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
            else
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.name == "redplatform")
        {
            if (collision.CompareTag("red"))
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        if (gameObject.name == "blueplatform")
        {
            if (collision.CompareTag("blue"))
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}
