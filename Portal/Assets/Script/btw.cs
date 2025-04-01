using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btw : MonoBehaviour
{
    // Start is called before the first frame update
   static btw instance;
    private void Awake()
    {

        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
