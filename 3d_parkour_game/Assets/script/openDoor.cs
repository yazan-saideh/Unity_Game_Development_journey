using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    public Animator ani;
    public float timeToColse;
    bool open;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            ani.SetBool("Open", true);
            open = true;
        }
        
    }
    private void Update()
    {
        if(open == true)
        {
            timeToColse += Time.deltaTime;
            if (timeToColse >= 2)
            {
                ani.SetBool("Open", false);
                timeToColse = 0f;
                open = false;
            }
        }
    }
}
