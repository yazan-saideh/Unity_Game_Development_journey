using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pickup : MonoBehaviour
{
    public float distance = 10f;
    public Transform EquipPos;
    GameObject CurrentWep;
    public bool CanGrab;
    public bool candrop;
    public bool grapmore;

    // Update is called once per frame
    void FixedUpdate()
    {
        canGrab();
        if (grapmore == true)
        {
            if (CanGrab)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    pickup();
                    CurrentWep.transform.rotation = EquipPos.transform.rotation;
                }
            }

        }
        else if (Input.GetKeyDown(KeyCode.C))
        {

        }
    }
    private void canGrab()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, transform.forward, out hit, distance))
        {
            if (hit.transform.tag == "cangrab")
            {
                CurrentWep = hit.transform.gameObject;

                CanGrab = true;
            }
        }
        else
        {
            CanGrab = false;
        }
    }
    private void pickup()
    {

        CurrentWep.transform.position = EquipPos.position;
        CurrentWep.transform.parent = EquipPos;
        CurrentWep.GetComponent<Rigidbody>().isKinematic = true;
        candrop = true;
        grapmore = false;

    }
}
