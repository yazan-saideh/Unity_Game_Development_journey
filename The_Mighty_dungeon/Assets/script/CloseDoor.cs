using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    public Animator ani;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && ani.GetBool("CloseDoor") == false)
        {
            ani.SetBool("CloseDoor", true);
        }
        else if (collision.CompareTag("Player") && ani.GetBool("CloseDoor") == true)
        {
            ani.SetBool("CloseDoor", false);
        }
    }
}
