using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraLight : MonoBehaviour
{
    public LayerMask mask;
    public GameManager gameManager;
    [Header("Light")]
    public GameObject Light;
    RaycastHit2D hit;
    public float distance;
    public bool Moving;
    public Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       if(Moving == false)
        {
            ani.SetBool("Moving", false);
        }
        else
        {
            ani.SetBool("Moving", true);
        }
        hit = Physics2D.Raycast(Light.transform.position, transform.up, distance, mask);
        //if (Light.transform.rotation.z >= maxR)
       // {
        //   rotation += rotatespeed * -Time.deltaTime;
       /// }
        //  else if(Light.transform.rotation.z <= minR)
       // {
         //   rotation += rotatespeed * Time.deltaTime;
       // }
       // else
       // {
            //rotation += rotatespeed * Time.deltaTime;
       // }
       // rotation = Mathf.Clamp(Light.transform.rotation.z, minR, maxR);
        //transform.rotation = Quaternion.Euler(0, 0, rotation);
        Debug.DrawRay(transform.position, transform.up * distance, Color.red);

        if(hit)
        {
            Debug.Log("hit");
            gameManager.lose();
        }
    }
}
