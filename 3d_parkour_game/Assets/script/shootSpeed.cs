using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootSpeed : MonoBehaviour
{
    public float speed;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        time += Time.deltaTime;
        if (time >= 5)
        {
            Destroy(gameObject);
            time = 0;
        }
    }
    
}
