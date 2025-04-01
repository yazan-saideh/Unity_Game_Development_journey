using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject projecttile;
    public GameObject tip;
    GameObject player;
    public float btw;
    
    public float shoot;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Vector2.Distance(transform.position , player.transform.position) < 7)
        {
            if(shoot <= 0)
            {
                GameObject fire = Instantiate(projecttile, tip.transform.position, projecttile.transform.rotation);
                
                shoot = btw;
            }
            else
            {
                shoot -= Time.deltaTime;
            }
        }
    }
}
