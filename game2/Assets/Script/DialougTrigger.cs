using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougTrigger : MonoBehaviour
{
    public Dialoug dialoug;
    public Animator ani;
    
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("g") == 1)
        {
            ani.SetBool("open", false);
        }
        else
        {
            Invoke("wait", 3f);
        }
    }

    // Update is called once per frame
    void wait()
    {
        FindObjectOfType<DialougManager>().startDialoug(dialoug);
        ani.SetBool("open", true);
    }
}
