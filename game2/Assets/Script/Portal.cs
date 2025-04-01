using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform destination;
    public bool isorange;
    public float distance;
    public bool spwaned;
    void Start ()
    {
        InvokeRepeating("spawn", 0.01f, 0.01f);  
    }
    void spawn() {
        if (isorange == false)
        {
            destination = GameObject.FindGameObjectWithTag("OrangePortal").transform;
        }
        else if(isorange == true)
        {
            destination = GameObject.FindGameObjectWithTag("BluePortal").transform;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.tag != "Ground" && collision.tag != "Ground2" && collision.tag != "coin" && collision.tag != "OrangePortal" && collision.tag != "BluePortal")
            {
                if (Vector2.Distance(transform.position, collision.transform.position) > .2f)
                {
                    Debug.Log(collision);
                    
                    collision.gameObject.transform.position = destination.position;
                }
            }
        if (collision.CompareTag("Ground2"))
        {
            gameObject.SetActive(false);

        }
    }
}
