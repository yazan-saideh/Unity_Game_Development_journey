using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    Vector3 nextpos;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        nextpos = pos1.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextpos, speed * Time.deltaTime);
        if (transform.position == pos1.position)
        {
            nextpos = pos2.position;
        }
        if (transform.position == pos2.position)
        {
            nextpos = pos1.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

        }
    }
}
