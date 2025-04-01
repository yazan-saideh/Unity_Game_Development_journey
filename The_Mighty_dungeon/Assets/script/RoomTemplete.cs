using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplete : MonoBehaviour
{
    public GameObject[] bottomroom;
    public GameObject[] toproom;
    public GameObject[] leftroom;
    public GameObject[] rightroom;
    public GameObject BottomCoreredor;
    public GameObject RightCoreredor;
    public GameObject LeftCoreredor;
    public GameObject TopCoreredor;
    public GameObject closedroom;
    public List<GameObject> rooms;
    public float waittime;
    public GameObject boss;
    private bool spawnedboss;

    void Update()
    {
        if (waittime <= 0 && spawnedboss == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if(i == rooms.Count - 1)
                {
                    Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
                    spawnedboss = true;
                }
            }
        }
        else
        {
            waittime -= Time.deltaTime;
        }
    }
}
