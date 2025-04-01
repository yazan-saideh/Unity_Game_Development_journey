using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DUNGEON : MonoBehaviour
{
    public int dUNGEON;
    private RoomTemplete templete;
    int rand;
    public bool isspwan = false;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 4);
        templete = GameObject.FindGameObjectWithTag("room").GetComponent<RoomTemplete>();
        Invoke("spwan", 0.1f);
    }

    // Update is called once per frame
    void spwan()
    {
        if (isspwan == false)
        {
            if (dUNGEON == 1)
            {
                rand = Random.Range(0, templete.bottomroom.Length);
                Instantiate(templete.bottomroom[rand], transform.position, templete.bottomroom[rand].transform.rotation);
            }
            //top door
            else if (dUNGEON == 2)
            {
                rand = Random.Range(0, templete.toproom.Length);
                Instantiate(templete.toproom[rand], transform.position, templete.toproom[rand].transform.rotation);
            }
            //left door
            else if (dUNGEON == 3)
            {
                rand = Random.Range(0, templete.leftroom.Length);
                Instantiate(templete.leftroom[rand], transform.position, templete.leftroom[rand].transform.rotation);
            }
            //right door
            else if (dUNGEON == 4)
            {
                rand = Random.Range(0, templete.rightroom.Length);
                Instantiate(templete.rightroom[rand], transform.position, templete.rightroom[rand].transform.rotation);
            }
            //bottom door
            isspwan = true;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("spawnpoint"))
        {
            if (collision.GetComponent<DUNGEON>().isspwan == false && isspwan == false)
            {
                Instantiate(templete.closedroom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            isspwan = true;
        }
       
    }
}
