using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addrooms : MonoBehaviour
{
    private RoomTemplete templete;
    // Start is called before the first frame update
    void Start()
    {
        templete = GameObject.FindGameObjectWithTag("room").GetComponent<RoomTemplete>();
        templete.rooms.Add(this.gameObject);
    }


    private void Update()
    {
        
    }

    
}
