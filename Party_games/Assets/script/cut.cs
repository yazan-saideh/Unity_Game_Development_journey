using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cut : MonoBehaviour
{
    public GameObject[] lines;
    public bool check;
    public GameObject[] player;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < player.Length; i++)
        {
            player[i] = GameObject.FindGameObjectWithTag("Player");
        }
        check = false;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Player").Length; i++)
        {
            if (player[i].GetComponent<trueCut>().Cutted == true)
            {
                check = true;
                Debug.Log("Cutted");
            }
        }
    }

        private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < lines.Length; i++)
        {
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<trueCut>().Cutted = true;
                Debug.Log("Cutted");
            }
        }
    }
    
}
