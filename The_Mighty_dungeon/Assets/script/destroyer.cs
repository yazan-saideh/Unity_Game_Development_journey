using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Player"));
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
    
}
