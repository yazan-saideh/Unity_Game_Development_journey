using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    public GameObject[] abilities;
    int i;
    public void Start()
    {
        i = Random.Range(0, abilities.Length);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
           Instantiate(abilities[i] ,transform.position ,transform.rotation);
            Destroy(gameObject);
        }
    }
}
