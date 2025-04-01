using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed;
    public Transform startpos;
    Vector3 nexpos;
    // Start is called before the first frame update
    void Start()
    {
        nexpos = startpos.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position == pos1.position)
        {
            nexpos = pos2.position;
        }
        if(transform.position == pos2.position)
        {
            nexpos = pos1.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nexpos, speed * Time.deltaTime);
    }
}
