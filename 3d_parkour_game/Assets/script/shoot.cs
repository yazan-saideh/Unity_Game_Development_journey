using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject ninjastar;
    public GameObject tip;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
        if (Input.GetMouseButtonDown(0))
        {
           GameObject ninjastarclone = Instantiate(ninjastar, tip.transform.position, tip.transform.rotation);
        }
    }
}
