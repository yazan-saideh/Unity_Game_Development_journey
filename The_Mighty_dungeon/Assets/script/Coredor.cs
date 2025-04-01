using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coredor : MonoBehaviour
{
    public int coredor;
    private RoomTemplete templete;
    public bool isspwan = false;
    // Start is called before the first frame update
    void Start()
    {
        templete = GameObject.FindGameObjectWithTag("room").GetComponent<RoomTemplete>();
        Invoke("spawn", 0.1f);
    }

    // Update is called once per frame
    void spawn()
    {if (isspwan == false)
        {
            if (coredor == 1)
            {
                Instantiate(templete.BottomCoreredor, transform.position, templete.BottomCoreredor.transform.rotation);
            }
            else if (coredor == 2)
            {
                Instantiate(templete.TopCoreredor, transform.position, templete.TopCoreredor.transform.rotation);
            }
            else if (coredor == 3)
            {
                Instantiate(templete.RightCoreredor, transform.position, templete.RightCoreredor.transform.rotation);
            }
            else if (coredor == 4)
            {
                Instantiate(templete.LeftCoreredor, transform.position, templete.LeftCoreredor.transform.rotation);
            }
            isspwan = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("coredor"))
        {
            if (collision.GetComponent<Coredor>().isspwan == false && isspwan == false)
            {
                Instantiate(templete.closedroom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            isspwan = true;
        }
    }
}
