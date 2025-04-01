using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonpressed : MonoBehaviour
{
    public GameObject[] buttons;
    public GameObject[] buttons2;
    public GameObject[] coins; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].GetComponent<Button2>().pressed == true && coins[i].GetComponent<coin>().collected == true)
            {
                GetComponent<Dooropen>().pressed = true;
            }
            else 
            {
                GetComponent<Dooropen>().pressed =false;
            }
        }
        for (int i = 0; i < buttons2.Length; i++)
        {
            if (buttons2[i].GetComponent<lightclose>().pressed == true && coins[i].GetComponent<coin>().collected == true)
            {
                GetComponent<Dooropen>().pressed = true;
            }
            else
            {
                GetComponent<Dooropen>().pressed = false;
            }
        }
    }
}
