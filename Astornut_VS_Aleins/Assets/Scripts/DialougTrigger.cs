using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougTrigger : MonoBehaviour
{
    public Dialoug dialoug;
    
    
    // Start is called before the first frame update
    void Start()
    {
            Invoke("wait", 1f);
    }

    // Update is called once per frame
    void wait()
    {
        FindObjectOfType<DialougManager>().startDialoug(dialoug);
        
    }
}
